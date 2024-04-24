using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Filters;
using EducationPlatform.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class SignatureController : Controller
    {
        private readonly ICRUD<SignatureOutput, SignatureInput> _SignatureService;

        public SignatureController(ICRUD<SignatureOutput, SignatureInput> SignatureService)
        {
            _SignatureService = SignatureService;
        }

        public async Task<ActionResult<IEnumerable<SignatureOutput>>> Index()
        {
            var SignaturesDb = await _SignatureService.BuscarTodos();

            return View(SignaturesDb);
        }

        public async Task<ActionResult> Details(int id)
        {
            return View(await _SignatureService.BuscarPorId(id));
        }

        public async Task<ActionResult> Create()
        {
            /* ViewBag.BloodType = new SelectList(Enum.GetValues(typeof(ETBloodType)));
             ViewBag.SpecialityMedical = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "MedicalSpeciality");*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SignatureInput collection)
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
            var medicoDb = await _SignatureService.BuscarPorId(id);
            return View(medicoDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SignatureInput SignatureEdit)
        {
            try
            {
                await _SignatureService.Editar(id, SignatureEdit);
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
            return View(await _SignatureService.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PaginaUsuarioAdm]
        public async Task<ActionResult> DeleteExecute(int id)
        {
            try
            {
                var SignatureDb = await _SignatureService.BuscarPorId(id);
                if (SignatureDb != null)
                {
                    await _SignatureService.Delete(id);
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
