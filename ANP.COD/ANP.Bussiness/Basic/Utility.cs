using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using ANP.Data;
using System.Web.UI.HtmlControls;

namespace ANP.Bussiness.Basic
{

    public static class Utility
    {
        public static void RunQuery(string Query)
        {
            DBConnector db = new DBConnector();
            db.SqlExecute(Query);
        }

        public static bool FillCombo(DataTable dt, ListControl combo, string ValueMember, string DisplayMember, bool addDefault)
        {
            try
            {
                combo.DataSource = dt;
                combo.DataTextField = DisplayMember;
                combo.DataValueField = ValueMember;
                combo.DataBind();
                if (addDefault) combo.Items.Insert(0, new ListItem("---", "0"));
            }
            catch { return false; }
            return true;
        }

        public static bool FillCombo(DataTable dt, ListControl combo, string ValueMember, string DisplayMember, string FirstItemName)
        {
            try
            {
                
                combo.DataSource = dt;
                combo.DataValueField = dt.Columns[0].ColumnName;
                combo.DataTextField = dt.Columns[1].ColumnName;
                combo.DataBind();
                combo.Items.Insert(0, new ListItem(FirstItemName, "0"));
            }
            catch { return false; }
            return true;
        }

        public static bool FillCombo2(DataTable dt, ListControl combo, string ValueMember, string DisplayMember, string FirstItemName)
        {
            try
            {
                combo.DataSource = dt;
                combo.DataTextField = DisplayMember;
                combo.DataValueField = ValueMember;
                combo.DataBind();
                combo.Items.Insert(0, new ListItem(FirstItemName, "-1"));
            }
            catch { return false; }
            return true;
        }

        public static bool FillCombo2(DataTable dt, ListControl combo, string ValueMember, string DisplayMember, bool addDefault)
        {
            try
            {
                combo.DataSource = dt;
                combo.DataTextField = DisplayMember;
                combo.DataValueField = ValueMember;
                combo.DataBind();
                if (addDefault) combo.Items.Insert(0, new ListItem("---", "-1"));
            }
            catch { return false; }
            return true;
        }

        public static bool FillCombo2Header(DataTable dt, ListControl combo, string ValueMember, string DisplayMember, string FirstItemName)
        {
            try
            {

                combo.DataSource = dt;
                combo.DataValueField = dt.Columns[0].ColumnName;
                combo.DataTextField = dt.Columns[1].ColumnName;
                combo.DataBind();
                combo.Items.Insert(0, new ListItem("بدون انتخاب", "-1"));
                combo.Items.Insert(1, new ListItem(FirstItemName, "0"));
            }
            catch { return false; }
            return true;
        }

        public static bool FillCombo(DataTable dt, HtmlSelect combo, string ValueMember, string DisplayMember, string FirstItemName, bool addDefault)
        {
            try
            {
                combo.DataSource = dt;
                combo.DataValueField = dt.Columns[0].ColumnName;
                combo.DataTextField = dt.Columns[1].ColumnName;
                combo.DataBind();
                combo.Items.Insert(0, new ListItem(FirstItemName, "0"));
            }
            catch { return false; }
            return true;
        }
    }
}
