using Bundesliga.DataAccess;
using Bundesliga.Web.Services;
using Microsoft.Practices.Unity;
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
        [Dependency]
        public IRankingService RankingService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            gvStandings.DataSource = RankingService.GetStandings().OrderByDescending(x => x.Points);
            gvStandings.DataBind();
        }
    }
}