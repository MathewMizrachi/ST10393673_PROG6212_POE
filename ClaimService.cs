using ST10393673_PROG6212_POE.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST10393673_PROG6212_POE.Services
{
    public class ClaimService : IClaimService
    {
        // Simulated data store
        private static readonly List<ClaimViewModel> Claims = new List<ClaimViewModel>();

        public async Task SubmitClaimAsync(ClaimViewModel model)
        {
            // Simulate async operation
            await Task.Run(() =>
            {
                Claims.Add(model);
            });
        }

        public async Task<IEnumerable<ClaimViewModel>> GetClaimsAsync(string statusFilter, string dateFilter)
        {
            return await Task.Run(() =>
            {
                var filteredClaims = Claims.AsEnumerable();

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    filteredClaims = filteredClaims.Where(c => c.Status == statusFilter);
                }

                if (DateTime.TryParse(dateFilter, out DateTime date))
                {
                    filteredClaims = filteredClaims.Where(c => c.SubmissionDate.Date == date.Date);
                }

                return filteredClaims.ToList();
            });
        }

        public async Task<bool> UpdateClaimStatusAsync(int claimId, string newStatus)
        {
            return await Task.Run(() =>
            {
                var claim = Claims.FirstOrDefault(c => c.ClaimId == claimId);
                if (claim == null)
                {
                    return false;
                }

                claim.Status = newStatus;
                return true;
            });
        }
    }
}
