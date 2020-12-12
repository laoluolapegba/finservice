using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Sockets;
using System.Diagnostics;

namespace FinSvc
{
    public class FinConMessenger
    {
        private int m_ServerPort;
        private string m_ServerIp;
        public string ServerIp
        {
            get
            {
                return m_ServerIp;
            }
            set
            {
                m_ServerIp = value;
            }
        }

        public int ServerPort
        {
            get
            {
                return m_ServerPort;
            }
            set
            {
                m_ServerPort = value;
            }
        }

        public FinConMessage FinConMsg;
        public FinConMessenger()
        {
            FinConMsg = new FinConMessage();
        }
        public FinConMessenger(string server_ip, int port)
        {
            m_ServerIp = server_ip;
            m_ServerPort = port;
            FinConMsg = new FinConMessage();
        }
        public void SendEchoTest()
        {
            try
            {
                //mandatory fields 1,7,11,70
                FinConMsg.NetworkManagementCode = 310;
                FinConMsg.MessageType = MESSAGE_TYPE.NetworkEcho;
                FinConMsg.TransmissionDateTime = DateTime.Now;
                byte[] avb_flds = new byte[] { 1, 7, 11, 70 };
                FinConMsg.DecodeFromISO(FinConMsg.EncodeToISO(avb_flds));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendBalanceInquiry()
        {
            try
            {
                byte[] avb_flds = new byte[] { 2, 3, 4, 7, 11, 12, 13, 15, 17, 32, 37, 41, 42, 49, 50, 51, 60 };
                FinConMsg.MessageType = MESSAGE_TYPE.Normal;
                FinConMsg.ProcessCode = PROCESS_CODE.BalanceInquiryCA;
                FinConMsg = FinConMsg.DecodeFromISO(SendISOMessage(FinConMsg.EncodeToISO(avb_flds)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendBalanceInquiryRev()
        {
            try
            {
                byte[] avb_flds = new byte[] { 2, 3, 4, 7, 11, 12, 13, 15, 17, 32, 37, 41, 42, 49, 50, 51, 60, 90, 95 };
                FinConMsg.MessageType = MESSAGE_TYPE.Reversal;
                FinConMsg.DecodeFromISO(SendISOMessage(FinConMsg.EncodeToISO(avb_flds)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendFundsTransfer()
        {
            try
            {
                byte[] avb_flds = new byte[] { 1, 2, 3, 4, 7, 11, 12, 13, 15, 17, 18, 32, 37, 41, 42, 43, 49, 50, 51, 60, 102, 103 };
                //  2,3,4,7,11,12,13,15,17,18,32,37,41,42,43,49,50,51,60

                FinConMsg.MessageType = MESSAGE_TYPE.Normal;
                FinConMsg.ProcessCode = PROCESS_CODE.FundTransferCA;
                FinConMsg = FinConMsg.DecodeFromISO(SendISOMessage(FinConMsg.EncodeToISO(avb_flds)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendCashWithdrawal()
        {
            try
            {
                byte[] avb_flds = new byte[] { 2, 3, 4, 7, 11, 12, 13, 15, 17, 18, 32, 37, 41, 42, 43, 49, 50, 51, 60 };
                FinConMsg.MessageType = MESSAGE_TYPE.Normal;
                FinConMsg.ProcessCode = PROCESS_CODE.CashWithdrawalCA;
                FinConMsg = FinConMsg.DecodeFromISO(SendISOMessage(FinConMsg.EncodeToISO(avb_flds)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SendNormalPurchase()
        {
            try
            {
                byte[] avb_flds = new byte[] { 2, 3, 4, 7, 11, 12, 13, 15, 17, 32, 37, 41, 42, 49, 50, 51, 60 };
                FinConMsg.MessageType = MESSAGE_TYPE.Normal;
                FinConMsg.ProcessCode = PROCESS_CODE.NormalPurchaseCA;
                FinConMsg.EncodeToISO(avb_flds);
                FinConMsg.DecodeFromISO(SendISOMessage(FinConMsg.EncodeToISO(avb_flds)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private byte[] SendISOMessage(byte[] iso_request)
        {
            byte[] iso_response = new byte[256];
            TcpClient client = null;
            try
            {
                client = new TcpClient(m_ServerIp, m_ServerPort);
                NetworkStream stream = client.GetStream();
                if (stream.CanWrite)
                {
                    stream.Write(iso_request, 0, iso_request.Length);
                }
                if (stream.CanRead)
                {
                    int nReadbytes = stream.Read(iso_response, 0, (int)iso_response.Length);
                    stream.Close();
                }
            }
            catch (Exception exp)
            {
                //EventLog finev = new EventLog();
                //finev.WriteEntry(exp.Message + exp.InnerException, EventLogEntryType.Error);
                throw (exp);
            }
            finally
            {
                client.Close();
            }
            return iso_response;
        }


    }
}