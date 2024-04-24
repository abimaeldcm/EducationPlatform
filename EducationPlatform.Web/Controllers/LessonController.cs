using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Filters;
using EducationPlatform.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class LessonController : Controller
    {
        private readonly ICRUD<LessonOutput, LessonInput> _LessonService;

        public LessonController(ICRUD<LessonOutput, LessonInput> LessonService)
        {
            _LessonService = LessonService;
        }

        public async Task<ActionResult<IEnumerable<LessonOutput>>> Index()
        {
            var LessonsDb = await _LessonService.BuscarTodos();

            return View(LessonsDb);
        }

        public async Task<ActionResult> Details(int id)
        {
            return View(await _LessonService.BuscarPorId(id));
        }

        public async Task<ActionResult> Create()
        {
            /* ViewBag.BloodType = new SelectList(Enum.GetValues(typeof(ETBloodType)));
             ViewBag.SpecialityMedical = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "MedicalSpeciality");*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LessonInput collection)
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
            var medicoDb = await _LessonService.BuscarPorId(id);
            return View(medicoDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LessonInput LessonEdit)
        {
            try
            {
                await _LessonService.Editar(id, LessonEdit);
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
            return View(await _LessonService.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PaginaUsuarioAdm]
        public async Task<ActionResult> DeleteExecute(int id)
        {
            try
            {
                var LessonDb = await _LessonService.BuscarPorId(id);
                if (LessonDb != null)
                {
                    await _LessonService.Delete(id);
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
