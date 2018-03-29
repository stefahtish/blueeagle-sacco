using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACCOPortal.NavOData;
using SACCOPortal.NAVWS;
using Microsoft.VisualBasic;
using SACCOPortal;

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
            if (!IsPostBack)
            {
             
                NAV nav = new Config().ReturnNav();
               
            }
        }
        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();
        //    ctrlGoogleReCaptcha.PublicKey = "6LdK7j4UAAAAAJaWiKryMXWxVcwuDAyjEb_Kr204";
        //    ctrlGoogleReCaptcha.PrivateKey = "6LdK7j4UAAAAAC1ovoMUpMxXODnYYsWaebjMbbf0";
        //}

        
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            cptCaptcha.ValidateCaptcha(txtCaptcha.Text.Trim());
            if (cptCaptcha.UserValidated)
            {
                string userName = txtStaffNo.Text.Trim().Replace("'", "");
                string userPassword = txtPassword.Text.Trim().Replace("'", "");

                if (string.IsNullOrEmpty(userPassword) && string.IsNullOrEmpty(userName))
                {
                    lblError.Text = "Username or Password Empty!";
                    return;
                }
                try
                {
                    var passDt = nav.MemberList.ToList().Where(r => r.No == userName);
                    var pdT = passDt.Select(r => r.Password_Set_Date).SingleOrDefault();

                    var iD = passDt.Select(id => id.ID_No).FirstOrDefault();
                    var passID = passDt.Select(idP => idP.Password).FirstOrDefault();
                    //var userIDNo =passDt.Select(nuu=>nuu.)				

                    DateTime Pexpires = Convert.ToDateTime(pdT);
                    var expDay = DateTime.Today;

                    int daysT = (expDay - Pexpires).Days;

                    if (nav.MemberList.Where(r => r.No == userName && r.Password == userPassword).FirstOrDefault() != null)
                    {
                        if (daysT > 30 || pdT == null)
                        {
                            SACCOFactory.ShowAlert("Sorry, your password expired, reset first");
                          //  btnp.Visible = false;
                            btnLogin.Visible = false;
                            MultiView1.SetActiveView(View2);
                            txtEmployeeNo.Text = userName;
                            txtEmployeeNo.Enabled = false;
                            btnSubmit.Visible = true;
                            btnBack.Visible = true;
                            lblError.Text = "";
                        }
                        else
                        {

                            Session["username"] = userName;
                            Session["pwd"] = userPassword;
                            Response.Redirect("Dashboard");
                        }
                    }
                    else if (nav.MemberList.Where(r => r.ID_No == userName && r.Password == userPassword).FirstOrDefault() != null)
                    {
                        var objMembers = nav.MemberList.Where(r => r.ID_No == userName);
                        foreach (var objMember in objMembers)
                        {
                            Session["username"] = objMember.No;
                        }
                        Session["pwd"] = userPassword;
                        Response.Redirect("Dashboard");
                    }

                    else if (nav.MemberList.Where(r => r.ID_No == userName && iD == userPassword && r.PasswordSameID == true).FirstOrDefault() != null)
                    {
                        userName = nav.MemberList.Where(r => r.ID_No == userName).ToList().Select(r => r.No).SingleOrDefault();
                        Session["username"] = userName;
                        Session["pwd"] = userPassword;
                        Response.Redirect("Dashboard");
                    }

                    else if (userPassword != nav.MemberList.Select(r => r.Password).ToString())
                    {
                        lblError.Text = "Authentication failed!";
                        return;
                    }
                }
                catch (Exception exception)
                {
                    lblError.Text = exception.Message;
                    return;
                }
            }
            else
            {
                lblError.Text = "Invalid Captcha!..Try again!";
            }

        }

        protected void btnPassword_Click(object sender, EventArgs e)
        {
            //btnSignup.Visible = false;
            btnLogin.Visible = false;
            MultiView1.SetActiveView(View2);
           
            btnSubmit.Visible = true;
            btnBack.Visible = true;
            lblError.Text = "";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = false;
            btnBack.Visible = false;
           
            MultiView1.SetActiveView(View1);
            //btnSignup.Visible = true;
            btnLogin.Visible = true;
            lblError.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userName = txtEmployeeNo.Text.Trim().Replace("'", "");
            string userPassword = idNo.Text.Trim().Replace("'", "");

            var idcheck = nav.MemberList.Where(r => r.No == userName).Select(k => k.ID_No).FirstOrDefault();
            var emalcheck = nav.MemberList.Where(r => r.No == userName).Select(k => k.E_Mail).FirstOrDefault();
            var phonecheck = nav.MemberList.Where(r => r.No == userName).Select(k => k.Phone_No).FirstOrDefault();
            if (string.IsNullOrEmpty(userPassword) && string.IsNullOrEmpty(userName))
            {
                lblError.Text = "Member No or National ID Empty!";
                btnSubmit.Visible = true;
                btnBack.Visible = true;
                //btnSignup.Visible = false;
                btnLogin.Visible = false;
                MultiView1.SetActiveView(View2);
                return;
            
            }
            else
            {
                try
                {
                    var nPassword = NewPassword();
                    var CompEmail = WSConfig.ObjNav.FnUpdatePassword(txtEmployeeNo.Text.Trim(), idNo.Text.Trim(), nPassword);
                    if (WSConfig.MailFunction(string.Format("Dear Sacco Member,\n Your New password is: {0}", nPassword), CompEmail,
                        "Portal password reset successful") && !String.IsNullOrEmpty(CompEmail))
                    {
                        SACCOFactory.ShowAlert(
                            "A New Password has been generated and sent to your Personal mail.Kindly use to it to login to your Member portal");
                        btnSubmit.Visible = true;
                        btnBack.Visible = true;
                        //btnSignup.Visible = false;
                        btnLogin.Visible = false;
                        MultiView1.SetActiveView(View2);
                        lblError.Text = "New Password generated!";
                    }
                    else if (idcheck != userPassword)
                    {
                        SACCOFactory.ShowAlert(
                           "Your Password could not be reset. Member number does not match your ID number!");
                        btnSubmit.Visible = true;
                        btnBack.Visible = true;
                        btnLogin.Visible = false;
                        MultiView1.SetActiveView(View2);
                    }
                    else if (string.IsNullOrEmpty(emalcheck) && phonecheck!=null)
                    {
                        SACCOFactory.ShowAlert(
                          "Your Password was send to your Phone Number");
                        btnSubmit.Visible = false;
                        txtEmployeeNo.Enabled = false;
                        idNo.Enabled = false;
                        btnBack.Visible = false;
                        MultiView1.SetActiveView(View1);
                        btnLogin.Visible = true;
                        lblError.Text = "Your Password was send to your Phone Number";
                    }

                }
                catch (Exception exception)
                {
                    SACCOFactory.ShowAlert(exception.Message);
                }
            }
            btnSubmit.Visible = true;
            btnBack.Visible = true;
            //btnSignup.Visible = false;
            btnLogin.Visible = false;
            MultiView1.SetActiveView(View2);

        }


        protected string NewPassword()
        {
            var nPwd = "";
            var rdmNumber = new Random();
            nPwd = rdmNumber.Next(1000, 1999).ToString();
            return nPwd;
        }


        protected void btnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MemberRegistration.aspx");
        }
       

        

       
        
       
    }
}