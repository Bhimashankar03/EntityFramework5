using EntityFramework5.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework5.Controllers
{
	public class CustomerController : Controller
	{
		public IActionResult Index()
		{
			CustomerDbContext db = new CustomerDbContext();
			var customer = db.Customers.ToList();

            return View(customer);
		}
		[HttpGet]
		public IActionResult Register()
		{
			Customer customer = new Customer();
			return View(customer);
		}
        [HttpPost]
        public IActionResult Register(Customer customer)
        {
			if (ModelState.IsValid)
			{
				CustomerDbContext db = new CustomerDbContext();
				db.Customers.Add(customer);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(customer);
        }
		public IActionResult Delete(int id)
		{
            CustomerDbContext db = new CustomerDbContext();
			var customer=db.Customers.FirstOrDefault(x=>x.Sno==id);
			db.Customers.Remove(customer);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
            CustomerDbContext db = new CustomerDbContext();
            var customer = db.Customers.FirstOrDefault(x => x.Sno == id);
			
            return View(customer);
		}
		[HttpPost]
        public IActionResult Edit(Customer customer)
        {
            CustomerDbContext db = new CustomerDbContext();
            var customerToUpdate = db.Customers.FirstOrDefault(x => x.Sno ==customer.Sno);
			customerToUpdate.Name = customer.Name;
            customerToUpdate.Email=customer.Email;
            customerToUpdate.MobNo=customer.MobNo;
            customerToUpdate.Address=customer.Address;
			db.SaveChanges();
			return RedirectToAction("index");
        }
    }
}
