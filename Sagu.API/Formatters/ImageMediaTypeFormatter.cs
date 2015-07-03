using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Sagu.Model;
using Sagu.Services;

namespace Sagu.API
{
    public class ImageSetMediaTypeFormatter : MediaTypeFormatter
    {
        public ImageSetMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(DTO.Area);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public async override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var formParts = await content.ReadAsMultipartAsync();

            var jsonFormData = formParts.Contents.FirstOrDefault(p => GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Any(m => 
                        m.MediaType == p.Headers.ContentType.MediaType));

            if (jsonFormData == null)
                throw new InvalidDataException();
            
            var areaJson = await jsonFormData.ReadAsStringAsync();
            var area = JsonConvert.DeserializeObject<DTO.Area>(areaJson);

            var imageFormData = formParts.Contents.FirstOrDefault(p => p.Headers.ContentDisposition.FileName != null);

            if (imageFormData != null)
            {
                var imageData = await imageFormData.ReadAsByteArrayAsync();

                new ImageService().SaveImage(area, imageFormData.Headers.ContentDisposition.FileName, imageData);
            }

            return area;
        }
    }
}
