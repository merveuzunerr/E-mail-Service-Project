using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmailServiceProject.Models
{
    public class Mail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? fromEmail { get; set; }

        //Since fromEmail is a constant with "merveu@ssttek.com",
        //only toEmail and Message should be given values ​​when writing json.
        [Required]
        public string toEmail { get; set; }
        [Required]
        public string Message { get; set; }


    }
}
