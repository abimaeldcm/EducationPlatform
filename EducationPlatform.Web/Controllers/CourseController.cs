using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Filters;
using EducationPlatform.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class CourseController : Controller
    {
        private readonly ICRUD<CourseOutput, CourseInput> _CourseService;

        public CourseController(ICRUD<CourseOutput, CourseInput> CourseService)
        {
            _CourseService = CourseService;
        }

        public async Task<ActionResult<IEnumerable<CourseOutput>>> Index()
        {
            var CoursesDb = await _CourseService.BuscarTodos();

            return View(CoursesDb);
        }

        public async Task<ActionResult> Details(int id)
        {
            return View(await _CourseService.BuscarPorId(id));
        }

        public async Task<ActionResult> Create()
        {
            /* ViewBag.BloodType = new SelectList(Enum.GetValues(typeof(ETBloodType)));
             ViewBag.SpecialityMedical = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "MedicalSpeciality");*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CourseInput collection)
        {
            try
            {
                //ViewBag.SpecialityId = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "Name");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            //ViewBag.BloodType = new SelectList(Enum.GetValues(typeof(ETBloodType)));
            //ViewBag.SpecialityMedical = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "MedicalSpeciality");
            var medicoDb = await _CourseService.BuscarPorId(id);
            return View(medicoDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CourseInput CourseEdit)
        {
            try
            {
                await _CourseService.Editar(id, CourseEdit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [PaginaUsuarioAdm]
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _CourseService.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PaginaUsuarioAdm]
        public async Task<ActionResult> DeleteExecute(int id)
        {
            try
            {
                var CourseDb = await _CourseService.BuscarPorId(id);
                if (CourseDb != null)
                {
                    await _CourseService.Delete(id);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
