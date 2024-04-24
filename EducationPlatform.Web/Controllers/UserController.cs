using EducationPlatform.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Services.Interfaces;
using EducationPlatform.Web.Domain.Entity.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationPlatform.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class UserController : Controller
    {
        private readonly ICRUD<UserOutput, UserInput> _userService;
        private readonly ICRUD<SignatureOutput, SignatureInput> _signatureService;

        public UserController(ICRUD<UserOutput, UserInput> userService, ICRUD<SignatureOutput, SignatureInput> signatureService)
        {
            _userService = userService;
            _signatureService = signatureService;
        }

        public async Task<ActionResult<IEnumerable<UserOutput>>> Index()
        {
            var UsersDb = await _userService.BuscarTodos();

            return View(UsersDb);
        }

        public async Task<ActionResult> Details(int id)
        {
            return View(await _userService.BuscarPorId(id));
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.ProfileType = new SelectList(Enum.GetValues(typeof(EProfile)));
            ViewBag.SignatureType = new SelectList((await _signatureService.BuscarTodos()).OrderBy(s => s.Name), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserInput userCreate)
        {
            try
            {
                await _userService.Cadastrar(userCreate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ProfileType = new SelectList(Enum.GetValues(typeof(EProfile)));
                ViewBag.SignatureType = new SelectList((await _signatureService.BuscarTodos()).OrderBy(s => s.Name), "Id", "Name");
                return View(userCreate);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            //ViewBag.BloodType = new SelectList(Enum.GetValues(typeof(ETBloodType)));
            //ViewBag.SpecialityMedical = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "MedicalSpeciality");
            var medicoDb = await _userService.BuscarPorId(id);
            return View(medicoDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UserInput userEdit)
        {
            try
            {
                await _userService.Editar(id, userEdit);
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
            return View(await _userService.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PaginaUsuarioAdm]
        public async Task<ActionResult> DeleteExecute(int id)
        {
            try
            {
                var userDb = await _userService.BuscarPorId(id);
                if (userDb != null)
                {
                    await _userService.Delete(id);
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

