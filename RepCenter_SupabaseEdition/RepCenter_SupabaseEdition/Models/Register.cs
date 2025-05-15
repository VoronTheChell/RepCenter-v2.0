using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("register")]
public class Register : BaseModel
{
    [PrimaryKey("id_user", false)]
    public int IdUser { get; set; }

    [Column("login_user")]
    public string LoginUser { get; set; }

    [Column("password_user")]
    public string PasswordUser { get; set; }

    [Column("subject_user")]
    public string SubjectUser { get; set; }

    [Column("status_user")]
    public string StatusUser { get; set; }
}
