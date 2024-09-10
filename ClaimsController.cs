using Microsoft.AspNetCore.Mvc;
using ST10393673_PROG6212_POE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ST10393673_PROG6212_POE.Services;

namespace ST10393673_PROG6212_POE.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly IClaimService _claimService;

        // Constructor to inject the claim service
        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        // GET: Claims/SubmitClaim
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();
        }

        // POST: Claims/SubmitClaim
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitClaim(ClaimViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Mocking the async submit operation
                await Task.CompletedTask;
                return RedirectToAction("ViewStatus");
            }

            return View(model);
        }

        // GET: Claims/ViewStatus
        [HttpGet]
        public async Task<IActionResult> ViewStatus(string statusFilter, string dateFilter)
        {
            // Mock data (replace with actual data retrieval from database)
            var claims = new List<ClaimViewModel>
            {
                new ClaimViewModel { ClaimId = 1, LecturerName = "John Doe", HoursWorked = 12, HourlyRate = 50, SubmissionDate = System.DateTime.Now.AddDays(-3), Status = "Pending" },
                new ClaimViewModel { ClaimId = 2, LecturerName = "Jane Smith", HoursWorked = 10, HourlyRate = 60, SubmissionDate = System.DateTime.Now.AddDays(-5), Status = "Approved" },
                new ClaimViewModel { ClaimId = 3, LecturerName = "David Brown", HoursWorked = 8, HourlyRate = 55, SubmissionDate = System.DateTime.Now.AddDays(-2), Status = "Rejected" }
            };

            // Simulating async data fetch
            return await Task.FromResult(View(claims));
        }

        // POST: Claims/UpdateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int claimId, string newStatus)
        {
            var validStatuses = new List<string> { "Pending", "Approved", "Rejected" };
            if (!validStatuses.Contains(newStatus))
            {
                ModelState.AddModelError("", "Invalid status selected.");
                return RedirectToAction("ViewStatus");
            }

            // Mocking the async update operation
            await Task.CompletedTask;
            return RedirectToAction("ViewStatus");
        }

        // GET: Claims/VerifyClaims
        [HttpGet]
        public IActionResult VerifyClaims()
        {
            // Mock data for verifying claims (replace with actual data retrieval if needed)
            var claims = new List<ClaimViewModel>
            {
                new ClaimViewModel { ClaimId = 1, LecturerName = "John Doe", HoursWorked = 12, HourlyRate = 50, SubmissionDate = System.DateTime.Now.AddDays(-3), Status = "Pending" },
                new ClaimViewModel { ClaimId = 2, LecturerName = "Jane Smith", HoursWorked = 10, HourlyRate = 60, SubmissionDate = System.DateTime.Now.AddDays(-5), Status = "Approved" },
                new ClaimViewModel { ClaimId = 3, LecturerName = "David Brown", HoursWorked = 8, HourlyRate = 55, SubmissionDate = System.DateTime.Now.AddDays(-2), Status = "Rejected" }
            };

            // Simulating async data fetch
            return View(claims);
        }
    }
}
