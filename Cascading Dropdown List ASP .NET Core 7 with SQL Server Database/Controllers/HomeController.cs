
using Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Cascading_Dropdown_List_ASP_.NET_Core_7_with_SQL_Server_Database.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;

        public HomeController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Customers()
        {
            List<Customer> Customers = _context.Customers
                                           .Include(c => c.Country)
                                           .Include(c => c.City)
                                           .ToList();
            return View(Customers);
        }

        private List<SelectListItem> GetCountries()
        {
            var CountriesList = new List<SelectListItem>();

            List<Country> Countries = _context.Countries.ToList();

            CountriesList = Countries.Select(cl => new SelectListItem()
            {
                Value = cl.Id.ToString(),
                Text = cl.countryName

            }).ToList();

            var DefaultItem = new SelectListItem()
            {
                Value = "",
                Text = "Select Country"

            };

            CountriesList.Insert(0, DefaultItem);

            return CountriesList;
        }
        private List<SelectListItem> GetCities(int countryId)
        {
            var CitiesList = new List<SelectListItem>();

            List<City> Cities = _context.Cities.Where(c => c.CountryId == countryId).ToList();

            CitiesList = Cities.Select(cl => new SelectListItem()
            {
                Value = cl.Id.ToString(),
                Text = cl.CityName

            }).ToList();

            var DefaultItem = new SelectListItem()
            {
                Value = "",
                Text = "Select City"

            };

            CitiesList.Insert(0, DefaultItem);

            return CitiesList;
        }

        //private List<SelectListItem> GetCities()
        //{

        //    var CitiesList = new List<SelectListItem>();

        //    List<City> Cities = _context.Cities.ToList();

        //    CitiesList = Cities.Select(cl => new SelectListItem()
        //    {
        //        Value = cl.Id.ToString(),
        //        Text = cl.CityName

        //    }).ToList();

        //    var DefaultItem = new SelectListItem()
        //    {
        //        Value = "",
        //        Text = "Select City"

        //    };

        //    CitiesList.Insert(0, DefaultItem);

        //    return CitiesList;
        //}


        private string getCountryName(int countryId)
        {
            string CountryName = _context.Countries.Where(c => c.Id == countryId).SingleOrDefault().countryName;
            return CountryName;
        }

        private string getCityName(int cityId)
        {
            string CityName = _context.Cities.Where(c => c.Id == cityId).SingleOrDefault().CityName;
            return CityName;
        }

        [HttpGet]
        public IActionResult Create()
        {
            Customer customer = new Customer();
       
            ViewBag.CountryId = GetCountries();

            ViewBag.CityId = GetCities(customer.CountryId);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();


            return RedirectToAction(nameof(Customers));
        }

        [HttpGet]
        public JsonResult GetCitiesByCountry(int countryId)
        {
            List<SelectListItem> cities = GetCities(countryId);
            return Json(cities);
        }

        private Customer getCustomer(int id)
        {
            Customer? customer = _context.Customers
                .Where(c => c.Id == id).FirstOrDefault();

            if (customer == null)
            {
                throw new ArgumentException("Invalid customer id");
            }

            return customer;

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer customer = getCustomer(id);
            ViewBag.CountryName = getCountryName(customer.CountryId);
            ViewBag.CityName = getCityName(customer.CityId);
            return View(customer);
        }


        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction(nameof(Customers));
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Customer customer = getCustomer(id);
            ViewBag.CountryName = getCountryName(customer.CountryId);
            ViewBag.CityName = getCityName(customer.CityId);

            return View(customer);
        }


        [HttpGet]
        public IActionResult Edit (int id)
        {
            Customer customer = getCustomer(id);
            if (customer != null)
            {
                 ViewBag.CountryId = GetCountries();
                ViewBag.CityId = GetCities(customer.CountryId);

            }

            return View(customer);
        }

      
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction(nameof(Customers));
        }

       
    }
}