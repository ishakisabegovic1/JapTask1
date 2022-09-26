namespace Api.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string content { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}