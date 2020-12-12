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

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFinConnect
    {
        [FaultContract(typeof(DatabaseFault))]
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite); 

        // TODO: Add your service operations here


        [OperationContract]
        int BalanceEnquiry(TransactionParams param,string cod_acct_no);

        [OperationContract]
        int FundTransfer(TransactionParams param, string cod_acct_no_pri, string src_cod_acct_no, string dest_cod_acct_no, decimal amt_txn);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class TransactionParams
    {
        string _acq_inst_id; string _ca_term_id; string _ca_id_cod; string _trn_cur_cod; string _stl_cur_cod; string _chd_bil_cur_cod;
        [DataMember]
        public string acq_inst_id
        {
            get { return _acq_inst_id; }
            set { _acq_inst_id = value; }
        }
        [DataMember]
        public string ca_term_id
        {
            get { return _ca_term_id; }
            set { _ca_term_id = value; }
        }


        [DataMember]
        public string ca_id_cod
        {
            get { return _ca_id_cod; }
            set { _ca_id_cod = value; }
        }

        [DataMember]
        public string trn_cur_cod
        {
            get { return _trn_cur_cod; }
            set { _trn_cur_cod = value; }
        }

        [DataMember]
        public string stl_cur_cod
        {
            get { return _stl_cur_cod; }
            set { _stl_cur_cod = value; }
        }

        [DataMember]
        public string chd_bil_cur_cod
        {
            get { return _chd_bil_cur_cod; }
            set { _chd_bil_cur_cod = value; }
        }
    }

    [DataContract]
    public class DatabaseFault
    {
        [DataMember]
        public string DbOperation;
        [DataMember]
        public string DbReason;
        [DataMember]
        public string DbMessage;
    }
}
