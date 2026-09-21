namespace IPQuest.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; } = string.Empty;

        public int TopicId { get; set; }

        public Topic Topic { get; set; } = null!;

        public List<AnswerOption> AnswerOptions { get; set; } = new();
    }
}