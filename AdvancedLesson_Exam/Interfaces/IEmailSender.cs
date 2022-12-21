
namespace AdvancedLesson_Exam.Interfaces
{
    public interface IEmailSender
    {
        public void SendUserEmail(string email, int line, int column);
        public void SendRestaurantEmail(string email);
    }
}
