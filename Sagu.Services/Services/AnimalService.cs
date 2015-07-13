using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.DAL;

namespace Sagu.Services
{
    public class AnimalService
    {
        public IEnumerable<DTO.Animal> GetAnimals()
        {
            using (var context = new SaguContext())
            {
                return context.Animals.ToList().Select(a => a.AsDTO());
            }
        }

        public DTO.Animal GetAnimal(Guid id)
        {
            using (var context = new SaguContext())
            {
                return context.Animals.Find(id).Get(a => a.AsDTO());
            }
        }

        public DTO.Animal CreateAnimal(DTO.Animal animal)
        {
            using (var context = new SaguContext())
            {
                context.Animals.Add(animal.AsEntity());
                context.SaveChanges();

                return animal;
            }
        }

        public DTO.Animal UpdateAnimal(DTO.Animal animal)
        {
            using (var context = new SaguContext())
            {
                var animalToUpdate = context.Animals.Find(animal.Id);

                if (animalToUpdate == null)
                    throw new KeyNotFoundException();

                context.Entry(animalToUpdate).CurrentValues.SetValues(animal);
                context.SaveChanges();

                return animal;
            }
        }

        public void DeleteAnimal(Guid id)
        {
            using (var context = new SaguContext())
            {
                var animalToRemove = context.Animals.Find(id);

                if (animalToRemove == null)
                    throw new KeyNotFoundException();

                context.Animals.Remove(animalToRemove);
                context.SaveChanges();
            }
        }
    }
}
