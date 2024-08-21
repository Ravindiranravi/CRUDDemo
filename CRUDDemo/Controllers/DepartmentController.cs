using CRUDDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCRUDDemo.Controllers
{
    public class DepartmentController : Controller
    {

        private CompanyContext context;


        public DepartmentController(CompanyContext cC)
        {
            context = cC;
        }
        public IActionResult Create()
        {
            //var dept = new Department()
            //{
            //    Name = "Ravindiran"
            //};

            //context.Add(dept);
            //context.SaveChangesAsync();
            return View();
        }
        public IActionResult Index()
        {
            return View(context.Department.AsNoTracking());
        }
        public async Task<IActionResult> Edit(int id)
        {
            Department dept = await context.Department.Where(e => e.Id == id).FirstOrDefaultAsync();

            return View(dept);
        }

        [HttpPost]

        public async Task<IActionResult> Create(Department dept)
        {
            context.Add(dept);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department dept)
        {
            context.Update(dept);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var dept = new Department() { Id = id };
            context.Remove(dept);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}