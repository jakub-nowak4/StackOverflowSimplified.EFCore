namespace StackOverflowSimplified.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Votes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public User Author { get; set; }
        public Guid AuthorId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
