using System.ComponentModel.DataAnnotations;

namespace EmailServiceProject.Models
{
    public class User
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9@_.-]+$")] //accepts only English characters, numbers, and certain symbols (., -, _, @).
        public string emailAdress { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
    }
}
