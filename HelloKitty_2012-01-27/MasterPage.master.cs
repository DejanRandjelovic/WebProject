﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
        
    }
    
    protected void LoginStatus1_LoggingOut1(object sender, LoginCancelEventArgs e)
    {
        Session["Ulogovani"] ="";
    }
    protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
    {
        Session["Ulogovani"] = "";
    }
}
