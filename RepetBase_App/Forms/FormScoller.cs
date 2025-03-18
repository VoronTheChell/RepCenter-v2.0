using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepetBase_App
{
    public partial class FormScoller : Form
    {
        private readonly DataBase dataBase = new DataBase();
        private readonly int loggedInUserId; // ID вошедшего пользователя

        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();

        // Конструктор с передачей ID пользователя
        public FormScoller(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId; // Сохраняем ID пользователя
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormScoller_Load(object sender, EventArgs e)
        {
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;

            CreateColumns_DataTime();
            CreateColumns_Payment();

            PlayMusicFon();
        }

        private void PlayMusicFon()
        {
            DateTime currentTime = DateTime.Now;
            DateTime morningTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 8, 30, 0);
            DateTime nightTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 17, 30, 0);

            if (currentTime >= nightTime || currentTime < morningTime)
            {
                player.controls.stop();
                player.URL = "https://vgmsite.com/soundtracks/wii-forecast-channel/uslofipyyl/11%20Global%20Forecast%20%28Nighttime%20-%20Layer%20Only%29.mp3";
                player.settings.setMode("loop", true);
                player.controls.play();
            }
            else if (currentTime >= morningTime && currentTime < nightTime)
            {
                player.controls.stop();
                player.URL = "https://vgmsite.com/soundtracks/wii-forecast-channel/stywgflmqc/10%20Global%20Forecast%20%28Daytime%20-%20Layer%20Only%29.mp3";
                player.settings.setMode("loop", true);
                player.controls.play();
            }
        }

        private void CreateColumns_DataTime()
        {
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"
                SELECT s.FIO AS 'Ученик', t.FIO AS 'Учитель', r.Time_Learn AS 'Время начала занятия', 
                       r.Learn_Status AS 'Статус занятия' 
                FROM Raspisanie_Zaniyatiy r 
                JOIN Student s ON r.student_id = s.student_id 
                JOIN Repetitors t ON r.tutor_id = t.tutor_id 
                WHERE s.id_User = @UserID", dataBase.GetConnection());

            com.Parameters.AddWithValue("@UserID", loggedInUserId);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Raspisanie_Zaniyatiy");
            dataGridView2.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void CreateColumns_Payment()
        {
            dataBase.openConnection();
            SqlCommand com = new SqlCommand(@"
                SELECT s.FIO AS 'Студент', t.FIO AS 'Репетитор', 
                       p.Date_of_Payment AS 'Дата оплаты', p.Summ_Payment AS 'Сумма оплаты', 
                       p.Status_Pay AS 'Статус оплаты' 
                FROM Payment p 
                JOIN Student s ON p.student_id = s.student_id 
                JOIN Repetitors t ON p.tutor_id = t.tutor_id 
                WHERE s.id_User = @UserID", dataBase.GetConnection());

            com.Parameters.AddWithValue("@UserID", loggedInUserId);

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Payment");
            dataGridView3.DataSource = ds.Tables[0];
            dataBase.closeConnection();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.closeConnection();
            player.controls.stop();
            this.Close();
        }
    }
}
