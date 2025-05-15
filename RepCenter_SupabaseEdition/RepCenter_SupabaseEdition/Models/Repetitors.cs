using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("repetitors")]
public class Repetitors : BaseModel
{
    [PrimaryKey("tutor_id", false)]
    public int TutorId { get; set; }

    [Column("id_user")]
    public int? IdUser { get; set; }

    [Column("fio")]
    public string FIO { get; set; }

    [Column("phone_number")]
    public string PhoneNumber { get; set; }

    [Column("kvalification")]
    public string Kvalification { get; set; }

    [Column("predmets")]
    public string Predmets { get; set; }
}
