using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("raspisanie_zaniyatiy")]
public class RaspisanieZaniyatiy : BaseModel
{
    [PrimaryKey("schedule_id", false)]
    public int ScheduleId { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("tutor_id")]
    public int TutorId { get; set; }

    [Column("time_learn")]
    public string TimeLearn { get; set; }

    [Column("learn_status")]
    public string LearnStatus { get; set; }
}
