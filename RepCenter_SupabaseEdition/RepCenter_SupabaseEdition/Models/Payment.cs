using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

[Table("payment")]
public class Payment : BaseModel
{
    [PrimaryKey("payment_id", false)]
    public int PaymentId { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("tutor_id")]
    public int TutorId { get; set; }

    [Column("date_of_payment")]
    public string DateOfPayment { get; set; }

    [Column("summ_payment")]
    public int SummPayment { get; set; }

    [Column("status_pay")]
    public string StatusPay { get; set; }
}
