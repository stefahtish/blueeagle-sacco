using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using SACCOPortal.NavOData;

public class Member
    {
        public static string No { get; set; }
        public static string Name { get; set; }
        public static string PayrollstaffNo { get; set; }
        public static string Accountcategory { get; set; }
        public static string Idnumber { get; set; }
        public static string MobileNo { get; set; }
        public static string BankAccount { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
        public static string Share { get; set; }
        public static string Share_d { get; set; }
        public static string currentshare { get; set; }
        public static string currentshare_d { get; set; }
        public static string unallocatedfund { get; set; }
       public static string Benevolent { get; set; }
        public static string Dividend { get; set; }
        public static string Oustandandingbal { get; set; }
        public static string Oustandandingbal_d { get; set; }
        public static string FOSAbal { get; set; }
        public static string interest { get; set; }



    public NAV nav = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]))
        {
            Credentials =
                new NetworkCredential(ConfigurationManager.AppSettings["W_USER"],
                    ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"])
        };

        public Member(string user)
        {
            var objMembers = nav.MemberList.Where(r => r.No == user);
            foreach (var objMember in objMembers)
            {
                No = objMember.No;
                Name = objMember.Name;
                PayrollstaffNo = objMember.Payroll_Staff_No;
                Accountcategory = objMember.Account_Category;
                Idnumber = objMember.ID_No;
                MobileNo = objMember.Phone_No;
                BankAccount = objMember.Bank_Account_No;
                Email = objMember.E_Mail_Personal;
                Password = objMember.password;
                Share = ((-1)*Convert.ToDecimal(objMember.Shares_Retained)).ToString("N");
                Share_d = ((-1)*Convert.ToDecimal(objMember.Shares_Retained)).ToString();
                currentshare = ((-1)*Convert.ToDecimal(objMember.Current_Shares)).ToString("N");
                currentshare_d = ((-1)*Convert.ToDecimal(objMember.Current_Shares)).ToString();
                unallocatedfund = Convert.ToDecimal(objMember.Un_allocated_Funds).ToString("N");
              Benevolent = ((-1)*Convert.ToDecimal(objMember.Benevolent_Fund)).ToString("N");
                Dividend = Convert.ToDecimal(objMember.Dividend_Amount).ToString("N");
                Oustandandingbal = Convert.ToDecimal(objMember.Outstanding_Balance).ToString("N");
                Oustandandingbal_d = Convert.ToDecimal(objMember.Outstanding_Balance).ToString();
                interest = ((-1)*Convert.ToDecimal(objMember.Outstanding_Interest)).ToString("n");
               FOSAbal = ((-1)*Convert.ToDecimal(objMember.FOSA_Account_Bal)).ToString("N");

            }


        }
    public void CopyFile(string src, string dest)
    {
        try {

            if (System.IO.File.Exists(dest))
            {
                System.IO.File.Delete(dest);
            }
            System.IO.File.Move(src, dest);
        }catch(Exception )
        {

        }
    }
}
