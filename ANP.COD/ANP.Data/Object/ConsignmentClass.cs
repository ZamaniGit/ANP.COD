using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANP.Data.Object
{
    public class ConsignmentClass
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int VatTax { get; set; }
        public int PostNode { get; set; }
        public int InsurCost { get; set; }
        public int ReceiptID { get; set; }
        public short StatusID { get; set; }
        public int PostalCost { get; set; }
        public int CustomerCost { get; set; }
        public int PriceEdit_Count { get; set; }
        public int PriceEdit_UserId { get; set; }

        public DateTime GenerateBarcodeDate { get; set; }
        public DateTime PriceEdit_Date { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EntryDate { get; set; }

        public string FirstPostNode { get; set; }
        public string BarcodeType { get; set; }
        public string LastCity { get; set; }
        public string Barcode { get; set; }
    }
}