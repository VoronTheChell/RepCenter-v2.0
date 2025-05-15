using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("student")]
public class Student : BaseModel
{
    [PrimaryKey("student_id", false)]
    public int StudentId { get; set; }

    [Column("id_user")]
    public int? IdUser { get; set; }

    [Column("fio")]
    public string FIO { get; set; }

    [Column("date_birth")]
    public string DateBirth { get; set; }

    [Column("number_phone")]
    public string NumberPhone { get; set; }

    [Column("email_adress")]
    public string EmailAdress { get; set; }

    [Column("predmet")]
    public string Predmet { get; set; }
}
