using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Filters;
using EducationPlatform.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.Web.Controllers
{
    [PaginaUsuarioLogado]
    public class BlockController : Controller
    {
        private readonly ICRUD<BlockOutput, BlockInput> _BlockService;

        public BlockController(ICRUD<BlockOutput, BlockInput> BlockService)
        {
            _BlockService = BlockService;
        }

        public async Task<ActionResult<IEnumerable<BlockOutput>>> Index()
        {
            var BlocksDb = await _BlockService.BuscarTodos();

            return View(BlocksDb);
        }

        public async Task<ActionResult> Details(int id)
        {
            return View(await _BlockService.BuscarPorId(id));
        }

        public async Task<ActionResult> Create()
        {
            /* ViewBag.BloodType = new SelectList(Enum.GetValues(typeof(ETBloodType)));
             ViewBag.SpecialityMedical = new SelectList((await _SpecialityService.BuscarTodos()).OrderBy(s => s.MedicalSpeciality), "Id", "MedicalSpeciality");*/
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BlockInput collection)
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
            var medicoDb = await _BlockService.BuscarPorId(id);
            return View(medicoDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BlockInput BlockEdit)
        {
            try
            {
                await _BlockService.Editar(id, BlockEdit);
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
            return View(await _BlockService.BuscarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [PaginaUsuarioAdm]
        public async Task<ActionResult> DeleteExecute(int id)
        {
            try
            {
                var BlockDb = await _BlockService.BuscarPorId(id);
                if (BlockDb != null)
                {
                    await _BlockService.Delete(id);
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
