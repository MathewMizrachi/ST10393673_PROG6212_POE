using Microsoft.AspNetCore.Mvc;
using ST10393673_PROG6212_POE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST10393673_PROG6212_POE.Controllers
{
    public class ClaimsController : Controller
    {
        // This method renders the Verify Claims page
        // GET: Claims/VerifyClaims
        public async Task<IActionResult> VerifyClaims()
        {
            // Retrieve claims asynchronously from the data source
            var claims = await GetClaimsAsync();

            // Return the claims to the view
            return View(claims);
        }

        // This method updates the status of a claim
        // POST: Claims/UpdateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int claimId, string newStatus)
        {
            // Validate the new status
            var validStatuses = new List<string> { "Pending", "Approved", "Rejected" };
            if (!validStatuses.Contains(newStatus))
            {
                ModelState.AddModelError("", "Invalid status selected.");
                return RedirectToAction("VerifyClaims"); // Redirect to the view if there's an error
            }

            // Attempt to update the claim status asynchronously
            var result = await UpdateClaimStatusAsync(claimId, newStatus);
            if (!result)
            {
                ModelState.AddModelError("", "Error updating claim status.");
            }

            // After updating, redirect back to the claim verification page
            return RedirectToAction("VerifyClaims");
        }

        // This method fetches all claims asynchronously (mock data for now)
        private async Task<IEnumerable<ClaimViewModel>> GetClaimsAsync()
        {
            // Mock data (replace with actual data retrieval from database)
            var claims = new List<ClaimViewModel>
            {
                new ClaimViewModel { ClaimId = 1, LecturerName = "John Doe", HoursWorked = 12, HourlyRate = 50, SubmissionDate = System.DateTime.Now.AddDays(-3), Status = "Pending" },
                new ClaimViewModel { ClaimId = 2, LecturerName = "Jane Smith", HoursWorked = 10, HourlyRate = 60, SubmissionDate = System.DateTime.Now.AddDays(-5), Status = "Approved" },
                new ClaimViewModel { ClaimId = 3, LecturerName = "David Brown", HoursWorked = 8, HourlyRate = 55, SubmissionDate = System.DateTime.Now.AddDays(-2), Status = "Rejected" }
            };

            // Simulating async data fetch
            return await Task.FromResult(claims);
        }

        // This method updates the claim status asynchronously (placeholder for real implementation)
        private async Task<bool> UpdateClaimStatusAsync(int claimId, string newStatus)
        {
            

            // For now, we'll assume the update always succeeds for the sake of the example
            return await Task.FromResult(true);
        }
    }
}
