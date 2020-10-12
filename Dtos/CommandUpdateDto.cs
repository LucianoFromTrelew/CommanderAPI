using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandUpdateDto
    {
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