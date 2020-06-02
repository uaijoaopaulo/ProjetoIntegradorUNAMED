using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoIntegrador.View
{
    public partial class _Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSobre.Attributes.Add("OnClick", "javascript:ChamaPaginaSobre()");
            lblAjuda.Attributes.Add("OnClick", "javascript:ChamaPaginaAjuda()");
        }
    }
}