using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Model
{
    public class Person
    {
        [Required(ErrorMessage ="Names is Required")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

    }
}
