using _01.CreateSimplePages.Models;
using Microsoft.AspNetCore.Mvc;

namespace _01.CreateSimplePages.Controllers
{
    public class TextSplitterController : Controller
    {
        public IActionResult Index(TextViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Split(TextViewModel model)
        {
            var splitTextArray = model
                .Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            model.SplitText = string.Join(Environment.NewLine, splitTextArray);

            return RedirectToAction("Index", model);
        }
    }
}
