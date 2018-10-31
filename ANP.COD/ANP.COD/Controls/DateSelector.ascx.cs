using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ANP.Bussiness;
using ANP.Common;

namespace ANP.COD.Controls {
    public interface IZamaniDate
    {
        string SelectedPersianDate { get; set; }
        string SelectedDate { get; set; }
    }
	public partial class DateSelector : System.Web.UI.UserControl,IZamaniDate {


		protected void Page_Load(object sender, EventArgs e) {
			faDate.Attributes.Add("onclick", "displayDatePicker('" + faDate.UniqueID + "');");
            this.faDate.Value =  DateAndTime.GetDate10Digit();
		}

		public string SelectedDate {
			get {
				return (faDate.Value.Length != 10 || faDate.Value.Trim() == string.Empty) ? "0" : faDate.Value;
			}
			set {
				if (value.Length == 10) {
					faDate.Value = value;
				}

			}
		}


		public string Text {
			get {
				return lt.Text;
			}
			set {
				lt.Text = value;
			}
		}

        
        public string Width {
			set {
                faDate.Style.Add(HtmlTextWriterStyle.Width, value);
			}
		}


		public bool ShowLabel {
			get {
				return tdlabel.Visible;
			}
			set {
				tdlabel.Visible = value;
			}
		}


		public int LabelWidthPercent {
			set {
				if (value > 100 || value <= 0)
					throw new Exception("Percent, as name suggest, must be between 1 to 100.");
				tdlabel.Attributes.Add("width", value+"%");
			}
		}


		public string SelectedPersianDate {
			get {
				return SelectedDate;
			}
			set {
				SelectedDate = value;
			}
		}
	}
}