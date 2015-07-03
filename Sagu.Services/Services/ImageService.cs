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
            if (area.Image != null)
            {
                area.Image.FileName = fileName;
            }
            else
            {
                area.Image = new AreaImage() { Id = area.Id, FileName = fileName };
            }

            File.WriteAllBytes(GetFilePath(area.Image), data);

            return area;
        }

        private string GetFilePath(AreaImage image)
        {
            return Path.Combine(ImagesDirectory, image.Id.ToString() + "." + image.FileName.Split('.').Last());
        }
    }
}
