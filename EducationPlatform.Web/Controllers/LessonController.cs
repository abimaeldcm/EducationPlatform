using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Web.Controllers
{
    public class LessonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
