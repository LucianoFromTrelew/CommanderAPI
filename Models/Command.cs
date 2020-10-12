using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        [MaxLength(256)]
        public string CommandLine { get; set; }
        [Required]
        [MaxLength(256)]
        public string Platform { get; set; }
    }
}