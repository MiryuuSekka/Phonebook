using System.ComponentModel.DataAnnotations;

namespace FileManager.Models
{
    public class Person
    {
        
        //public int Id { get; set; }

        [Required(ErrorMessage = "Required first name")]
        [RegularExpression(@"^[A-Z]'?([a-zA-Z]|\.| |-)+$", ErrorMessage = "Validation failed. U can use only A-Z, a-z symbols")]
        [StringLength(20, ErrorMessage = "Too long name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required last name")]
        [RegularExpression(@"^[A-Z]'?([a-zA-Z]|\.| |-)+$", ErrorMessage = "Validation failed. U can use only A-Z, a-z symbols")]
        [StringLength(20, ErrorMessage = "Too long name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required birth year")]
        [Range(1900, 2019, ErrorMessage = "WrongYear")]
        public int BirthYear { get; set; }

        [Required(ErrorMessage = "Required telephone number")]
        [RegularExpression(@"^((\+7|7|8)+([0-9]){10})$", ErrorMessage = "Validation failed. Need 11 symbols, first one is 8 or 7")]
        [StringLength(11, ErrorMessage = "Too long telephone number")]
        public string Phone { get; set; }
    }
}
