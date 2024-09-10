using Microsoft.AspNetCore.Mvc;
using ST10393673_PROG6212_POE.Models;
using System.Threading.Tasks;

namespace ST10393673_PROG6212_POE.Controllers
{
    public class ClaimsController : Controller
    {
        // GET: Claims/SubmitClaim
        public IActionResult SubmitClaim()
        {
            return View(new ClaimViewModel());
        }

        // POST: Claims/SubmitClaim
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitClaim(ClaimViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the file
                if (model.SupportingDocuments != null && model.SupportingDocuments.Length > 0)
                {
                    // Save file logic here (e.g., to blob storage or server directory)
                }

                // Process other form data
                // Save claim to database or storage

                // Clear the form and show a success message
                TempData["SuccessMessage"] = "Claim submitted successfully!";
                return RedirectToAction("SubmitClaim");
            }

            return View(model);
        }
    }
}
