using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;        
        public CustomersController()
        {
            _context = new ApplicationDbContext();            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Route("Customers/")]
        public ActionResult Index() 
        {
            var customers = _context.Customers.Include(c=>c.MembershipType);
            return View(customers);
        }

        // GET: Customers/Details/
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c=>c.MembershipType).FirstOrDefault(c => c.Id == id);
            return View(customer);
        }
    }
}