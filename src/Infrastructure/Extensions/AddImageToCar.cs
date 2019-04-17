using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Komis.Core.Models;

namespace Komis.Infrastructure.Extensions
{
    public static class AddImageToCar
    {
        public static void Add(this IHostingEnvironment _hostingEnvironment, IFormFile[] Images, Car car)
        {
            var filesize = 2048;
            var supportedTypes = new[] { "jpg", "png" };

            foreach (var image in Images)
            {
                var fileExt = Path.GetExtension(image.FileName).Substring(1).ToLowerInvariant();

                if (!supportedTypes.Contains(fileExt))
                {
                    throw new Exception("Photos extension is invalid - only upload JPG/PNG files");
                }
                else if (image.Length > (filesize * 1024))
                {
                    throw new Exception($"Photos size should be up to {filesize} KB");
                }
                else if(car.Images.Count() + Images.Count() >6)
                {
                    throw new Exception("You can only upload up to 5 photos");
                }
                else
                {
                    string uniqueName = Guid.NewGuid().ToString() + '.' + fileExt;

                    var images = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    var lib = Path.Combine(_hostingEnvironment.WebRootPath, "lib");
                    var filePath = Path.Combine(images, uniqueName);

                    var id = Guid.Parse(Path.GetFileNameWithoutExtension(filePath));

                    using (var stream = new FileStream(filePath, FileMode.CreateNew))
                    {
                        image.CopyTo(stream);
                    }

                    filePath = Path.GetRelativePath(lib, filePath);

                    car.AddImage(filePath, uniqueName, id);
                }
            }

        }
    }
}
