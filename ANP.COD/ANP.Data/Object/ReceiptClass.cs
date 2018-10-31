using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANP.Data.Object
{
    public class ReceiptClass
    {
        public int ID { get; set; }
        public string ReceiptSerialNo { get; set; }
        public string ReceiptNumberSeri { get; set; }
        public string ReceiptAlphabetSeri { get; set; }
        public int BankID { get; set; }
        public UInt64 Price { get; set; }
        public string PayDate { get; set; }
        public DateTime InsertDate_M { get; set; }
        public string InsertDate_SH { get; set; }
        public string InsertTime { get; set; }
        public string ApproveFlag { get; set; }
        public string ApproveDate { get; set; }
        public string PayerName { get; set; }
        public int UserID { get; set; }
        public int PostNodeCode { get; set; }
        public string Deleted { get; set; }
        public string IsSupplementReceipt { get; set; }
        public UInt64 ParentID { get; set; }
        public string Description { get; set; }
        public Int64 MasterReceiptID { get; set; }
        public UInt64 ReceiptTypeValue { get; set; }
        public int UpdateCount { get; set; }
        public Int64 RefID { get; set; }
        public short FinancialMoodValue { get; set; }
        public string LogFlag { get; set; }
        public string IsPhish { get; set; }
        public string ChequeVajh { get; set; }
        public string ChequeSaderKonandeh {get; set;}
        public string ChequeAccountNo {get; set;}
        public string ChequeComment { get; set; }
    }
}
