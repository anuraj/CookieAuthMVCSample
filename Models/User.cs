using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Http;

namespace HelloMvc.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public IFormFile File { get; set; }
    }    
    
    public class AuthUser
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}