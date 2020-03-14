using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataTools
{
    public static class FormExtensions
    {
        public static T Get<T>(this PlaceHolder holder, string controlname)
            where T : class
        {
            return holder.FindControl(controlname) as T;
        }

        public static void ClearControls(this Control Parent)
        {
            if (Parent is TextBox)
                (Parent as TextBox).Text = string.Empty;
            else if (Parent is CheckBox)
                (Parent as CheckBox).Checked = false;
            else if (Parent is DropDownList)
                (Parent as DropDownList).SelectedValue = "-1";
            else if (Parent is RadioButtonList)
                (Parent as RadioButtonList).SelectedValue = "-1";
            else
            {
                foreach (Control c in Parent.Controls)
                    ClearControls(c);
            }
        }
        public static string RenderControlToHtml(Control ControlToRender)
        {
            StringBuilder sb = new StringBuilder();
            System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stWriter);
            ControlToRender.RenderControl(htmlWriter);
            return sb.ToString();
        }
    }
}
