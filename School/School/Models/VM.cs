namespace School.Models
{
    public class VM
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public int StudentId { get; set; }
        public int CourseId { get; set; }


    }
}
