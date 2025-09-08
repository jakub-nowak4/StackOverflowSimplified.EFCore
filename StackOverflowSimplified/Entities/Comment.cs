namespace StackOverflowSimplified.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Views { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public User Author { get; set; }
        public Guid AuthorId { get; set; }

        public Answer Answer { get; set; }
        public int? AnswerId { get; set; }

        public Question Question { get; set; }
        public int? QuestionId { get; set; }
    }
}
