namespace EducationPlatform.Domain.Entity.EntityRelational
{
    public class UserLessonCompleted
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdLesson { get; set; }
        public DateTime FinishedLesson { get; set; }

        public UserEntity User { get; set; }
        public Lesson Lesson { get; set; }
    }
}
