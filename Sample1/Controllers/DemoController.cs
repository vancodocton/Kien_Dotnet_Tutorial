using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample1.Data;
using Sample1.Extensions;
using Sample1.Models;

namespace Sample1.Controllers
{
    public class DemoController : Controller
    {
        private readonly ApplicationDbContext context;

        public DemoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Demo1Async()
        {
            var category = new Category()
            {
                Name = "Empty",
                Created = DateTime.UtcNow,
            };

            context.Categories.Add(category);

            await context.SaveChangesAsync();

            return Ok(category);
        }

        // mvc is UI architecture not software architecture.
        public async Task<IActionResult> Demo2Async(int id)
        {
            var category = await context.Categories.FirstAsync(c => c.Id == id);

            //var time = category.Created.GetDateTimeByUserTz();

            category.Created = category.Created.GetDateTimeByUserTz();

            return Ok(category);
        }

        public async Task<IActionResult> Demo3Async(int id)
        {
            var category = await context.Categories.FirstAsync(c => c.Id == id);

            var time = DateTime.Now;

            var utc = TimeZoneInfo.ConvertTimeToUtc(time, TimeZoneInfo.Local);


            category.Created = time.GetUtcDateTimeFromUserTz();

            context.Update(category);

            await context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpGet]
        public IActionResult Demo4()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Demo4Async(Category category)
        {
            context.Add(category);

            category.Created = category.Created.GetUtcDateTimeFromUserTz();

            await context.SaveChangesAsync();

            return RedirectToAction("Demo2", new { id = category.Id });
        }
    }
}
