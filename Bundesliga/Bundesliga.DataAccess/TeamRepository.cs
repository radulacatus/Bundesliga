using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bundesliga.DataAccess
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly BundesligaContext _bundesligaContext;

        private readonly System.Data.Entity.DbSet<Team> _set;

        public TeamRepository(BundesligaContext bundesligaContext)
        {
            _bundesligaContext = bundesligaContext;
            _set = bundesligaContext.Teams;
        }

        public Team Get(int id)
        {
            return _set.Single(x => x.Id == id);
        }

        public IEnumerable<Team> All()
        {
            return _set.ToList();
        }

        public int Save(Team entity)
        {
            var savedEntity = _set.Add(entity);
            _bundesligaContext.SaveChanges();
            return savedEntity.Id;
        }

        public void Delete(Team entity)
        {
            _set.Remove(entity);
            _bundesligaContext.SaveChanges();
        }
    }
}
