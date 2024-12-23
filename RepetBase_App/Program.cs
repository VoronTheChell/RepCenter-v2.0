using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepetBase_App
{
    internal class DataBase
    {
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source=VORONPC\SQLEXPRESS; Initial Catalog=RepCenter; Integrated Security=true");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public void CheckConnection()
        {
            try
            {
                openConnection();
                closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно подключиться к Базе Данных: {ex.Message}", "ОШИБКА ВХОДА!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            DataBase dataBase = new DataBase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dataBase.CheckConnection();

            Application.Run(new Admin_Form());
        }
    }
}
