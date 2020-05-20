using Cooper.MotCheck.Ui.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cooper.MotCheck.Ui.Models
{
    public class CheckController : Controller
    {
        public IActionResult Result(MotCheckRequest model)
        {
            var viewModel = new CheckResultViewModel
            {
                Result = new MotCheckResponse
                {
                    Registration = model.Registration
                }
            };

            return View(viewModel);
        }
    }
}