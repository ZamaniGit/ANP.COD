using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace ANP.Bussiness.Models.Reports
{
    public interface IControlForm
    {
        Boolean trState { get; set; }
        Boolean trCity { get; set; }
        Boolean trPostNodeName { get; set; }
        Boolean trLastState { get; set; }
        Boolean trLastCity { get; set; }
        Boolean trLastPostNode { get; set; }
        Boolean trUser { get; set; }
        Boolean trBarcodeStatus { get; set; }
        Boolean trFDate { get; set; }
        Boolean trTDate { get; set; }
        Boolean trReceiptNo { get; set; }
        Boolean trReceiptType { get; set; }
        Boolean trReceiptState { get; set; }
        Boolean trShowButton { get; set; }
        Boolean trReceiptSaveState { get; set; }
        Boolean trPayType { get; set; }
        Boolean trBarCode { get; set; }
        Boolean trCredit { get; set; }
        
        
        string Fdate { get; set; }
        string Ldate { get; set; }

        TextBox txtReceiptSeriNo { get; set; }
        TextBox txtReceiptNo { get; set; }
        TextBox txtBarCode { get; set; }

        DropDownList ddlReceiptSeriAlepha { get; set; }
        DropDownList ddlState { get; set; }
        DropDownList ddlCity { get; set; }
        DropDownList ddlPostNode { get; set; }
        DropDownList ddlLastState { get; set; }
        DropDownList ddlLastCity { get; set; }
        DropDownList ddlLastPostNode { get; set; }
        DropDownList ddlUser { get; set; }
        DropDownList ddlBarcodeStatus { get; set; }
        DropDownList ddlReceiptType { get; set; }
        DropDownList ddlReceiptState { get; set; }
        DropDownList ddlReceiptSaveState { get; set; }
        DropDownList ddlPayType { get; set; }
        DropDownList ddlCredit { get; set; }
        
        Label lblReceiptState { get; set; }
        Label lblReceiptType { get; set; }
        Label lblReceiptNo { get; set; }
        Label lblTdate { get; set; }
        Label lblFdate { get; set; }
        Label lblUser { get; set; }
        Label lblBarcodeStatus { get; set; }
        Label lblReceiptSaveState { get; set; }
        Label lblPostNode { get; set; }
        Label lblCity { get; set; }
        Label lblState { get; set; }
        Label lblLastPostNode { get; set; }
        Label lblLastCity { get; set; }
        Label lblLastState { get; set; }
        Label lblPayType { get; set; }
        Label lblBarCode { get; set; }
        Label lblCredit { get; set; }
        
        Button btnShow { get; set; }
    }
}