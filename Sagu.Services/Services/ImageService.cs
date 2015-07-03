using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagu.DAL;
using Sagu.DTO;

namespace Sagu.Services
{
    public class ImageService
    {
        private static string ImagesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

        public Area SaveImage(Area area, string fileName, byte[] data)
        {
            var existingImage = GetImage(area.Id).Get(i => i.AsDTO());

            area.Image = existingImage ?? new AreaImage() { Id = area.Id };
            area.Image.FileName = fileName;

            File.WriteAllBytes(GetFilePath(area.Image), data);

            return area;
        }

        private Model.AreaImage GetImage(Guid id)
        {
            using (var context = new SaguContext())
            {
                return context.AreaImages.Find(id);
            }
        }

        private string GetFilePath(AreaImage image)
        {
            return Path.Combine(ImagesDirectory, image.Id.ToString() + "." + image.FileName.Split('.').Last());
        }
    }
}
