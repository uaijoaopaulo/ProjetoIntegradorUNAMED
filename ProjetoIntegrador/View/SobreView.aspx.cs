﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoIntegrador.View
{
    public partial class SobreView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bttVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/EmailView.aspx");
        }
    }
}