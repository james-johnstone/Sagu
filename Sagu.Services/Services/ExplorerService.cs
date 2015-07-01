using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.DAL;
using Sagu.Model;
using System.Data.Entity;

namespace Sagu.Services
{
    public class ExplorerService
    {
        public IEnumerable<Explorer> GetExplorers()
        {
            using (var context = new SaguContext())
            {
                return context.Explorers.Include(e => e.ExploredAreas).ToList();
            }
        }

        public Explorer GetExplorer(Guid id)
        {
            using (var context = new SaguContext())
            {
                return context.Explorers.Find(id);
            }
        }

        public Explorer CreateExplorer(Explorer explorer)
        {
            using (var context = new SaguContext())
            {
                var newExplorer = context.Explorers.Add(explorer);
                context.SaveChanges();

                return newExplorer;
            }
        }

        public void DeleteExplorer(Explorer explorer)
        {
            using (var context = new SaguContext())
            {
                context.Explorers.Remove(explorer);
                context.SaveChanges();
            }
        }
    }
}
