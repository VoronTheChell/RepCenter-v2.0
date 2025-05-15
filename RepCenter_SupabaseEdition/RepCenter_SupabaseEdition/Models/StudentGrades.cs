using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("studentgrades")]
public class StudentGrades : BaseModel
{
    [PrimaryKey("gradeid", false)]
    public int GradeId { get; set; }

    [Column("studentid")]
    public int StudentId { get; set; }

    [Column("subject")]
    public string Subject { get; set; }

    [Column("grade")]
    public decimal Grade { get; set; }

    [Column("comments")]
    public string Comments { get; set; }

    [Column("evaluationdate")]
    public DateTime EvaluationDate { get; set; }
}
