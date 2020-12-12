using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;
namespace FinSvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FinConnect : IFinConnect
    {
        public static string serv_host_addr = ConfigurationManager.AppSettings["serv_host_addr"];
        public static int serv_tcp_port = Convert.ToInt32(ConfigurationManager.AppSettings["server_tcp_port"]);
        private decimal _AvailBal = 0;
        private decimal _UnclrBal = 0;
        private decimal _BookBal = 0;
        private int _RespCode;
        private int _Amt_Txn = 0;

        private System.Diagnostics.EventLog FinEvent = null;

        public decimal AvailBal
        {
            get { return _AvailBal; }
        }
        public decimal UnclrBal
        {
            get { return _UnclrBal; }
        }
        public decimal BookBal
        {
            get { return _BookBal; }
        }
        public int RespCode
        {
            get { return _RespCode; }
        }
        public decimal Amt_Txn
        {
            get { return _Amt_Txn; }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int BalanceEnquiry(TransactionParams param, string cod_acct_no)
        {
            try
            {
                if (param == null)
                {
                    throw new ArgumentNullException("param");
                }
                FinConMessenger fMsgr = new FinConMessenger(serv_host_addr, serv_tcp_port);
                fMsgr.FinConMsg.AcquirerInstId = param.acq_inst_id;
                fMsgr.FinConMsg.CardAcceptorTerminalId = param.ca_term_id;
                fMsgr.FinConMsg.CardAcceptorId = param.ca_id_cod;
                fMsgr.FinConMsg.TransactionCurrenyCode = param.trn_cur_cod;
                fMsgr.FinConMsg.SettlementCurrencyCode = param.stl_cur_cod;
                fMsgr.FinConMsg.CardHolderBillingCurrencyCode = param.chd_bil_cur_cod;
                fMsgr.FinConMsg.LocalDateTime = DateTime.Now;
                fMsgr.FinConMsg.PrimaryAccountNo = cod_acct_no;
                fMsgr.FinConMsg.SettlementDateTime = DateTime.Now;
                fMsgr.FinConMsg.TransmissionDateTime = DateTime.Now;
                fMsgr.FinConMsg.CaptureDateTime = DateTime.Now;

                //build and send iso msg to atms
                fMsgr.SendBalanceInquiry();
                _RespCode = fMsgr.FinConMsg.ResponseCode2;
                if (_RespCode == 0)
                {
                    //availbal
                    if (fMsgr.FinConMsg.AvailableBalance.CreditDebit.ToString() == "C")
                    {
                        _AvailBal = fMsgr.FinConMsg.AvailableBalance.Amount / 100;
                    }
                    else if (fMsgr.FinConMsg.AvailableBalance.CreditDebit.ToString() == "D")
                    {
                        _AvailBal = -1 * (fMsgr.FinConMsg.AvailableBalance.Amount / 100);
                    }
                    //unclr_effect
                    if (fMsgr.FinConMsg.UnclearedFunds.CreditDebit.ToString() == "C")
                    {
                        _UnclrBal = fMsgr.FinConMsg.UnclearedFunds.Amount / 100;  // base currency is kobo

                    }
                    else if (fMsgr.FinConMsg.UnclearedFunds.CreditDebit.ToString() == "D")
                    {
                        _UnclrBal = -1 * (fMsgr.FinConMsg.UnclearedFunds.Amount / 100);
                    }
                    //ledg bal
                    if (fMsgr.FinConMsg.LedgerBalance.CreditDebit.ToString() == "C")
                    {
                        _BookBal = fMsgr.FinConMsg.LedgerBalance.Amount / 100;
                    }
                    else if (fMsgr.FinConMsg.LedgerBalance.CreditDebit.ToString() == "D")
                    {
                        _BookBal = -1 * (fMsgr.FinConMsg.LedgerBalance.Amount / 100);
                    }
                }
                return 0;  //no error occurred return 0

            }
            catch (Exception ex)
            {
                FinEvent.WriteEntry(ex.Message + "\n" + ex.StackTrace);
                //return 999;
                DatabaseFault df = new DatabaseFault();
                df.DbMessage =  ex.Message;
                df.DbOperation = "BalanceEnquiry";
                df.DbReason = "Exception while sending bal enquiry : ";
                throw new FaultException <DatabaseFault>(df);
                

            }
        }

        public int FundTransfer(TransactionParams param, string cod_acct_no_pri, string src_cod_acct_no, string dest_cod_acct_no, decimal amt_txn)
        {
            try
            {
                FinConMessenger fMsgr = new FinConMessenger(serv_host_addr, serv_tcp_port);
                fMsgr.FinConMsg.AcquirerInstId = param.acq_inst_id;
                fMsgr.FinConMsg.CardAcceptorTerminalId = param.ca_term_id;
                fMsgr.FinConMsg.CardAcceptorId = param.ca_id_cod;
                fMsgr.FinConMsg.TransactionCurrenyCode = param.trn_cur_cod;
                fMsgr.FinConMsg.SettlementCurrencyCode = param.stl_cur_cod;
                fMsgr.FinConMsg.CardHolderBillingCurrencyCode = param.chd_bil_cur_cod;
                fMsgr.FinConMsg.TransactionAmount = amt_txn;
                fMsgr.FinConMsg.LocalDateTime = DateTime.Now;
                fMsgr.FinConMsg.PrimaryAccountNo = src_cod_acct_no;
                fMsgr.FinConMsg.SecondaryAccountNo = dest_cod_acct_no;
                fMsgr.FinConMsg.SettlementDateTime = DateTime.Now;
                fMsgr.FinConMsg.TransmissionDateTime = DateTime.Now;
                fMsgr.FinConMsg.CaptureDateTime = DateTime.Now;
                //build and send iso msg to atms
                fMsgr.SendFundsTransfer();
                _RespCode = fMsgr.FinConMsg.ResponseCode2;
                if (_RespCode == 0)
                {
                }
                return 0;  ///no error occured return 0

            }
            catch (Exception ex)
            {
                FinEvent.WriteEntry(ex.Message);
                return 999;
            }
        }
        private static string DecodeProcessCode(int cod_proc)
        {
            string iso_req_msg;
            switch (cod_proc)
            {
                case 011000: iso_req_msg = "CashWithDrawal"; break;
                case 012000: iso_req_msg = "CashWithDrawal"; break;

                case 211000: iso_req_msg = "CashDeposit"; break;
                case 212000: iso_req_msg = "CashDeposit"; break;

                case 381000: iso_req_msg = "MiniStateMent"; break;
                case 382000: iso_req_msg = "MiniStateMent"; break;

                case 311000: iso_req_msg = "BalanceInquiry"; break;
                case 302000: iso_req_msg = "BalanceInquiry"; break;

                case 401010: iso_req_msg = "FundTransfer"; break;
                case 401020: iso_req_msg = "FundTransfer"; break;
                case 402010: iso_req_msg = "FundTransfer"; break;
                case 402020: iso_req_msg = "FundTransfer"; break;
                case 501010: iso_req_msg = "FundTransfer"; break;
                case 501020: iso_req_msg = "FundTransfer"; break;
                case 502010: iso_req_msg = "FundTransfer"; break;
                case 502020: iso_req_msg = "FundTransfer"; break;


                default: iso_req_msg = "Msg Not Set"; break;
            }
            return iso_req_msg;
        }
    }
}
