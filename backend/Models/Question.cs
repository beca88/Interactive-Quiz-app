

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace backend.Models
{
    public class Question
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string QuestionText { get; set; } = default!;
        [Required]
        public List<string> Options { get; set; } = []; 
        [Required]
        public string CorrectAnswer { get; set; } = default!;

    }
}