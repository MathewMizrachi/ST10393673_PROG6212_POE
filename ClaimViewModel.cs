using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;  // Add this for IFormFile

namespace ST10393673_PROG6212_POE.Models
{
    public class ClaimViewModel
    {
        public int ClaimId { get; set; }

        [Required]
        [Display(Name = "Lecturer Name")]
        public string LecturerName { get; set; }

        [Required]
        [Display(Name = "Hours Worked")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid number of hours.")]
        public double HoursWorked { get; set; }

        [Required]
        [Display(Name = "Hourly Rate")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid hourly rate.")]
        public double HourlyRate { get; set; }

        [Required]
        [Display(Name = "Submission Date")]
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; } = DateTime.Now;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending Review";

        // Add this property for file upload
        [Display(Name = "Supporting Documents")]
        public IFormFile SupportingDocuments { get; set; }
    }
}
