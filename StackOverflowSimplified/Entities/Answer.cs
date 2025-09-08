namespace StackOverflowSimplified.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Votes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
