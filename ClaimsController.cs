using Microsoft.AspNetCore.Mvc;
using ST10393673_PROG6212_POE.Models;

namespace ST10393673_PROG6212_POE.Controllers
{
    public class ClaimsController : Controller
    {
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            // Render the form with default values
            return View(new ClaimViewModel());
        }

        [HttpPost]
        public IActionResult SubmitClaim(ClaimViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Logic to save the claim can be added here (e.g., save to a database)
                ViewBag.Message = "Claim submission is successful";
                return View(new ClaimViewModel()); // Clear the form after submission
            }

            // If the form is invalid, return the view with validation messages
            ViewBag.Message = "Please complete all fields.";
            return View(model);
        }
    }
}
