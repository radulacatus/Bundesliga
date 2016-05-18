using Bundesliga.DataAccess;
using Bundesliga.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bundesliga.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var rankingService = Global.Resolve<IRankingService>();
            gvStandings.DataSource = rankingService.GetStandings().OrderByDescending(x => x.Points);
            gvStandings.DataBind();
        }
    }
}