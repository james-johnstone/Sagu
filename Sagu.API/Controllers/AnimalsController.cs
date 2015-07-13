using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sagu.DTO;
using Sagu.Services;

namespace Sagu.API
{
    public class AnimalsController : ApiController
    {
        AnimalService AnimalService = new AnimalService();

        public IHttpActionResult Get()
        {
            var animals = AnimalService.GetAnimals();

            return Ok(animals);
        }

        public IHttpActionResult Get(Guid id)
        {
            var animal = AnimalService.GetAnimal(id);

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        public IHttpActionResult Post(Animal animal)
        {
            if (animal == null)
                return BadRequest();

            try
            {
                var newAnimal = AnimalService.CreateAnimal(animal);

                return Created(string.Format("{0}/{1}", Request.RequestUri, newAnimal.Id), newAnimal);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Put([FromBody] Animal animal)
        {
            if (animal == null)
                return BadRequest();

            try
            {
                var updatedAnimal = AnimalService.UpdateAnimal(animal);

                return Ok(updatedAnimal);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                AnimalService.DeleteAnimal(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}
