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
        private RankingService _rankingService = new RankingService(new BundesligaContext());

        protected void Page_Load(object sender, EventArgs e)
        {
            gvStandings.DataSource = _rankingService.GetStandings().OrderByDescending(x => x.Points);
            gvStandings.DataBind();
        }
    }
}