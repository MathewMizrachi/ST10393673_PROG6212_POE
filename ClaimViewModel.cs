using System;
using System.ComponentModel.DataAnnotations;

namespace ST10393673_PROG6212_POE.Models
{
    public class ClaimViewModel
    {
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
        public DateTime SubmissionDate { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}
