// MathAssignment.cs
public class MathAssignment : Assignment
{
    private string _section;
    private string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string section, string problems)
        : base(studentName, topic) // call base class constructor
    {
        _section = section;
        _problems = problems;
    }

    // Method to display math homework list
    public string GetHomeworkList()
    {
        return $"Section {_section} Problems {_problems}";
    }
}
