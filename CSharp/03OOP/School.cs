namespace _03OOP;

/**
 * Since this code is expected to be viewed via Github.com, I'll put all classes and interfaces in one file.
 */

// Interfaces
public interface IPersonService
{
    decimal CalculateSalary();
    int CalculateAge();
    List<string> GetAddresses();
}

public interface IStudentService : IPersonService
{
    double CalculateGPA();
    void EnrollInCourse(Course course);
}

public interface IInstructorService : IPersonService
{
    decimal CalculateSalary();
    void AssignDepartment(Department department);
}

public interface ICourseService
{
    void EnrollStudent(Student student);
}

public interface IDepartmentService
{
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    void SetDepartmentHead(Instructor instructor);
    void AddCourse(Course course);
}

// Classes
public abstract class Person : IPersonService
{
    public string Name { get; set; }
    private DateTime BirthDate { get; set; }
    public List<string> Addresses { get; private set; }

    private decimal _salary;

    protected decimal Salary
    {
        get => _salary;
        set => _salary = value >= 0
            ? value
            : throw new ArgumentException("Salary cannot be negative");
    }

    protected Person(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
        Addresses = new List<string>();
    }

    /// <summary>
    /// Calculate age based on birth date
    /// </summary>
    /// <returns> Age in years </returns>
    public int CalculateAge()
    {
        var today = DateTime.Today;
        var age = today.Year - BirthDate.Year;
        return age;
    }

    /// <summary>
    /// Add address to the list of addresses
    /// </summary>
    /// <param name="address"></param>
    public void AddAddress(string address)
    {
        Addresses.Add(address);
    }

    /// <summary>
    /// Get the list of addresses
    /// </summary>
    /// <returns> List of addresses </returns>
    public List<string> GetAddresses()
    {
        return Addresses;
    }

    /// <summary>
    /// Calculate salary
    /// </summary>
    /// <returns> Annual salary </returns>
    public virtual decimal CalculateSalary()
    {
        return Salary;
    }
}

public class Instructor : Person, IInstructorService
{
    public Department Department { get; set; }
    private DateTime JoinDate { get; set; }
    public bool IsDepartmentHead { get; set; }


    public Instructor(string name, DateTime birthDate, DateTime joinDate) : base(name, birthDate)
    {
        JoinDate = joinDate;
        Salary = 70000;
    }

    private int GetYearsOfExperience()
    {
        var today = DateTime.Today;
        var years = today.Year - JoinDate.Year;
        return years;
    }

    public override decimal CalculateSalary()
    {
        // 3% increase for each year of experience
        var bonus = CalculateBonus();
        return Salary + bonus;
    }

    private decimal CalculateBonus()
    {
        return Salary * 0.03m * GetYearsOfExperience();
    }

    public void AssignDepartment(Department department)
    {
        Department = department;
    }
}

public class Student : Person, IStudentService
{
    private List<Course> EnrolledCourses { get; set; }
    private Dictionary<Course, char> CourseGrades { get; set; }


    public Student(string name, DateTime birthDate) : base(name, birthDate)
    {
        EnrolledCourses = new List<Course>();
        CourseGrades = new Dictionary<Course, char>();
    }

    public void EnrollInCourse(Course course)
    {
        if (EnrolledCourses.Contains(course))
        {
            throw new InvalidOperationException("Student is already enrolled in the course");
        }

        EnrolledCourses.Add(course);
        course.EnrollStudent(this);
    }

    public override decimal CalculateSalary()
    {
        throw new InvalidOperationException("Students do not have a salary");
    }

    public void SetGradeForCourse(Course course, char grade)
    {
        if (!EnrolledCourses.Contains(course))
        {
            throw new InvalidOperationException("Student is not enrolled in the course. Use EnrollInCourse method first.");
        }

        CourseGrades[course] = grade;
    }

    public double CalculateGPA()
    {
        if (CourseGrades.Count == 0) return 0;

        double totalPoints = 0;
        foreach (var grade in CourseGrades.Values)
        {
            totalPoints += GradeToPoint(grade);
        }

        return totalPoints / CourseGrades.Count;
    }

    /// <summary>
    /// Convert grade to point
    /// </summary>
    /// <param name="grade"></param>
    /// <returns> Point equivalent of the grade </returns>
    private double GradeToPoint(char grade)
    {
        return grade switch
        {
            'A' => 4.0,
            'B' => 3.0,
            'C' => 2.0,
            'D' => 1.0,
            'F' => 0.0,
            _ => 0.0,
        };
    }
}

public class Course : ICourseService
{
    public string CourseName { get; set; }
    public List<Student> EnrolledStudents { get; set; }
    private Dictionary<Student, char> StudentGrades { get; set; }


    public Course(string courseName)
    {
        CourseName = courseName;
        EnrolledStudents = new List<Student>();
        StudentGrades = new Dictionary<Student, char>();
    }

    public void EnrollStudent(Student student)
    {
        EnrolledStudents.Add(student);
    }
}

public class Department : IDepartmentService
{
    public decimal Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Instructor DepartmentHead { get; set; }
    public List<Course> Courses { get; set; }

    public Department(decimal budget, DateTime startDate, DateTime endDate)
    {
        Budget = budget;
        StartDate = startDate;
        EndDate = endDate;
        Courses = new List<Course>();
    }

    public void SetDepartmentHead(Instructor instructor)
    {
        DepartmentHead = instructor;
        instructor.AssignDepartment(this);
    }

    public void AddCourse(Course course)
    {
        Courses.Add(course);
    }
}