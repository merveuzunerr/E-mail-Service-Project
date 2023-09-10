using EmailServiceProject.Models;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace EmailServiceProject.ConfigSettingsCode
{
    public class emailAdressConfig //The email address must be like "exampleemail@ssttek.com"
    {
        public bool IsValidEmail(string email)
        {   
            string pattern = @"^.+@ssttek\.com$";
            return Regex.IsMatch(email, pattern);
        }
      
    }

}
