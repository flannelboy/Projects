using Cadillacs.WebSite.Model;
using Cadillacs.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cadillacs.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileCarService CarService;
        public IEnumerable<Car> Cars { get; private set; }
        public IndexModel(
            ILogger<IndexModel> logger ,
            JsonFileCarService carService)
        {
            _logger = logger;
            CarService = carService;
        }

        public void OnGet()
        {
            Cars = CarService.GetCars();
        }
    }
}