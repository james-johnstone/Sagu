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
        public IEnumerable<Sagu.DTO.Explorer> GetExplorers()
        {
            using (var context = new SaguContext())
            {
                return context.Explorers.Include(e => e.ExploredAreas).ToList().Select(e => e.AsDTO());
            }
        }

        public Sagu.DTO.Explorer GetExplorer(Guid id)
        {
            using (var context = new SaguContext())
            {
                return context.Explorers.Find(id).Get(e => e.AsDTO());
            }
        }

        public Sagu.DTO.Explorer CreateExplorer(Sagu.DTO.Explorer explorer)
        {
            using (var context = new SaguContext())
            {
                var newExplorer = context.Explorers.Add(explorer.AsEntity());
                context.SaveChanges();

                return newExplorer.AsDTO();
            }
        }

        public void DeleteExplorer(Sagu.DTO.Explorer explorer)
        {
            using (var context = new SaguContext())
            {
                var explorerToRemove = context.Explorers.Find(explorer.Id);

                context.Explorers.Remove(explorerToRemove);
                context.SaveChanges();
            }
        }
    }
}
