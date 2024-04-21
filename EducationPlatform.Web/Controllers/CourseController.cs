using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Web.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
