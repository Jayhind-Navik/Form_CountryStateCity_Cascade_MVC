using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Form_CountryStateCity_Cascade_MVC.Models
{
    public class ApplicationForm
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Range(18, 100)]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
    }
}
