namespace EzovionAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DOB { get; set; }

        public int TotalMarks { get; set; } 

        public decimal CGPA { get; set; }
        public string Mobile { get; set; } = string.Empty;
        public string? Address { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;

        public string GraduationYear { get; set; } = string.Empty;
    }
}
