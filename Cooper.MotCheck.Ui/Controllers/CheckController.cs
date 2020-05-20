using Cooper.MotCheck.Models;
using Cooper.MotCheck.Services;
using Cooper.MotCheck.Ui.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cooper.MotCheck.Ui.Models
{
    public class CheckController : Controller
    {
        private readonly IMotCheckService motCheckService;

        public CheckController(IMotCheckService motCheckService)
        {
            this.motCheckService = motCheckService;
        }

        public async Task<IActionResult> Result(MotCheckRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var status = await motCheckService.CheckVehicleMot(model.Registration);
            var viewModel = new CheckResultViewModel
            {
                Result = status
            };

            return View(viewModel);
        }
    }
}