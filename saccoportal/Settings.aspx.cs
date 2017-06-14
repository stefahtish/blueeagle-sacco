using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SACCOPortal
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Default");

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPasswordOld.Text.Trim()) && String.IsNullOrEmpty(txtPasswordNew.Text.Trim()) &&
                String.IsNullOrEmpty(txtPasswordConfirm.Text))
            {
                SACCOFactory.ShowAlert("You must fill-in all the fields to continue");
                return;
            }
            if (String.IsNullOrEmpty(txtPasswordNew.Text.Trim()) !=String.IsNullOrEmpty(txtPasswordConfirm.Text))
            {
                SACCOFactory.ShowAlert("New password is not equal to the confirm password field");
                return;
            }
            try
            {
                if (WSConfig.ObjNav.FnChangePassword(Session["username"].ToString(), txtPasswordOld.Text.Trim(),
                    txtPasswordConfirm.Text.Trim()))
                {
                    SACCOFactory.ShowAlert("Password was succesfully changed");
                }
                else
                {
                    SACCOFactory.ShowAlert("Your password cannot be changed at the moment. Kindly contact your Sacco Helpdesk");
                }
            }
            catch (Exception exception)
            {
                SACCOFactory.ShowAlert(exception.Message);
            }

            
        }
    }
}