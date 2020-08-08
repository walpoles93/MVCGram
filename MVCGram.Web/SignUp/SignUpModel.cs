using System.ComponentModel.DataAnnotations;

namespace MVCGram.Web.SignUp
{
    public class SignUpModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
