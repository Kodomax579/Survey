namespace Umfrage.Model
{
    public class UserQuestions
    {
        public int UserId { get; set; }
        public int QuestionsId { get; set; }
        public User? User { get; set; }
        public Questions? Questions { get; set; }
        public DateTime Date { get; set; }
    }
}
