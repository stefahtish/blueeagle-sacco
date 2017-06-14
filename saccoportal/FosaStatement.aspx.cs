using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACCOPortal.NavOData;

namespace SACCOPortal
{
    public partial class FosaStatement : System.Web.UI.Page
    {
        public NAV nav = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]))
        {
            Credentials =
             new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"],
                 ConfigurationManager.AppSettings["DOMAIN"])
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Default");
            }

            if (!IsPostBack)
            {
                LoadFosaAccounts(nav);
            }

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Session["account"] = ddFosaAccount.SelectedValue;
            Response.Redirect("Reports?r=fs");
        }

        protected void LoadFosaAccounts(NAV navData)
        {
            var objFosaAccount =
            navData.FosaAccounts.Where(r => r.BOSA_Account_No == Session["username"].ToString()).ToList();
            ddFosaAccount.DataSource = objFosaAccount;
            ddFosaAccount.DataTextField = "No";
            ddFosaAccount.DataValueField = "No";
            ddFosaAccount.DataBind();
        }
    }
}