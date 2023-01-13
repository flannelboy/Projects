using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using Cadillacs.WebSite.Model;
using Microsoft.AspNetCore.Hosting;

namespace Cadillacs.WebSite.Services
{
    public class JsonFileCarService
    {
        public JsonFileCarService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "Cadillacs.json");
            }
        }
        public IEnumerable<Car> GetCars()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Car[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    });
            }
        }
    }
}
