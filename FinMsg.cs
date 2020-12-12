using System;
using System.Text;

namespace FinSvc
{
    public enum ACCOUNT_TYPE
    {
        CurrentAc = 1,
        SavingsAc = 2
    };
    public enum MESSAGE_TYPE
    {
        Normal = 200,
        NormalResponse = 210,
        Reversal = 400,
        ReversalResponse = 410,
        NetworkEcho = 800,
        NetworkEchoRev = 810
    }
    public enum PROCESS_CODE
    {
        BalanceInquiryCA = 311000,
        BalanceInquirySA = 301000,
        CashWithdrawalCA = 11000,
        CashWithdrawalSA = 12000,
        FundTransferCA = 401010,
        FundTransferSA = 402010,
        MiniStatementCA = 381000,
        MiniStatementSA = 382000,
        NormalPurchaseCA = 1000,
        NormalPurchaseSA = 2000
    };
    public class FinConMessage
    {
        public struct AdditionalAmt
        {
            public int AccountType;
            public int AmountType;
            public string CurrencyCode;
            public char CreditDebit;
            public decimal Amount;
        }
        PROCESS_CODE m_ProCode;
        MESSAGE_TYPE m_MsgType;
        string m_PriAcNo;
        decimal m_TrnAmt;
        decimal m_StlAmt;
        DateTime m_LocDateTime;
        DateTime m_StlDateTime;
        DateTime m_CapDateTime;
        DateTime m_ExpDateTime;
        decimal m_CHBAmt;
        int m_MerchantType;
        DateTime m_TrmDateTime;
        decimal m_CHBFee;
        decimal m_StlConvRate;
        decimal m_CHBConvRate;
        decimal m_TrnFee;
        decimal m_StlFee;
        decimal m_TrnPrcFee;
        decimal m_StlProFee;
        string m_AcqInstId;
        string m_FwdInstId;
        int m_RespCode;
        string m_CAPTermld;
        string m_CAPName = "";
        string m_CAPId;
        string m_TrnCcyCode;
        string m_StlCcyCode;
        string m_CHBCcyCode;
        string m_SecAcNo;
        decimal m_TransProcFee;
        decimal m_StlProcFee;
        int m_RetRefNo;
        int m_TraceNo;
        int m_PosEntryMode;
        int m_PosCapCode;
        int m_PosCondCode;
        int m_CardSeqNo;
        int m_NetworkMgmCode;
        string m_CAPLoc;
        ACCOUNT_TYPE m_AcType;
        /// <summary>
        /// Laolu 18-sep-2007*/
        /// Added full response message
        /// </summary>

        int m_RespCode2;	//needed cosRespCode not accurately parsed --Laolu
        string m_iso_msg;
        public string M_iso_msg
        {
            get { return m_iso_msg; }
        }
        public int ResponseCode2
        {
            get
            {
                return this.m_RespCode2;
            }

        }

        public FinConMessage()
        {
            m_TraceNo = 0;
            m_RetRefNo = 0;
        }
        public decimal TransactionAmount
        {
            get
            {
                return m_TrnAmt;
            }
            set
            {
                m_TrnAmt = value;
            }
        }
        public DateTime SettlementDateTime
        {
            get
            {
                return m_StlDateTime;
            }
            set
            {
                m_StlDateTime = value;
            }
        }
        public DateTime CaptureDateTime
        {
            get
            {
                return m_CapDateTime;
            }
            set
            {
                m_CapDateTime = value;
            }
        }
        public DateTime TransmissionDateTime
        {
            get
            {
                return m_TrmDateTime;
            }
            set
            {
                m_TrmDateTime = value;
            }
        }
        public DateTime LocalDateTime
        {
            get
            {
                return m_LocDateTime;
            }
            set
            {
                m_LocDateTime = value;
            }
        }
        public string SecondaryAccountNo
        {
            get
            {
                return m_SecAcNo;
            }
            set
            {
                m_SecAcNo = value;
                if (m_SecAcNo.Length > 17)
                {
                    m_SecAcNo = m_SecAcNo.Substring(0, 17);
                }
            }
        }
        public string PrimaryAccountNo
        {
            get
            {
                return m_PriAcNo;
            }
            set
            {
                m_PriAcNo = value;
                if (m_PriAcNo.Length > 17)
                {
                    m_PriAcNo = m_PriAcNo.Substring(0, 17);
                }
            }
        }

        public ACCOUNT_TYPE CardAccountType
        {
            get
            {
                return m_AcType;
            }
            set
            {

                m_AcType = value;
            }

        }
        public MESSAGE_TYPE MessageType
        {
            get
            {
                return m_MsgType;
            }
            set
            {
                m_MsgType = value;
            }

        }
        public PROCESS_CODE ProcessCode
        {
            get
            {
                return m_ProCode;
            }
            set
            {
                m_ProCode = value;
            }
        }
        public string FowarderInst
        {
            get
            {
                return m_FwdInstId;
            }
            set
            {
                m_FwdInstId = value;
                if (m_FwdInstId.Length > 9)
                {
                    m_FwdInstId = m_FwdInstId.Substring(0, 9);
                }
            }
        }
        public string AcquirerInstId
        {
            get
            {
                return m_AcqInstId;
            }
            set
            {
                m_AcqInstId = value;
                if (m_AcqInstId.Length > 9)
                {
                    m_AcqInstId = m_AcqInstId.Substring(0, 9);
                }

            }
        }
        public string CardAcceptorTerminalId
        {
            get
            {
                return m_CAPTermld;
            }
            set
            {
                m_CAPTermld = value;
                if (m_CAPTermld.Length > 8)
                {
                    m_CAPTermld = m_CAPTermld.Substring(0, 8);
                }


            }
        }
        public string CardAcceptorId
        {
            get
            {
                return m_CAPId;
            }
            set
            {
                m_CAPId = value;
                if (m_CAPId.Length > 15)
                {
                    m_CAPId = m_CAPId.Substring(0, 15);
                }
            }
        }
        public string CardAcceptorName
        {
            get
            {
                return m_CAPName;
            }
            set
            {
                m_CAPName = value;
            }
        }
        public string CurrencyCode
        {
            get
            {
                return m_TrnCcyCode;
            }
            set
            {
                m_TrnCcyCode = value;
            }
        }
        public int MerchantType
        {
            get
            {
                return m_MerchantType;
            }
            set
            {
                m_MerchantType = value;
            }
        }
        public int POSEntryMode
        {
            get
            {
                return m_PosEntryMode;
            }
            set
            {
                m_PosEntryMode = value;
            }
        }
        public int POSCaptureCode
        {
            get
            {
                return m_PosCapCode;
            }
            set
            {
                m_PosCapCode = value;
            }
        }
        public int CardSequenceNo
        {
            get
            {
                return m_CardSeqNo;
            }
            set
            {
                m_CardSeqNo = value;
            }
        }
        public int POSConditionCode
        {
            get
            {
                return m_PosCondCode;
            }
            set
            {
                m_PosCondCode = value;
            }
        }
        public string CardAcceptorLocation
        {
            get
            {
                return m_CAPLoc;
            }
            set
            {
                m_CAPLoc = value;
            }
        }

        public string TransactionCurrenyCode
        {
            get
            {
                return this.m_TrnCcyCode;
            }
            set
            {
                this.m_TrnCcyCode = value;
                if (this.m_TrnCcyCode.Length > 3)
                {
                    this.m_TrnCcyCode = this.m_TrnCcyCode.Substring(0, 3);
                }
                m_TrnCcyCode = m_TrnCcyCode.PadLeft(3, '0');
            }
        }
        public string SettlementCurrencyCode
        {
            get
            {
                return this.m_StlCcyCode;
            }
            set
            {
                this.m_StlCcyCode = value;
                if (this.m_StlCcyCode.Length > 3)
                {
                    this.m_StlCcyCode = this.m_StlCcyCode.Substring(0, 3);
                }
                this.m_StlCcyCode = this.m_StlCcyCode.PadLeft(3, '0');
            }
        }
        public DateTime DateExpiration
        {
            get
            {
                return m_ExpDateTime;

            }
            set
            {
                m_ExpDateTime = value;
            }
        }
        public string CardHolderBillingCurrencyCode
        {
            get
            {
                return this.m_CHBCcyCode;
            }
            set
            {
                m_CHBCcyCode = value;
                if (m_CHBCcyCode.Length > 3)
                {
                    m_CHBCcyCode = m_CHBCcyCode.Substring(0, 3);
                }
                m_CHBCcyCode = m_CHBCcyCode.PadLeft(3, '0');
            }

        }

        public decimal CardHolderBillingConvRate
        {
            get
            {
                return m_CHBConvRate;
            }
            set
            {
                m_CHBConvRate = value;
            }

        }


        public AdditionalAmt AvailableBalance;

        public AdditionalAmt UnclearedFunds;

        public AdditionalAmt LedgerBalance;


        public int RetrievalReferenceNo
        {
            get
            {
                return m_RetRefNo;
            }
        }
        public decimal TransactionProcFee
        {
            get
            {
                return m_TransProcFee;
            }
            set
            {
                m_TransProcFee = value;
            }
        }
        public decimal SettlementProcFee
        {
            get
            {
                return m_StlProcFee;
            }
            set
            {
                m_StlProcFee = value;
            }
        }
        public int ResponseCode
        {
            get
            {
                return this.m_RespCode;
            }

        }
        public int NetworkManagementCode
        {
            get
            {
                return m_NetworkMgmCode;
            }
            set
            {
                m_NetworkMgmCode = value;
            }
        }
        public byte[] EncodeToISO(byte[] avb_flds)
        {
            m_TraceNo++;
            string msg_body = "";


            ////fld 1 Bitmap

            ////check if fld 1 is set    -laolu
            //if (IsFieldAvailable(avb_flds, 1))
            //{
            //   msg_body = m_PriAcNo.Length.ToString().PadLeft(2, '0') + m_PriAcNo;
            //}

            //fld 2 Primary Account Number 

            //check if fld 2 is set
            if (IsFieldAvailable(avb_flds, 2))
            {
                //reserve 2 bytes for length and trim
                msg_body = m_PriAcNo.Length.ToString().PadLeft(2, '0') + m_PriAcNo;
            }
            //fld 3 process code
            if (IsFieldAvailable(avb_flds, 3))
            {
                int vProCode = (int)m_ProCode;
                msg_body += vProCode.ToString().PadLeft(6, '0').Substring(0, 6);
            }

            // fld 4 transaction  transaction amount
            if (IsFieldAvailable(avb_flds, 4))
            {
                msg_body += m_TrnAmt.ToString().PadLeft(12, '0');
            }

            // fld 5 settlement amount

            if (IsFieldAvailable(avb_flds, 5))
            {
                msg_body += m_StlAmt.ToString().PadLeft(12, '0');
            }

            // fld 6 card holder billing
            if (IsFieldAvailable(avb_flds, 6))
            {
                msg_body += m_CHBAmt.ToString().PadLeft(12, '0');
            }

            //fld 7 transmission date time

            if (IsFieldAvailable(avb_flds, 7))
            {

                msg_body +=
                m_TrmDateTime.Month.ToString().PadLeft(2, '0') +
                m_TrmDateTime.Day.ToString().PadLeft(2, '0') +
                m_TrmDateTime.Hour.ToString().PadLeft(2, '0') +
                m_TrmDateTime.Minute.ToString().PadLeft(2, '0') +
                m_TrmDateTime.Second.ToString().PadLeft(2, '0');
            }
            //fld 8 card holder billing fee

            if (IsFieldAvailable(avb_flds, 8))
            {
                msg_body += m_CHBFee.ToString().PadLeft(12, '0');
            }
            //fld 9 conversion rate settlement
            if (IsFieldAvailable(avb_flds, 9))
            {
                msg_body += m_StlConvRate.ToString().PadLeft(8, '0');
            }

            //fld 10 conversion rate billing
            if (IsFieldAvailable(avb_flds, 10))
            {
                msg_body += m_CHBConvRate.ToString().PadLeft(8, '0');
            }

            //fld 11 system audit trace no
            if (IsFieldAvailable(avb_flds, 11))
            {
                msg_body += m_TraceNo.ToString().PadLeft(6, '0');
            }

            //fld 12 time local transaction 
            if (IsFieldAvailable(avb_flds, 12))
            {
                msg_body +=
                m_LocDateTime.Hour.ToString().PadLeft(2, '0') +
                m_LocDateTime.Minute.ToString().PadLeft(2, '0') +
                m_LocDateTime.Second.ToString().PadLeft(2, '0');
            }
            //fld 13 date local transaction 
            if (IsFieldAvailable(avb_flds, 13))
            {
                msg_body +=
                    m_LocDateTime.Month.ToString().PadLeft(2, '0') +
                    m_LocDateTime.Day.ToString().PadLeft(2, '0');
            }

            //fld 14 date expiration
            if (IsFieldAvailable(avb_flds, 14))
            {
                msg_body +=
                m_ExpDateTime.Month.ToString().PadLeft(2, '0') +
                m_ExpDateTime.Day.ToString().PadLeft(2, '0');
            }

            //fld 15 date settlement
            if (IsFieldAvailable(avb_flds, 15))
            {
                msg_body +=
                    m_StlDateTime.Month.ToString().PadLeft(2, '0') +
                    m_StlDateTime.Day.ToString().PadLeft(2, '0');
            }
            //fld 17 build capture date
            if (IsFieldAvailable(avb_flds, 17))
            {
                msg_body +=
                    m_CapDateTime.Month.ToString().PadLeft(2, '0') +
                    m_CapDateTime.Day.ToString().PadLeft(2, '0');
            }

            //fld 18 Message type merchant type n4

            if (IsFieldAvailable(avb_flds, 18))
            {
                msg_body += m_MerchantType.ToString().PadLeft(4, '0');
            }

            //fld 22 POS entry mode n3
            if (IsFieldAvailable(avb_flds, 22))
            {
                msg_body += m_PosEntryMode.ToString().PadLeft(3, '0');
            }
            //fld 23 Card Sequence No n3
            if (IsFieldAvailable(avb_flds, 22))
            {
                msg_body += m_CardSeqNo.ToString().PadLeft(3, '0');
            }
            //fld 25 POS Condition Code n2
            if (IsFieldAvailable(avb_flds, 25))
            {
                msg_body += m_PosCondCode.ToString().PadLeft(2, '0');
            }

            //fld 25 POS Capture Code
            if (IsFieldAvailable(avb_flds, 26))
            {
                msg_body += m_PosCapCode.ToString().PadLeft(2, '0');
            }

            //fld 27

            //fld 30 Transaction Processing Fee x+n8

            if (IsFieldAvailable(avb_flds, 30))
            {
                msg_body += m_TransProcFee.ToString().PadLeft(8, '0');
            }

            //fld 31 settlement processing fee x + n8
            if (IsFieldAvailable(avb_flds, 31))
            {
                msg_body += m_StlProcFee.ToString().PadLeft(8, '0');
            }

            //fld 32 Acquiring Institution Identification Code  LL VAR  n..11
            if (IsFieldAvailable(avb_flds, 32))
            {
                msg_body += m_AcqInstId.Length.ToString().PadLeft(2, '0') + m_AcqInstId;
            }
            //fld 37 Retrieval Reference No 
            if (IsFieldAvailable(avb_flds, 37))
            {
                msg_body += m_RetRefNo.ToString().PadLeft(12, '0');
            }
            //fld 39 response code
            if (IsFieldAvailable(avb_flds, 39))
            {
                msg_body += m_RespCode.ToString().PadLeft(2, '0');
            }
            //fld 41 Card Acceptor Terminal Id   n..8
            if (IsFieldAvailable(avb_flds, 41))
            {
                msg_body += m_CAPTermld.PadRight(8, '?');
            }
            //fld 42 Card Acceptor Identification Code  ans 15
            if (IsFieldAvailable(avb_flds, 42))
            {
                msg_body += this.m_CAPId.PadRight(15, '?');//mark 0
            }

            //fld 43 Card Acceptor Name ans 40

            if (IsFieldAvailable(avb_flds, 43))
            {
                if (m_CAPName == "")
                {
                    m_CAPName = m_CAPId.Substring(0, 14); //if Card Acceptor Name is not Set fill it with the Card Acceptor Id
                }
                msg_body += m_CAPName.PadRight(40, '?');//mark 0
            }

            //fld 49 Transaction ccy code 
            if (IsFieldAvailable(avb_flds, 49))
            {
                msg_body += m_TrnCcyCode;
            }
            //fld 50 Settlement ccy code   not compulsory
            if (IsFieldAvailable(avb_flds, 50))
            {
                msg_body += m_StlCcyCode;
            }
            //fld 51 Card Holder Billing not compulsory adjust bitmap
            if (IsFieldAvailable(avb_flds, 51))
            {
                msg_body += m_CHBCcyCode;
            }
            //fld 60 Reserved Private
            if (IsFieldAvailable(avb_flds, 60))
            {
                msg_body +=
                    "016" +
                    m_LocDateTime.Year.ToString() +
                    m_StlDateTime.Year.ToString() +
                    m_CapDateTime.Year.ToString() +
                    m_TrmDateTime.Year.ToString();
            }

            if (IsFieldAvailable(avb_flds, 102))
            {
                msg_body += m_PriAcNo.Length.ToString().PadLeft(2, '0') + m_PriAcNo;
            }

            if (IsFieldAvailable(avb_flds, 103))
            {
                msg_body += m_SecAcNo.Length.ToString().PadLeft(2, '0') + m_SecAcNo;
            }
            //build the iso msg body
            byte[] iso_msg_body = Encoding.ASCII.GetBytes(msg_body);
            //replace all ? with 0
            for (int i = 0; i < iso_msg_body.Length; i++)
                if (iso_msg_body[i] == 63) iso_msg_body[i] = 0;

            //iso msg = msg header + msg_body

            //build msg header

            //msg_header = msglen(2b) + bitmap(8/16b)    + process code(4b)
            byte[] bitmap = GenBinBitmap(ref avb_flds);
            int iso_msg_len = bitmap.Length + iso_msg_body.Length + 6;//msglen(2b)+processcode(4b)

            byte[] iso_msg = new byte[iso_msg_len];
            iso_msg[1] = (byte)(iso_msg_len - 2);//exclude first 2 bytes

            int ins_idx = 2; //skip to message type

            //insert message type
            int iMsgType = (int)m_MsgType;
            byte[] bMsgType = Encoding.ASCII.GetBytes(iMsgType.ToString().PadLeft(4, '0'));

            for (int i = 0; i < bMsgType.Length; i++)
                iso_msg[i + ins_idx] = bMsgType[i];

            ins_idx += 4; //skip to bitmap

            //insert bitmap
            for (int i = 0; i < bitmap.Length; i++)
                iso_msg[i + ins_idx] = bitmap[i];

            //insert msg body
            ins_idx += bitmap.Length; //skip to msg body
            for (int i = 0; i < iso_msg_body.Length; i++)
                iso_msg[i + ins_idx] = iso_msg_body[i];
            return iso_msg;
        }
        public FinConMessage DecodeFromISO(byte[] iso_msg)
        {
            //check if iso msg is valid
            FinConMessage fin_msg = new FinConMessage();
            if (iso_msg != null)
            {
                //get the length of the iso msg body
                bool blnExtBitmap = false;
                string strTrmDateTime = "";
                string strLocTranDateTime = "";
                string strCapDateTime = "";
                string strStlDateTime = "";
                byte[] pBitmap = new byte[8];
                Array.Copy(iso_msg, 6, pBitmap, 0, 8);
                byte[] Bitmap = new byte[16];
                if (IsFieldSet(pBitmap, 1))			//check for extended bitmap
                {
                    Array.Copy(iso_msg, 6, Bitmap, 0, 16); //secondary bitmap
                    blnExtBitmap = true;
                }
                else
                    Array.Copy(iso_msg, 6, Bitmap, 0, 8); // primary bitmap

                int MsgLen = Int32.Parse(iso_msg[0].ToString() + iso_msg[1].ToString());
                try
                {
                    //get the bitmap 
                    int cur_idx = 0;
                    fin_msg.MessageType = (MESSAGE_TYPE)Int32.Parse(Encoding.ASCII.GetString(iso_msg, 2, 4));

                    if (blnExtBitmap)
                        cur_idx = 22;// skip secondary bitmap
                    else
                        cur_idx = 14;//skip primary bitmap

                    //fld 2 primary account #

                    string msg_body = Encoding.ASCII.GetString(iso_msg, cur_idx, iso_msg.Length - cur_idx).ToString();
                    m_iso_msg = msg_body;
                    cur_idx = 0;
                    if (IsFieldSet(Bitmap, 2))
                    {
                        //get the length 
                        int pan_len = Int32.Parse(msg_body.Substring(cur_idx, 2));

                        //skip the PAN length
                        cur_idx += 2;

                        //decode the PAN
                        fin_msg.m_PriAcNo = msg_body.Substring(cur_idx, pan_len);

                        //skip to next fld
                        cur_idx += pan_len;
                    }

                    //fld 3 processing code
                    if (IsFieldSet(Bitmap, 3))
                    {
                        //get processing code
                        fin_msg.m_ProCode = (PROCESS_CODE)Int32.Parse(msg_body.Substring(cur_idx, 6));
                        //skip to the next field
                        cur_idx += 6;

                    }

                    //fld 4 transaction amount
                    if (IsFieldSet(Bitmap, 4))
                    {
                        //get the transaction amount
                        fin_msg.m_TrnAmt = Decimal.Parse(msg_body.Substring(cur_idx, 12));
                        //skip to the next fld
                        cur_idx += 12;
                    }

                    //fld 5 settlement amount
                    if (IsFieldSet(Bitmap, 5))
                    {
                        //get the transaction amount
                        this.m_StlAmt = Decimal.Parse(msg_body.Substring(cur_idx, 12));
                        //skip to the next fld
                        cur_idx += 12;
                    }

                    //fld 6 cardholder billing amount
                    if (IsFieldSet(Bitmap, 6))
                    {
                        //get the transaction amount
                        fin_msg.m_CHBAmt = Decimal.Parse(msg_body.Substring(cur_idx, 12));
                        //skip to the next fld
                        cur_idx += 12;
                    }

                    //fld 7 transmission date time
                    if (IsFieldSet(Bitmap, 7))
                    {

                        //get the transmission date and time
                        strTrmDateTime = msg_body.Substring(cur_idx, 10);

                        //skip to the next fld
                        cur_idx += 10;
                    }

                    //fld 8 card holder billing fee amount
                    if (IsFieldSet(Bitmap, 8))
                    {
                        //get the card holder billing fee
                        fin_msg.m_CHBFee = Decimal.Parse(msg_body.Substring(cur_idx, 8));
                        //skip to the next field
                        cur_idx += 8;
                    }

                    //fld 9 conversion rate settlement
                    if (IsFieldSet(Bitmap, 9))
                    {
                        //get the card holder billing fee
                        fin_msg.m_StlConvRate = Decimal.Parse(msg_body.Substring(cur_idx, 8));
                        //skip to the next field
                        cur_idx += 8;
                    }

                    //fld 10 conversion rate settlement
                    if (IsFieldSet(Bitmap, 10))
                    {
                        //get the card holder billing fee

                        fin_msg.m_CHBFee = Decimal.Parse(msg_body.Substring(cur_idx, 8));

                        //skip to the next field
                        cur_idx += 8;
                    }

                    //fld 11 system trace audit number
                    if (IsFieldSet(Bitmap, 11))
                    {
                        //get the system audit trace #
                        fin_msg.m_TraceNo = Int32.Parse(msg_body.Substring(cur_idx, 6));

                        //skip to the next field
                        cur_idx += 6;
                    }

                    //fld 12 time local transaction
                    if (IsFieldSet(Bitmap, 12) && IsFieldSet(Bitmap, 13))
                    {
                        //parse fld 12 time  local transaction
                        strLocTranDateTime = msg_body.Substring(cur_idx, 6);
                        cur_idx += 6;

                        //parse fld 13 date local transaction 
                        strLocTranDateTime = msg_body.Substring(cur_idx, 4) + strLocTranDateTime;
                        cur_idx += 4;
                    }

                    //fld 13 date local transaction
                    //combined with fld 12

                    //fld 14 ??????????????????????


                    //fld 15 date settlement MMDD
                    if (IsFieldSet(Bitmap, 15))
                    {
                        //get the settlement date MMDD
                        strStlDateTime = msg_body.Substring(cur_idx, 4);
                        //adjust for HHMMSS
                        strStlDateTime += "000000";

                        //skip to the next field
                        cur_idx += 4;

                    }


                    //fld 16 ??????????????????????

                    //fld 17 date capture
                    if (IsFieldSet(Bitmap, 17))
                    {
                        //get the system audit trace # n4

                        //get the capture date MMDD
                        strCapDateTime = msg_body.Substring(cur_idx, 4);
                        //adjust for HHMMSS
                        strCapDateTime += "000000";
                        //skip to the next field
                        cur_idx += 4;
                    }


                    //fld 18 - 27 ??????????????????

                    //fld 28 transaction fee x + n8

                    if (IsFieldSet(Bitmap, 28))
                    {
                        //get the transaction fee x + n8
                        fin_msg.m_TrnFee = Decimal.Parse(msg_body.Substring(cur_idx, 8));

                        //skip to the next field
                        cur_idx += 8;
                    }

                    //fld 29 settlement fee
                    if (IsFieldSet(Bitmap, 29))
                    {
                        //get the settlement fee x + n8
                        fin_msg.m_StlFee = Decimal.Parse(msg_body.Substring(cur_idx, 8));

                        //skip to the next field
                        cur_idx += 8;
                    }

                    //fld 30 transaction processing fee x + n8

                    if (IsFieldSet(Bitmap, 30))
                    {
                        //get the settlement fee x + n8
                        fin_msg.m_TrnPrcFee = Decimal.Parse(msg_body.Substring(cur_idx, 8));

                        //skip to the next field
                        cur_idx += 8;
                    }

                    //fld 31 settlement processing fee

                    if (IsFieldSet(Bitmap, 31))
                    {
                        //get the settlement processing fee x + n8
                        fin_msg.m_StlProFee = Decimal.Parse(msg_body.Substring(cur_idx, 8));

                        //skip to the next field
                        cur_idx += 8;
                    }

                    //fld 32 acquiring institution id code n..11

                    if (IsFieldSet(Bitmap, 32))
                    {
                        //get the length of aquiriing inst
                        int acq_len = Int32.Parse(msg_body.Substring(cur_idx, 2));

                        //skip the length
                        cur_idx += 2;

                        //acquiring institution id code
                        fin_msg.m_AcqInstId = msg_body.Substring(cur_idx, acq_len);

                        //skip to the next field
                        cur_idx += acq_len;
                    }

                    //fld 33 fowarding institution code
                    if (IsFieldSet(Bitmap, 33))
                    {
                        //get the length of fowarding institution code
                        int fwd_len = Int32.Parse(msg_body.Substring(cur_idx, 2));

                        //skip the length
                        cur_idx += 2;

                        //acquiring institution id code
                        fin_msg.m_FwdInstId = msg_body.Substring(cur_idx, fwd_len);

                        //skip to the next field
                        cur_idx += fwd_len;

                    }

                    //trace no fld 37
                    if (IsFieldSet(Bitmap, 37))
                    {
                        fin_msg.m_TraceNo = Int32.Parse(msg_body.Substring(cur_idx, 12));
                        cur_idx += 12;
                    }

                    //fld 39 response code
                    if (IsFieldSet(Bitmap, 39))
                    {
                        if (fin_msg.MessageType == MESSAGE_TYPE.NormalResponse)
                        {
                        }
                        //get the length of fowarding institution code
                        fin_msg.m_RespCode = Int32.Parse(msg_body.Substring(cur_idx, 2));
                        //skip the length
                        cur_idx += 2;
                    }
                    fin_msg.m_RespCode2 = GetResponseCode(msg_body, m_CAPTermld);

                    //fld 41 card acceptor terminal identification ans 8

                    if (IsFieldSet(Bitmap, 41))
                    {
                        // adjustment <laolu>
                        cur_idx += 6;
                        //get the cceptor terminal identification
                        fin_msg.m_CAPTermld = msg_body.Substring(cur_idx, 8);
                        //skip the length
                        fin_msg.m_CAPTermld = fin_msg.m_CAPTermld.Replace("\0", "");
                        cur_idx += 8;

                    }

                    //fld 42 card acceptor identification code ans 15

                    if (IsFieldSet(Bitmap, 42))
                    {
                        //get the card acceptor identification code
                        fin_msg.m_CAPId = msg_body.Substring(cur_idx, 15);
                        //skip to the next fld
                        cur_idx += 15;
                    }
                    if (IsFieldSet(Bitmap, 43))
                    {
                        fin_msg.m_CAPName = msg_body.Substring(cur_idx, 40);
                        //skip to the next fld
                        cur_idx += 40;
                    }

                    //fld 49 transaction currency code

                    if (IsFieldSet(Bitmap, 49))
                    {
                        //get the transaction currency code
                        fin_msg.m_TrnCcyCode = msg_body.Substring(cur_idx, 3);

                        //skip to the next fld
                        cur_idx += 3;
                    }

                    //fld 50 settlement currency code

                    if (IsFieldSet(Bitmap, 50))
                    {
                        //get the settlement currency code
                        fin_msg.m_StlCcyCode = msg_body.Substring(cur_idx, 3);

                        //skip to the next fld
                        cur_idx += 3;
                    }

                    //fld 51 cardholder billing currency code
                    if (IsFieldSet(Bitmap, 51))
                    {
                        //get the cardholder billing currency code
                        fin_msg.m_CHBCcyCode = msg_body.Substring(cur_idx, 3);
                        //skip to the next fld
                        cur_idx += 3;
                    }

                    //fld 54 additional amounts
                    if (IsFieldSet(Bitmap, 54))
                    {
                        //skip the length 
                        cur_idx += 3;
                        //parse the Net Available Balance 

                        fin_msg.AvailableBalance.AccountType = Int32.Parse(msg_body.Substring(cur_idx, 2));
                        cur_idx += 2;
                        fin_msg.AvailableBalance.AmountType = Int32.Parse(msg_body.Substring(cur_idx, 2));
                        cur_idx += 2;
                        fin_msg.AvailableBalance.CurrencyCode = msg_body.Substring(cur_idx, 3);
                        cur_idx += 3;
                        fin_msg.AvailableBalance.CreditDebit = Char.Parse(msg_body.Substring(cur_idx, 1));
                        cur_idx += 1;
                        fin_msg.AvailableBalance.Amount = Decimal.Parse(msg_body.Substring(cur_idx, 12));
                        cur_idx += 12;

                        //parse the Uncleared Funds

                        fin_msg.UnclearedFunds.AccountType = Int32.Parse(msg_body.Substring(cur_idx, 2));
                        cur_idx += 2;
                        fin_msg.UnclearedFunds.AmountType = Int32.Parse(msg_body.Substring(cur_idx, 2));
                        cur_idx += 2;
                        fin_msg.UnclearedFunds.CurrencyCode = msg_body.Substring(cur_idx, 3);
                        cur_idx += 3;
                        fin_msg.UnclearedFunds.CreditDebit = Char.Parse(msg_body.Substring(cur_idx, 1));
                        cur_idx += 1;
                        fin_msg.UnclearedFunds.Amount = Decimal.Parse(msg_body.Substring(cur_idx, 12));
                        cur_idx += 12;

                        //parse the Ledgerbalance

                        fin_msg.LedgerBalance.AccountType = Int32.Parse(msg_body.Substring(cur_idx, 2));
                        cur_idx += 2;
                        fin_msg.LedgerBalance.AmountType = Int32.Parse(msg_body.Substring(cur_idx, 2));
                        cur_idx += 2;
                        fin_msg.LedgerBalance.CurrencyCode = msg_body.Substring(cur_idx, 3);
                        cur_idx += 3;
                        fin_msg.LedgerBalance.CreditDebit = Char.Parse(msg_body.Substring(cur_idx, 1));
                        cur_idx += 1;
                        fin_msg.LedgerBalance.Amount = Decimal.Parse(msg_body.Substring(cur_idx, 12));

                    }
                    //fld 60 reserved private XXX YYYY YYYY YYYY YYYY

                    //flexcube does not set fld 60 so use current year
                    /*
                    if (IsFieldSet(Bitmap,60))
                    {
                        //just skip this field , length of fld 60
                        cur_idx+=3;
                        //local transation datetime
                        string strLocTranYear = msg_body.Substring(cur_idx,4);
                        fin_msg.m_LocDateTime = new DateTime(Int32.Parse(strLocTranYear),Int32.Parse(strLocTranDateTime.Substring(0,2)),Int32.Parse(strLocTranDateTime.Substring(2,2)),Int32.Parse(strLocTranDateTime.Substring(4,2)),Int32.Parse(strLocTranDateTime.Substring(6,2)),Int32.Parse(strLocTranDateTime.Substring(8,2)));
                        cur_idx+=4;
						
                        //settlement datetime
                        string strStlYear = msg_body.Substring(cur_idx,4);
                        fin_msg.m_StlDateTime = new DateTime(Int32.Parse(strStlYear),Int32.Parse(strStlDateTime.Substring(0,2)),Int32.Parse(strStlDateTime.Substring(2,2)),Int32.Parse(strStlDateTime.Substring(4,2)),Int32.Parse(strStlDateTime.Substring(6,2)),Int32.Parse(strStlDateTime.Substring(8,2)));
                        cur_idx+=4;
					
                        //capture datetime
                        string strCapYear = msg_body.Substring(cur_idx,4);
                        fin_msg.m_CapDateTime = new DateTime(Int32.Parse(strCapYear),Int32.Parse(strCapDateTime.Substring(0,2)),Int32.Parse(strCapDateTime.Substring(2,2)),Int32.Parse(strTrmDateTime.Substring(4,2)),Int32.Parse(strCapDateTime.Substring(6,2)),Int32.Parse(strCapDateTime.Substring(8,2)));
						
                        cur_idx+=4;

                        //transmission datetime
                        string strTrmYear = msg_body.Substring(cur_idx,4);
                        fin_msg.m_TrmDateTime = new DateTime(Int32.Parse(strTrmYear),Int32.Parse(strTrmDateTime.Substring(0,2)),Int32.Parse(strTrmDateTime.Substring(2,2)),Int32.Parse(strTrmDateTime.Substring(4,2)),Int32.Parse(strTrmDateTime.Substring(6,2)),Int32.Parse(strTrmDateTime.Substring(8,2)));
                        cur_idx+=4;
                    }
                    */

                    //local transation datetime
                    string strLocTranYear = DateTime.Now.Year.ToString();
                    fin_msg.m_LocDateTime = new DateTime(Int32.Parse(strLocTranYear), Int32.Parse(strLocTranDateTime.Substring(0, 2)), Int32.Parse(strLocTranDateTime.Substring(2, 2)), Int32.Parse(strLocTranDateTime.Substring(4, 2)), Int32.Parse(strLocTranDateTime.Substring(6, 2)), Int32.Parse(strLocTranDateTime.Substring(8, 2)));

                    //settlement datetime
                    string strStlYear = DateTime.Now.Year.ToString();
                    fin_msg.m_StlDateTime = new DateTime(Int32.Parse(strStlYear), Int32.Parse(strStlDateTime.Substring(0, 2)), Int32.Parse(strStlDateTime.Substring(2, 2)), Int32.Parse(strStlDateTime.Substring(4, 2)), Int32.Parse(strStlDateTime.Substring(6, 2)), Int32.Parse(strStlDateTime.Substring(8, 2)));

                    //capture datetime
                    string strCapYear = DateTime.Now.Year.ToString();
                    fin_msg.m_CapDateTime = new DateTime(Int32.Parse(strCapYear), Int32.Parse(strCapDateTime.Substring(0, 2)), Int32.Parse(strCapDateTime.Substring(2, 2)), Int32.Parse(strTrmDateTime.Substring(4, 2)), Int32.Parse(strCapDateTime.Substring(6, 2)), Int32.Parse(strCapDateTime.Substring(8, 2)));

                    //transmission datetime
                    string strTrmYear = DateTime.Now.Year.ToString();
                    fin_msg.m_TrmDateTime = new DateTime(Int32.Parse(strTrmYear), Int32.Parse(strTrmDateTime.Substring(0, 2)), Int32.Parse(strTrmDateTime.Substring(2, 2)), Int32.Parse(strTrmDateTime.Substring(4, 2)), Int32.Parse(strTrmDateTime.Substring(6, 2)), Int32.Parse(strTrmDateTime.Substring(8, 2)));

                    //fld 70 network management code
                    if (IsFieldSet(Bitmap, 70))
                    {


                    }

                    //if secondary bitmap is enabled
                    if (blnExtBitmap)
                    {
                        //fld 102 Debit account No
                        int ac_no_len = Int32.Parse(msg_body.Substring(cur_idx, 2));
                        //skip to next fld
                        cur_idx += 2;
                        //get the a/c no
                        fin_msg.m_SecAcNo = msg_body.Substring(cur_idx, ac_no_len);

                        //skip to next field

                        cur_idx += ac_no_len;

                        //fld 103 Credit account No

                        //get the ac no length
                        ac_no_len = Int32.Parse(msg_body.Substring(cur_idx, 2));

                        //skip to a/c no

                        //same as fld 2 just skip it
                        cur_idx += ac_no_len;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return fin_msg;
        }
        public byte[] GenBinBitmap(ref byte[] avb_flds)
        {
            //encodes the bitmap, extended bitmap is supported as well
            //check if secondary bitmap is enabled
            bool ext_bmp = false;
            if (avb_flds == null)
            {
                return null;
            }
            for (int i = 0; i < avb_flds.Length; i++)
            {
                if (avb_flds[i] > 64)
                {
                    ext_bmp = true;
                    break;
                }
            }
            byte[] bitmap = new byte[(ext_bmp ? 16 : 8)];
            int idx;
            for (int i = 0; i < avb_flds.Length; i++)
            {
                //int z = Math.Floor((double)x / (double)y);
                double z = Convert.ToDouble(avb_flds[i] / 8);
                //idx = (int) Math.Floor(avb_flds[i]/8);
                idx = (int)Math.Floor(z);
                if (avb_flds[i] % 8 == 0)
                {
                    idx = idx - 1;
                }

                bitmap[idx] |= (byte)Math.Pow(2, ((avb_flds[i] % 8 == 0) ? 0 : (8 - (avb_flds[i] % 8))));
            }
            return bitmap;
        }
        public string GetResponseDescription(int iso_code)
        {
            string iso_req_msg;
            switch (iso_code)
            {
                case 0: iso_req_msg = "Completed Successful"; break;
                case 1: iso_req_msg = "Refer Card Issuer"; break;
                case 2: iso_req_msg = "Refer Card Issuer Special Condition"; break;
                case 3: iso_req_msg = "Invalid Merchant"; break;
                case 4: iso_req_msg = "Pick up"; break;
                case 5: iso_req_msg = "Do not Honour"; break;
                case 6: iso_req_msg = "Error"; break;
                case 7: iso_req_msg = "Pick-up Special Condition"; break;
                case 8: iso_req_msg = "Honour with identification"; break;
                case 9: iso_req_msg = "Request in Progress"; break;
                case 10: iso_req_msg = "Approved for part number"; break;
                case 11: iso_req_msg = "Approved (VIP)"; break;

                case 13: iso_req_msg = "Invalid Amount"; break;
                case 14: iso_req_msg = "Invalid Card Number"; break;
                case 15: iso_req_msg = "No Such Issuer"; break;
                case 16: iso_req_msg = "Approved, Update track 3"; break;
                case 17: iso_req_msg = "Customer Cancellation"; break;
                case 18: iso_req_msg = "Customer Dispute"; break;
                case 19: iso_req_msg = "Reenter Transaction"; break;
                case 20: iso_req_msg = "Invalid Response"; break;
                case 21: iso_req_msg = "No Action Taken"; break;
                case 22: iso_req_msg = "Suspected Malfunction"; break;
                case 23: iso_req_msg = "Unacceptable Transaction Fee"; break;
                case 24: iso_req_msg = "File Update not supported"; break;
                case 25: iso_req_msg = "Unable to locate rec on file"; break;
                case 26: iso_req_msg = "Duplicate file record"; break;
                case 27: iso_req_msg = "File Update edit error"; break;
                case 28: iso_req_msg = "File Update File Locked Out"; break;
                case 29: iso_req_msg = "File Update Error"; break;
                case 30: iso_req_msg = "Invalid Format"; break;
                case 31: iso_req_msg = "Bank Not Supported"; break;
                case 32: iso_req_msg = "Completed Partially"; break;
                case 33: iso_req_msg = "Card Expired"; break;
                case 34: iso_req_msg = "Suspected Fraud (Pickup)"; break;
                case 35: iso_req_msg = "Card Acceptor Contact Acquirer (P)"; break;
                case 36: iso_req_msg = "Restricted Card (Pickup)"; break;
                case 37: iso_req_msg = "Card Acptr Contact Acquirer"; break;
                case 38: iso_req_msg = "PIN Retries Exceeded (Pickup)"; break;
                case 39: iso_req_msg = "No Credit Account"; break;
                case 40: iso_req_msg = "Invalid Function Requested"; break;
                case 41: iso_req_msg = "Lost Card"; break;
                case 42: iso_req_msg = "No Universal Account"; break;
                case 43: iso_req_msg = "Stolen Card"; break;
                case 44: iso_req_msg = "Invalid Investment Account"; break;
                /* not available in ISO*/


                case 51: iso_req_msg = "Not Sufficient Funds"; break;
                case 52: iso_req_msg = "No Chequeing Account"; break;
                case 53: iso_req_msg = "No Savings Account"; break;
                case 54: iso_req_msg = "Expired Card"; break;
                case 55: iso_req_msg = "Invalid PIN"; break;
                case 56: iso_req_msg = "No Card Record"; break;
                case 57: iso_req_msg = "Txn not permitted to Cardholder"; break;
                case 58: iso_req_msg = "Txn not permitted to Terminal"; break;
                case 59: iso_req_msg = "Suspected Fraud (Decline)"; break;
                case 60: iso_req_msg = "Card Accep. Contact Acq.(Decline)"; break;
                case 61: iso_req_msg = "Withdrawal Amt Exceeds Limit"; break;
                case 62: iso_req_msg = "Restricted Card(Decline)"; break;
                case 63: iso_req_msg = "Security Violation"; break;
                case 64: iso_req_msg = "Invalid Original Amount"; break;
                case 65: iso_req_msg = "Exceeds Withdrawal Freq Limit"; break;
                case 66: iso_req_msg = "Card Acptr Contacct Acquirer"; break;
                case 67: iso_req_msg = "Hard Capture"; break;
                case 68: iso_req_msg = "Response Arrived Too Late"; break;
                case 75: iso_req_msg = "PIN Retries Exceeded (Decline)"; break;
                case 90: iso_req_msg = "Cutoff in progress"; break;
                case 91: iso_req_msg = "Issuer Inoperative"; break;
                case 92: iso_req_msg = "Forwarder Inoperative"; break;
                case 93: iso_req_msg = "Txn cannot be completed"; break;
                case 94: iso_req_msg = "Duplicate Trasmission"; break;
                case 95: iso_req_msg = "Reconcilation Error"; break;
                case 96: iso_req_msg = "System Malfunction"; break;
                case 98: iso_req_msg = "Duplicate reversal send"; break;
                case 99: iso_req_msg = "Duplicate transaction send"; break;
                default: iso_req_msg = "Msg Not Set"; break;
            }
            return iso_req_msg;

        }

        /// <summary>
        /// checks if a field is set in a bitmap
        /// </summary>
        /// <param name="bmp_flds">contains the bitmap as an array of bytes</param>
        /// <param name="fld">fld to check</param>
        /// <returns></returns>
        public bool IsFieldSet(byte[] bmp_flds, byte fld)
        {
            if (bmp_flds == null)
            {
                return false;
            }
            //adjust to 0 index
            fld--;
            //get the fld index in the bitmap
            if (fld < 0 || fld > (bmp_flds.Length * 8) - 1)
            {
                return false;
            }
            int bmp_idx = (int)Math.Floor(Convert.ToDouble((fld / 8)));
            int bit_idx = 7 - (fld % 8);
            return (((bmp_flds[bmp_idx] & (byte)(Math.Pow(2, bit_idx))) >> (bit_idx)) == 1);
        }
        /// <summary>
        /// scans fields in an array an returns true if found else returns false
        /// </summary>
        /// <param name="bmp_flds"></param>
        /// <param name="fld"></param>
        /// <returns></returns>
        public bool IsFieldAvailable(byte[] arr_flds, byte fld)
        {
            for (int i = 0; i < arr_flds.Length; i++)
            {
                if (arr_flds[i] == fld)
                {
                    return true;
                }
            }
            return false;
        }
        private int GetResponseCode(string msg, string m_CAPTermld)
        {
            int cur_indx = msg.IndexOf(m_CAPTermld) - 2;
            return Int32.Parse(msg.Substring(cur_indx, 2));
        }

    }
}
