using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bundesliga.DataAccess
{
    public class GameRepository : IRepository<Game>
    {
        private readonly BundesligaContext _bundesligaContext;

        private readonly System.Data.Entity.DbSet<Game> _set;

        public GameRepository(BundesligaContext bundesligaContext)
        {
            _bundesligaContext = bundesligaContext;
            _set = bundesligaContext.Games;
        }

        public Game Get(int id)
        {
            return _set.Single(x => x.Id == id);
        }

        public IEnumerable<Game> All()
        {
            return _set.ToList();
        }

        public int Save(Game entity)
        {
            var savedEntity = _set.Add(entity);
            _bundesligaContext.SaveChanges();
            return savedEntity.Id;
        }

        public void Delete(Game entity)
        {
            _set.Remove(entity);
            _bundesligaContext.SaveChanges();
        }
    }
}
