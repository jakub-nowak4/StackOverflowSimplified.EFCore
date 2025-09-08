using System.ComponentModel.DataAnnotations;

namespace StackOverflowSimplified.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Answer> Answers { get; set; } = new List<Answer> ();
        public List<Comment> Comments { get; set; } = new List<Comment> ();
    }
}
