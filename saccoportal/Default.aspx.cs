using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACCOPortal.NavOData;
using System.Configuration;
using System.Net;

namespace SACCOPortal
{
    public partial class _Default : Page
    {
        public NAV nav = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]))
        {
            Credentials =
               new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"],
                   ConfigurationManager.AppSettings["DOMAIN"])
        };
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
            btnBack.Visible = false;
            btnSubmit.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string userName = txtStaffNo.Text.Trim().Replace("'", "");
            string userPassword = txtPassword.Text.Trim().Replace("'", "");

            if (string.IsNullOrEmpty(userPassword) && string.IsNullOrEmpty(userName))
            {
                lblError.Text = "Username or Password cannot be null!";
                return;
            }
            try
            {
                var list = nav.MemberList.ToList();
                if (nav.MemberList.Where(r =>r.No== userName&& r.password == userPassword).FirstOrDefault() != null)
                {
                    Session["username"] = userName;
                    Session["pwd"] = userPassword;
                    Response.Redirect("Dashboard");
                }
                else if (nav.MemberList.Where(r => r.Old_Account_No == userName  && r.password == userPassword).FirstOrDefault() != null)
                {
                   
                    var objMembers = nav.MemberList.Where(r => r.Old_Account_No == userName);
                    foreach (var objMember in objMembers)
                    {
                        Session["username"] = objMember.No;
                    }
                        
                    Session["pwd"] = userPassword;
                    Response.Redirect("Dashboard");
                }
                else
                {
                    lblError.Text = "Authenication failed!";
                    return;
                }
            }
            catch (Exception exception)
            {
                lblError.Text = exception.Message;
                return;
            }

        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            btnPassword.Visible = false;
            MultiView1.SetActiveView(View2);
            btnLogin.Visible = false;
            btnSubmit.Visible = true;
            btnBack.Visible = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = false;
            btnBack.Visible = false;
            btnPassword.Visible = true;
            btnLogin.Visible = true;

            MultiView1.SetActiveView(View1);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var nPassword = NewPassword();
                var CompEmail = WSConfig.ObjNav.FnUpdatePassword(txtEmployeeNo.Text.Trim(),idNo.Text.Trim(),  nPassword);
                if (WSConfig.MailFunction(string.Format("DEAR MEMBER,\n YOUR NEW PASSWORD IS {0}", nPassword), CompEmail,
                    "PORTAL PASSWORD RESET") && !String.IsNullOrEmpty(CompEmail))
                {
                    SACCOFactory.ShowAlert(
                        "A New Password has been generated and sent to your Personal mail.Kindly use to it to login to your Member portal");
                }
                else
                {
                    SACCOFactory.ShowAlert(
                       "An error occurred while sending you a new password. Kindly consult ICT for more details.");
                }

            }
            catch (Exception exception)
            {
                SACCOFactory.ShowAlert(exception.Message);
            }
            btnSubmit.Visible = false;
            btnBack.Visible = false;
            btnPassword.Visible = true;
            btnLogin.Visible = true;
            MultiView1.SetActiveView(View1);

        }


        protected string NewPassword()
        {
            var nPwd = "";
            var rdmNumber = new Random();
            nPwd = rdmNumber.Next(1000, 1999).ToString();
            return nPwd;
        }
    }
}