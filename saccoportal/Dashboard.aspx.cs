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
    public partial class Dashboard : System.Web.UI.Page
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
            ReturnMember();
            LoadKinsData(nav);
            LoadBeneficiaryData(nav);
            LoadMinistatement();
        }

        protected Member ReturnMember()
        {

            return new Member(Session["username"].ToString());
        }

        protected void LoadKinsData(NAV navData)
        {
            var objKins = navData.KeensDetails.Where(r => r.Account_No == Session["username"].ToString() &&  r.Beneficiary == false).ToList();

            gvKins.DataSource = objKins;
            gvKins.AutoGenerateColumns = false;
            gvKins.DataBind();
        }

        protected void LoadBeneficiaryData(NAV navData)
        {
            var objBeneficiary = navData.KeensDetails.Where(r => r.Account_No == Session["username"].ToString() && r.Beneficiary==true).ToList();

            GvBeneficiary.DataSource = objBeneficiary;
            GvBeneficiary.AutoGenerateColumns = false;
            GvBeneficiary.DataBind();
        }

        protected void LoadMinistatement()
        {
            var finalList = new List<Statement>();
            foreach (var item in MiniStatement())
            {
                string[] ministmtArray = item.Split(new string[] { ":::" }, StringSplitOptions.None);
                finalList.Add(new Statement {Date = ministmtArray[0], Descrition = ministmtArray[1], Amount = ministmtArray[2]});
            }
           gvMinistatement.DataSource = finalList;
           gvMinistatement.AutoGenerateColumns = true;
           gvMinistatement.DataBind();
        }


        public List<string> MiniStatement()
        {
            var ministmtList = new List<string>();
            try
            {
                string ministmt = WSConfig.ObjNav.MiniStatement(Session["username"].ToString());
                string[] ministmtArray = ministmt.Split(new string[] { "::::" }, StringSplitOptions.RemoveEmptyEntries);
                ministmtList = ministmtArray.ToList();
                
            }
            catch (Exception e)
            {
                e.Data.Clear();
            }
            return ministmtList;
        }
    }

    class Statement
    {
        public string Date { get; set; }
        public string Descrition { get; set; }
        public string Amount { get; set; }
    }
}