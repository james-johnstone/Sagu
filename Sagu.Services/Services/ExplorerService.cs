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
        public IEnumerable<DTO.Explorer> GetExplorers()
        {
            using (var context = new SaguContext())
            {
                return context.Explorers.Include(e => e.ExploredAreas).Include(e => e.ExploredAreas.Select(a => a.Area)).ToList().Select(e => e.AsDTO());
            }
        }

        public DTO.Explorer GetExplorer(Guid id)
        {
            using (var context = new SaguContext())
            {
                return context.Explorers.Include(e => e.ExploredAreas).Include(e => e.ExploredAreas.Select(a => a.Area)).Include(e => e.ExploredAreas.Select(a => a.Area.Image)).FirstOrDefault(e => e.Id == id).Get(e => e.AsDTO());
                //return context.Explorers.Find(id).Get(e => e.AsDTO());
            }
        }

        public DTO.Explorer CreateExplorer(DTO.Explorer explorer)
        {
            explorer.Id = Guid.NewGuid();
            explorer.Level = 1;

            using (var context = new SaguContext())
            {
                var newExplorer = context.Explorers.Add(explorer.AsEntity());
                context.SaveChanges();

                return newExplorer.AsDTO();
            }
        }

        public DTO.Explorer UpdateExplorer(DTO.Explorer explorer)
        {
            using (var context = new SaguContext())
            {
                var explorerToUpdate = context.Explorers.Find(explorer.Id);

                if (explorerToUpdate == null)
                    throw new KeyNotFoundException();

                context.Entry(explorerToUpdate).CurrentValues.SetValues(explorer);
                context.SaveChanges();

                return explorer;
            }
        }

        public void DeleteExplorer(Guid id)
        {
            using (var context = new SaguContext())
            {
                var explorerToRemove = context.Explorers.Find(id);

                if (explorerToRemove == null)
                    throw new KeyNotFoundException();

                context.Explorers.Remove(explorerToRemove);
                context.SaveChanges();
            }
        }
    }
}
