using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("pridments")]
public class Pridments : BaseModel
{
    [PrimaryKey("subject_id", false)]
    public int SubjectId { get; set; }

    [Column("name_pridment")]
    public string NamePridment { get; set; }
}
