using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.ExercisePages
{
    public partial class FormC : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageList.DataSource = null;
            MessageList.DataBind();

        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            MessageList.CssClass = cssclass;
            MessageList.DataSource = errormsglist;
            MessageList.DataBind();
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            if (School.SelectedIndex == 0)
            {
                errormsgs.Add("Select a school to search.");
                LoadMessageDisplay(errormsgs, "alert alert-warning");
            }
        }
        }
}