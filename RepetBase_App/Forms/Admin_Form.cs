using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


using System.Net.Mail;
using System.Net;
using RepetBase_App.Forms;

using Aspose.Pdf;
using Aspose.Pdf.Text;
using Aspose.Pdf.Drawing;

namespace RepetBase_App
{

    public partial class Admin_Form : Form
    {
        private readonly DataBase dataBase = new DataBase();

        private readonly DataTable dataTable = new DataTable();

        DataTable paymentDataTable;

        int selectdRow;

        public int id_users, id_student, 
                   id_teacher, id_raspisanie, 
                   id_pridmet, id_payment;

        public bool Clear_Funk = false;

        public Admin_Form()
        {
            InitializeComponent();
            AppOptions();

            CreateColumns();
            LoadScheduleData();
            LoadPaymentData();

            LoadScoolersToComboBox();
            LoadTeachersToComboBox();
            LoadSubjectsToComboBox();
        }

        private void AppOptions()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            Users_Primary_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            TypeOfUser_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            Pridmets_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            PridmetTeacher_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            Status_Zanyria_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectScooler_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectTeacher_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            PayScoller_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            PayTeacher_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            PayStatus_CB.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CreateColumns()
        {
            FillDataGridView("SELECT id_User AS 'ID', login_user AS 'Логин пользователей', password_user AS 'Пароли', subject_user AS 'Предметы', " +
                             "status_user AS 'Тип пользователя' FROM register", UsersDGV);

            FillDataGridView("SELECT student_id AS 'ID', FIO AS 'ФИО', Date_Birth AS 'Дата рождения', Number_Phone AS 'Номер телефона', " +
                             "Email_adress AS 'Почта', Predmet AS 'Предмет' FROM Student", StudentDGV);

            FillDataGridView("SELECT tutor_id AS 'ID', FIO AS 'ФИО', Phone_Number AS 'Номер телефона', Kvalification AS 'Квалификация', " +
                             "Predmets AS 'Предмет' FROM Repetitors", TeacherDGV);

            FillDataGridView("SELECT r.schedule_id AS 'ID', s.FIO AS 'Ученик', t.FIO AS 'Учитель', r.Time_Learn AS 'Время начала занятия', " +
                             "r.Learn_Status AS 'Статус занятия' FROM Raspisanie_Zaniyatiy r JOIN Student s ON r.student_id = s.student_id " +
                             "JOIN Repetitors t ON r.tutor_id = t.tutor_id", DataLearnDGV);
            
            FillDataGridView("SELECT subject_id AS 'ID', Name_Pridment AS 'Названия предмета' FROM Pridments", LearnThemeDGV);

            FillDataGridView("SELECT p.payment_id AS 'ID', s.FIO AS 'Студент', t.FIO AS 'Репетитор', p.Date_of_Payment AS 'Дата оплаты', " +
                             "p.Summ_Payment AS 'Сумма оплаты', p.Status_Pay AS 'Статус оплаты' FROM Payment p JOIN Student s ON p.student_id = s.student_id " +
                             "JOIN Repetitors t ON p.tutor_id = t.tutor_id;", PaymentDGV);
        }

        private void LoadScheduleData()
        {
            // Загружаем данные из базы данных один раз и сохраняем в DataTable
            string query = "SELECT r.schedule_id AS 'ID', s.FIO AS 'Студент', t.FIO AS 'Репетитор', " +
                           "r.Time_Learn AS 'Дата занятия', " +
                           "r.Learn_Status AS 'Статус занятия' " +
                           "FROM Raspisanie_Zaniyatiy r " +
                           "JOIN Student s ON r.student_id = s.student_id " +
                           "JOIN Repetitors t ON r.tutor_id = t.tutor_id";
            
            using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }
        }
        
        private void LoadPaymentData()
        {
            // Загружаем данные из базы данных один раз и сохраняем в DataTable
            string query = "SELECT p.payment_id AS 'ID', s.FIO AS 'Студент', t.FIO AS 'Репетитор', " +
                           "p.Date_of_Payment AS 'Дата оплаты', p.Summ_Payment AS 'Сумма', p.Status_Pay AS 'Статус оплаты' " +
                           "FROM Payment p " +
                           "JOIN Student s ON p.student_id = s.student_id " +
                           "JOIN Repetitors t ON p.tutor_id = t.tutor_id";

            paymentDataTable = new DataTable();
            using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(paymentDataTable);
            }

            // Привязываем DataTable к DataGridView
            PaymentDGV.DataSource = paymentDataTable;
        }

        private void FillDataGridView(string query, DataGridView dataGridView)
        {
            dataBase.openConnection();
            using (SqlCommand com = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(com))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView.DataSource = ds.Tables[0];
                dataGridView.AutoResizeColumns();
            }
            dataBase.closeConnection();
        }

        private void SearchUp(string query, DataGridView dataGridView, params (string, object)[] parameters)
        {
            dataBase.openConnection();
            using (SqlCommand com = new SqlCommand(query, dataBase.GetConnection()))
            {
                foreach (var param in parameters)
                    com.Parameters.AddWithValue(param.Item1, param.Item2);

                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView.DataSource = ds.Tables[0];
                dataGridView.AutoResizeColumns();
            }
            dataBase.closeConnection();
        }

        private int GetIDByNameStudent(string selectedName)
        {
            // Устанавливаем значение по умолчанию, если ID не найден
            int idStudent = -1;

            // Проверяем, что selectedName не равен null или пустой строке
            if (string.IsNullOrEmpty(selectedName))
            {
                MessageBox.Show("Имя студента не указано.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return idStudent;
            }

            // Открываем соединение и выполняем запрос в блоке using
            string query = "SELECT student_id FROM Student WHERE FIO = @Name";
            try
            {
                dataBase.openConnection();
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    // Устанавливаем значение параметра @Name
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = selectedName;

                    // Выполняем запрос и получаем результат
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        idStudent = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обращении к базе данных: {ex.Message}", "Ошибка");
            }
            finally
            {
                // Закрываем соединение
                dataBase.closeConnection();
            }

            return idStudent;
        }

        private int GetIDByNameTeacher(string selectedName)
        {
            id_teacher = -1; // Значение по умолчанию, если ID не найден

            try
            {
                dataBase.openConnection(); // Открываем подключение
                string query = "SELECT tutor_id FROM Repetitors WHERE FIO = @Name";
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Name", selectedName);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        id_teacher = Convert.ToInt32(result);
                    }
                }
            }

            finally
            {
                dataBase.closeConnection(); // Закрываем подключение
            }

            return id_teacher;
        }

        public void LoadScoolersToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            SelectScooler_CB.Items.Clear();
            PayScoller_CB.Items.Clear();

            // SQL-запрос для получения названий предметов из таблицы Student
            string query = "SELECT FIO FROM Student";

            // Открываем соединение и выполняем запрос
            dataBase.openConnection();
            using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Добавляем каждый предмет в ComboBox
                    SelectScooler_CB.Items.Add(reader["FIO"].ToString());
                    PayScoller_CB.Items.Add(reader["FIO"].ToString());
                }
            }
            dataBase.closeConnection();
        }

        public void LoadTeachersToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            SelectTeacher_CB.Items.Clear();
            PayTeacher_CB.Items.Clear();

            // SQL-запрос для получения названий предметов из таблицы Repetitors
            string query = "SELECT FIO FROM Repetitors";

            // Открываем соединение и выполняем запрос
            dataBase.openConnection();
            using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Добавляем каждый предмет в ComboBox
                    SelectTeacher_CB.Items.Add(reader["FIO"].ToString());
                    PayTeacher_CB.Items.Add(reader["FIO"].ToString());
                }
            }
            dataBase.closeConnection();
        }

        public void LoadSubjectsToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            Users_Primary_CB.Items.Clear();
            Pridmets_CB.Items.Clear();
            PridmetTeacher_CB.Items.Clear();

            // SQL-запрос для получения названий предметов из таблицы Pridments
            string query = "SELECT Name_Pridment FROM Pridments";

            // Открываем соединение и выполняем запрос
            dataBase.openConnection();
            using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Добавляем каждый предмет в ComboBox
                    Users_Primary_CB.Items.Add(reader["Name_Pridment"].ToString());
                    Pridmets_CB.Items.Add(reader["Name_Pridment"].ToString());
                    PridmetTeacher_CB.Items.Add(reader["Name_Pridment"].ToString());
                }
            }
            dataBase.closeConnection();
        }

        private void ExecuteQuery(string query, params (string, object)[] parameters)
        {
            dataBase.openConnection();
            using (SqlCommand com = new SqlCommand(query, dataBase.GetConnection()))
            {
                foreach (var param in parameters)
                    com.Parameters.AddWithValue(param.Item1, param.Item2);

                com.ExecuteNonQuery();
            }
            dataBase.closeConnection();
        }



        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функции для пункта: Пользователи

        private void SearchApp_ChangeText(object sender, EventArgs e)
        {
            string searchapString = $"select id_User as 'ID', login_user as 'Логин пользователей', password_user as 'Пароли', " +
                                    $"subject_user as 'Предметы', status_user as 'Тип пользователя' " +
                                    $"from register where login_user like @SearchText";

            SearchUp(searchapString, UsersDGV, ("@SearchText", "%" + textBox1.Text + "%"));
        }

        private void UsersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = UsersDGV.Rows[selectdRow];

                    id_users = Convert.ToInt32(row.Cells[0].Value);
                    UserLogin_TB.Text = row.Cells[1].Value.ToString();
                    UserPass_TB.Text = row.Cells[2].Value.ToString();
                    Users_Primary_CB.Text = row.Cells[3].Value.ToString();
                    TypeOfUser_CB.Text = row.Cells[4].Value.ToString();
                }

                catch 
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }

        private void ClearUserFields()
        {
            UserLogin_TB.Text = "";
            UserPass_TB.Text = "";
            Users_Primary_CB.SelectedIndex = -1;
            TypeOfUser_CB.SelectedIndex = -1;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserLogin_TB.Text) || string.IsNullOrEmpty(UserPass_TB.Text) || string.IsNullOrEmpty(Users_Primary_CB.Text) || string.IsNullOrEmpty(TypeOfUser_CB.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                string delcommandString = "DELETE FROM register WHERE id_User = @UserID";
                ExecuteQuery(delcommandString, ("@UserID", id_users));
                ClearUserFields();
                CreateColumns();
                MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            string addCommandString = "INSERT INTO register (login_user, password_user, subject_user, status_user) VALUES (@Login, @Password, @Subject, @Status)";
            ExecuteQuery(addCommandString,
                         ("@Login", UserLogin_TB.Text),
                         ("@Password", UserPass_TB.Text),
                         ("@Subject", Users_Primary_CB.Text),
                         ("@Status", TypeOfUser_CB.Text));
            ClearUserFields();
            CreateColumns();
            MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            string changeCommandString = "UPDATE register SET login_user = @Login, password_user = @Password, subject_user = @Subject, status_user = @Status WHERE id_User = @UserID";
            ExecuteQuery(changeCommandString,
                         ("@Login", UserLogin_TB.Text),
                         ("@Password", UserPass_TB.Text),
                         ("@Subject", Users_Primary_CB.Text),
                         ("@Status", TypeOfUser_CB.Text),
                         ("@UserID", id_users));
            ClearUserFields();
            CreateColumns();
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ClearButton1_Click(object sender, EventArgs e)
        {
            UsersDGV.Update();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------
        // Реализация функций для работы со студентами
        private void SearchApp2_ChangeText(object sender, EventArgs e)
        {
            string searchapString = "SELECT student_id AS 'ID', FIO AS 'ФИО', Date_Birth AS 'Дата рождения', " +
                                    "Number_Phone AS 'Номер телефона', Email_adress AS 'Почта', Predmet AS 'Предмет' " +
                                    "FROM Student WHERE FIO LIKE @SearchText";
            SearchUp(searchapString, StudentDGV, ("@SearchText", "%" + textBox2.Text + "%"));
        }

        private void StudentDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = StudentDGV.Rows[selectdRow];
                    id_student = Convert.ToInt32(row.Cells[0].Value);
                    FIO_Student_TB.Text = row.Cells[1].Value.ToString();
                    StudentDataTime_TBM.Text = row.Cells[2].Value.ToString();
                    StudentNumberPhone_TBM.Text = row.Cells[3].Value.ToString();
                    Pridmets_CB.Text = row.Cells[4].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FIO_Student_TB.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                string delCommandString = "DELETE FROM Student WHERE student_id = @StudentID";
                ExecuteQuery(delCommandString, ("@StudentID", id_student));
                ClearStudentFields();
                CreateColumns();
                MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadScoolersToComboBox();
            }
        }

        private void buttonNew2_Click(object sender, EventArgs e)
        {
            string addCommandString = "INSERT INTO Student (FIO, Date_Birth, Number_Phone, Email_adress, Predmet) " +
                                      "VALUES (@FIO, @DateBirth, @NumberPhone, @Predmet)";
            ExecuteQuery(addCommandString,
                         ("@FIO", FIO_Student_TB.Text),
                         ("@DateBirth", StudentDataTime_TBM.Text),
                         ("@NumberPhone", StudentNumberPhone_TBM.Text),
                         ("@Email", emailValues_TB.Text),
                         ("@Predmet", Pridmets_CB.Text));
            ClearStudentFields();
            CreateColumns();
            MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadScoolersToComboBox();
        }

        private void buttonChange2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FIO_Student_TB.Text) || string.IsNullOrEmpty(StudentDataTime_TBM.Text) || string.IsNullOrEmpty(StudentNumberPhone_TBM.Text) || string.IsNullOrEmpty(Pridmets_CB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string changeCommandString = "UPDATE Student SET FIO = @FIO, Date_Birth = @DateBirth, Number_Phone = @NumberPhone, " +
                                         "Email_adress = @Email, Predmet = @Predmet WHERE student_id = @StudentID";
            ExecuteQuery(changeCommandString,
                         ("@FIO", FIO_Student_TB.Text),
                         ("@DateBirth", StudentDataTime_TBM.Text),
                         ("@NumberPhone", StudentNumberPhone_TBM.Text),
                         ("@Email", emailValues_TB.Text),
                         ("@Predmet", Pridmets_CB.Text),

                         ("@StudentID", id_student));
            ClearStudentFields();
            CreateColumns();
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadScoolersToComboBox();
        }

        private void ClearButton2_Click(object sender, EventArgs e)
        {
            ClearStudentFields();
        }

        // Метод для очистки полей формы для студентов
        private void ClearStudentFields()
        {
            FIO_Student_TB.Text = "";
            StudentDataTime_TBM.Text = "";
            StudentNumberPhone_TBM.Text = "";
            Pridmets_CB.SelectedIndex = -1;
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функций для работы с репетиторами
        private void SearchApp3_ChangeText(object sender, EventArgs e)
        {
            string searchQuery = "SELECT tutor_id AS 'ID', FIO AS 'ФИО', Phone_Number AS 'Номер телефона', " +
                                 "Kvalification AS 'Квалификация', Predmets AS 'Предмет' " +
                                 "FROM Repetitors WHERE FIO LIKE @SearchText";
            SearchUp(searchQuery, TeacherDGV, ("@SearchText", "%" + textBox3.Text + "%"));
        }

        private void TeacherDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = TeacherDGV.Rows[selectdRow];
                    id_teacher = Convert.ToInt32(row.Cells[0].Value);
                    TeacherFIO_TB.Text = row.Cells[1].Value.ToString();
                    RepNumberPhone_TBM.Text = row.Cells[2].Value.ToString();
                    Cvalification_TB.Text = row.Cells[3].Value.ToString();
                    PridmetTeacher_CB.Text = row.Cells[4].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeacherFIO_TB.Text))
            {
                MessageBox.Show("Отсутсвует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                string delCommand = "DELETE FROM Repetitors WHERE tutor_id = @IDTeacher";
                ExecuteQuery(delCommand, ("@IDTeacher", id_teacher));
                ClearTeacherFields();
                CreateColumns();
                MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTeachersToComboBox();
            }
        }

        private void buttonNew3_Click(object sender, EventArgs e)
        {
            string addCommand = "INSERT INTO Repetitors (FIO, Phone_Number, Kvalification, Predmets) " +
                                "VALUES (@FIO, @PhoneNumber, @Kvalification, @Predmet)";

            ExecuteQuery(addCommand,
                         ("@FIO", TeacherFIO_TB.Text),
                         ("@PhoneNumber", RepNumberPhone_TBM.Text),
                         ("@Kvalification", Cvalification_TB.Text),
                         ("@Predmet", PridmetTeacher_CB.Text));
            ClearTeacherFields();
            CreateColumns();
            MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTeachersToComboBox();
        }

        private void buttonChange3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeacherFIO_TB.Text) || string.IsNullOrEmpty(RepNumberPhone_TBM.Text) ||
                string.IsNullOrEmpty(Cvalification_TB.Text) || string.IsNullOrEmpty(PridmetTeacher_CB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string changeCommand = "UPDATE Repetitors SET FIO = @FIO, Phone_Number = @PhoneNumber, " +
                                   "Kvalification = @Kvalification, Predmets = @Predmet WHERE tutor_id = @IDTeacher";
            ExecuteQuery(changeCommand,
                         ("@FIO", TeacherFIO_TB.Text),
                         ("@PhoneNumber", RepNumberPhone_TBM.Text),
                         ("@Kvalification", Cvalification_TB.Text),
                         ("@Predmet", PridmetTeacher_CB.Text),
                         ("@IDTeacher", id_teacher));
            ClearTeacherFields();
            CreateColumns();
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTeachersToComboBox();
        }

        private void ClearButton3_Click(object sender, EventArgs e)
        {
            ClearTeacherFields();
        }

        // Метод для очистки полей формы для репетиторов
        private void ClearTeacherFields()
        {
            TeacherFIO_TB.Text = "";
            RepNumberPhone_TBM.Text = "";
            Cvalification_TB.Text = "";
            PridmetTeacher_CB.SelectedIndex = -1;
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функций для работы с расписанием занятий
        private void SearchApp4_ChangeText(object sender, EventArgs e)
        {
            string searchText = textBox4.Text.Trim();

            // Привязываем DataTable к DataGridView
            DataLearnDGV.DataSource = dataTable;

            if (dataTable != null)
            {
                // Устанавливаем фильтр по студенту и репетитору (поиск по строкам FIO студентов и репетиторов)
                dataTable.DefaultView.RowFilter = $"[Студент] LIKE '%{searchText}%' OR [Репетитор] LIKE '%{searchText}%'";
            }
        }

        public int selectIdStudent, selectIdTeacher;

        private void DataLearnDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = DataLearnDGV.Rows[selectdRow];

                    id_raspisanie = Convert.ToInt32(row.Cells[0].Value);
                    SelectScooler_CB.Text = row.Cells[1].Value.ToString();
                    SelectTeacher_CB.Text = row.Cells[2].Value.ToString();
                    DataZanytia_DTP.Text = row.Cells[3].Value.ToString();
                    Status_Zanyria_CB.Text = row.Cells[4].Value.ToString();

                    id_student = GetIDByNameStudent(SelectScooler_CB.Text);
                    id_teacher = GetIDByNameTeacher(SelectTeacher_CB.Text);

                }
                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DataZanytia_DTP.Text))
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                string delCommand = "DELETE FROM Raspisanie_Zaniyatiy WHERE schedule_id = @IDRaspis";
                ExecuteQuery(delCommand, ("@IDRaspis", id_raspisanie));

                Clear_Funk = true;

                ClearScheduleFields();
                CreateColumns();
                
                MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonNew4_Click(object sender, EventArgs e)
        {
            string addCommand = "INSERT INTO Raspisanie_Zaniyatiy (student_id, tutor_id, Time_Learn, Learn_Status) " +
                                "VALUES (@StudentID, @TeacherID, @TimeBegin, @LearnStatus)";

            id_student = GetIDByNameStudent(SelectScooler_CB.Text);
            id_teacher = GetIDByNameTeacher(SelectTeacher_CB.Text);

            ExecuteQuery(addCommand,
                         ("@StudentID", id_student),
                         ("@TeacherID", id_teacher),
                         ("@TimeBegin", DataZanytia_DTP.Text),
                         ("@LearnStatus", Status_Zanyria_CB.Text));

            Clear_Funk = true;

            ClearScheduleFields();
            CreateColumns();
            
            MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonChange4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectScooler_CB.Text) || string.IsNullOrEmpty(SelectTeacher_CB.Text) ||
                string.IsNullOrEmpty(DataZanytia_DTP.Text) || string.IsNullOrEmpty(Status_Zanyria_CB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string changeCommand = "UPDATE Raspisanie_Zaniyatiy SET student_id = @StudentID, tutor_id = @TeacherID, " +
                                   "Time_Learn = @TimeBegin, Learn_Status = @LearnStatus " +
                                   "WHERE schedule_id = @IDRaspis";

            id_student = GetIDByNameStudent(SelectScooler_CB.Text);
            id_teacher = GetIDByNameTeacher(SelectTeacher_CB.Text);

            ExecuteQuery(changeCommand,
                         ("@StudentID", id_student),
                         ("@TeacherID", id_teacher),
                         ("@TimeBegin", DataZanytia_DTP.Text),
                         ("@LearnStatus", Status_Zanyria_CB.Text),
                         ("@IDRaspis", id_raspisanie));

            Clear_Funk = true;

            ClearScheduleFields();
            CreateColumns();
            
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearButton4_Click(object sender, EventArgs e)
        {
            ClearScheduleFields();
        }

        // Метод для очистки полей формы расписания
        private void ClearScheduleFields()
        {
            SelectScooler_CB.SelectedIndex = -1;
            SelectTeacher_CB.SelectedIndex = -1;
            DataZanytia_DTP.Text = "";
            Status_Zanyria_CB.SelectedIndex = -1;
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функций для работы с предметами для учёбы
        private void SearchApp5_ChangeText(object sender, EventArgs e)
        {
            string searchQuery = "SELECT subject_id AS 'ID', Name_Pridment AS 'Названия предмета' " +
                                 "FROM Pridments WHERE Name_Pridment LIKE @SearchText";
            SearchUp(searchQuery, LearnThemeDGV, ("@SearchText", "%" + textBox5.Text + "%"));
        }

        private void LearnThemeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = LearnThemeDGV.Rows[selectdRow];
                    id_pridmet = Convert.ToInt32(row.Cells[0].Value);
                    NewPridmet_TB.Text = row.Cells[1].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewPridmet_TB.Text))
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                string delCommand = "DELETE FROM Pridments WHERE subject_id = @SubjectID";
                ExecuteQuery(delCommand, ("@SubjectID", id_pridmet));
                
                ClearSubjectFields();
                LoadSubjectsToComboBox();
                CreateColumns();
                
                MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonNew5_Click(object sender, EventArgs e)
        {
            string addCommand = "INSERT INTO Pridments (Name_Pridment) VALUES (@SubjectName)";
            ExecuteQuery(addCommand, ("@SubjectName", NewPridmet_TB.Text));
            
            ClearSubjectFields();
            LoadSubjectsToComboBox();
            CreateColumns();

            MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearButton5_Click(object sender, EventArgs e)
        {
            ClearSubjectFields();
        }

        // Метод для очистки полей формы для предметов
        private void ClearSubjectFields()
        {
            NewPridmet_TB.Text = "";
        }

//-----------------------------------------------------------------------------------------------------------------------------------------------------

        // Реализация функций для работы со статистикой оплаты занятий
        private void SearchApp6_ChangeText(object sender, EventArgs e)
        {
            string searchText = textBox6.Text.Trim();

            if (paymentDataTable != null)
            {
                // Устанавливаем фильтр для поиска по студенту и репетитору
                paymentDataTable.DefaultView.RowFilter = $"[Студент] LIKE '%{searchText}%' OR [Репетитор] LIKE '%{searchText}%'";
            }
        }

        private void PaymentDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = PaymentDGV.Rows[selectdRow];
                    id_payment = Convert.ToInt32(row.Cells[0].Value);
                    PayScoller_CB.Text = row.Cells[1].Value.ToString();
                    PayTeacher_CB.Text = row.Cells[2].Value.ToString();
                    Data_Pay_DTP.Text = row.Cells[3].Value.ToString();
                    ValuesRUB_TB.Text = row.Cells[4].Value.ToString();
                    PayStatus_CB.Text = row.Cells[5].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonDel6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PayScoller_CB.Text) || string.IsNullOrEmpty(PayTeacher_CB.Text))
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                string delCommand = "DELETE FROM Payment WHERE payment_id = @PaymentID";
                ExecuteQuery(delCommand, ("@PaymentID", id_payment));
                ClearPaymentFields();
                CreateColumns();
                MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonNew6_Click(object sender, EventArgs e)
        {
            string addCommand = "INSERT INTO Payment (student_id, tutor_id, Date_of_Payment, Summ_Payment, Status_Pay) " +
                                "VALUES (@StudentID, @TutorID, @PaymentDate, @PaymentSum, @StatusPay)";

            id_student = GetIDByNameStudent(PayScoller_CB.Text);
            id_teacher = GetIDByNameTeacher(PayTeacher_CB.Text);

            ExecuteQuery(addCommand,
                         ("@StudentID", id_student),
                         ("@TutorID", id_teacher),
                         ("@PaymentDate", Data_Pay_DTP.Text),
                         ("@PaymentSum", ValuesRUB_TB.Text),
                         ("@StatusPay", PayStatus_CB.Text)
                         );
            ClearPaymentFields();
            CreateColumns();
            MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonChange6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PayScoller_CB.Text) || string.IsNullOrEmpty(PayTeacher_CB.Text) ||
                string.IsNullOrEmpty(Data_Pay_DTP.Text) || string.IsNullOrEmpty(ValuesRUB_TB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string changeCommand = "UPDATE Payment SET student_id = @StudentID, tutor_id = @TutorID, " +
                                   "Date_of_Payment = @PaymentDate, Summ_Payment = @PaymentSum, Status_Pay = @StatusPay WHERE payment_id = @PaymentID";

            id_student = GetIDByNameStudent(PayScoller_CB.Text);
            id_teacher = GetIDByNameTeacher(PayTeacher_CB.Text);

            ExecuteQuery(changeCommand,
                         ("@StudentID", id_student),
                         ("@TutorID", id_student),
                         ("@PaymentDate", Data_Pay_DTP.Text),
                         ("@PaymentSum", ValuesRUB_TB.Text),
                         ("@StatusPay", PayStatus_CB.Text),

                         ("@PaymentID", id_payment));
            CreateColumns();
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearPaymentFields();
        }

        private void ClearButton6_Click(object sender, EventArgs e)
        {
            ClearPaymentFields();
        }


        private void DataZanytia_DTP_ValueChanged(object sender, EventArgs e)
        {
            // Проверяем, что выбранная дата меньше текущей
            if (DataZanytia_DTP.Value.Date < DateTime.Now.Date)
            {
                // Выводим сообщение об ошибке
                MessageBox.Show("Ошибка: Нельзя выбрать дату в прошлом. Установлена текущая дата.", "Ошибка даты", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Устанавливаем сегодняшнюю дату
                DataZanytia_DTP.Value = DateTime.Now.Date;
            }
        }

        private void DataLearnDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printCheck_button_Click(object sender, EventArgs e)
        {
            // Извлекаем данные из элементов управления
            string scroller = PayScoller_CB.SelectedItem?.ToString() ?? "Не указано";
            string teacher = PayTeacher_CB.SelectedItem?.ToString() ?? "Не указано";
            DateTime paymentDate = Data_Pay_DTP.Value; // Извлечение значения из DateTimePicker
            decimal amount;

            // Проверка суммы
            if (!decimal.TryParse(ValuesRUB_TB.Text, out amount))
            {
                MessageBox.Show("Введите корректную сумму!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Сохраняем чек
            SaveBeautifulReceipt(scroller, "Администратор школы", "410056, г. Саратов, ул. им. Пугачева Е.И., д.72", "Оплата за обучение",
                "Предоплата 100%", amount.ToString(), DateTime.Now.ToString("dd.MM.yyyy HH:mm"), "6");
        }

        public void SaveBeautifulReceipt(string cashierName, string adminRole, string organization,
                         string serviceType, string paymentMethod, string paymentAmount,
                         string paymentDate, string receiptNumber)
        {
            try
            {
                // Создаем документ PDF
                Document pdfDocument = new Document();
                Page page = pdfDocument.Pages.Add();

                // Устанавливаем стиль страницы
                page.PageInfo.Margin = new MarginInfo(20, 20, 20, 20);

                // Добавляем заголовок
                TextFragment header = new TextFragment($"КАССОВЫЙ ЧЕК № {receiptNumber}");
                header.TextState.FontSize = 14;
                header.TextState.FontStyle = FontStyles.Bold;
                header.TextState.ForegroundColor = Aspose.Pdf.Color.Blue;
                header.TextState.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                page.Paragraphs.Add(header);

                // Создаем объект Graph для линии
                Graph graph = new Graph(500, 20); // Ширина и высота графической области
                Line line = new Line(new float[] { 0, 0, 500, 0 })  // Координаты: от (0, 0) до (500, 0)
                {
                    GraphInfo = new GraphInfo
                    {
                        LineWidth = 1.5f,  // Толщина линии
                        Color = Aspose.Pdf.Color.Gray  // Цвет линии
                    }
                };
                graph.Shapes.Add(line);
                page.Paragraphs.Add(graph);

                // Добавляем дату и смену
                TextFragment dateShiftInfo = new TextFragment($"Дата: {paymentDate}\nСмена: 1\nКассир: {cashierName}");
                dateShiftInfo.TextState.FontSize = 10;
                page.Paragraphs.Add(dateShiftInfo);

                // Добавляем информацию об организации
                TextFragment organizationInfo = new TextFragment($"{organization}\nОбразовательные услуги");
                organizationInfo.TextState.FontSize = 10;
                page.Paragraphs.Add(organizationInfo);

                // Создаем объект Graph для линии
                Graph graph2 = new Graph(500, 20); // Ширина и высота графической области
                Line line2 = new Line(new float[] { 0, 0, 1500, 0 })  // Координаты: от (0, 0) до (500, 0)
                {
                    GraphInfo = new GraphInfo
                    {
                        LineWidth = 1.5f,  // Толщина линии
                        Color = Aspose.Pdf.Color.Gray  // Цвет линии
                    }
                };
                graph.Shapes.Add(line2);
                page.Paragraphs.Add(graph2);

                // Добавляем текст прихода
                TextFragment incomeHeader = new TextFragment("ПРИХОД");
                // Изменяем свойства существующего объекта TextState
                incomeHeader.TextState.FontSize = 12;
                incomeHeader.TextState.FontStyle = FontStyles.Bold;
                incomeHeader.TextState.ForegroundColor = Aspose.Pdf.Color.Blue;
                page.Paragraphs.Add(incomeHeader);

                // Добавляем таблицу для деталей платежа
                Table detailsTable = new Table
                {
                    ColumnWidths = "100 100",
                    DefaultCellTextState = new TextState { FontSize = 10 }
                };

                // Заголовок таблицы
                Row headerRow = detailsTable.Rows.Add();
                headerRow.Cells.Add("Описание");
                headerRow.Cells.Add("Сумма");

                // Данные таблицы
                Row dataRow1 = detailsTable.Rows.Add();
                dataRow1.Cells.Add($"Пополнение счета: {serviceType}");
                dataRow1.Cells.Add($"{paymentAmount} RUB");

                Row dataRow2 = detailsTable.Rows.Add();
                dataRow2.Cells.Add("ИТОГО:");
                dataRow2.Cells.Add($"{paymentAmount} RUB");

                page.Paragraphs.Add(detailsTable);

                // Сохраняем чек
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Сохранить чек как...";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        pdfDocument.Save(saveFileDialog.FileName);
                        MessageBox.Show("Чек успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении чека: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            SelectAndSendEmail selectAndSendEmail = new SelectAndSendEmail();
            selectAndSendEmail.ShowDialog();            
        }

        private void buttonPinTeacher_Click(object sender, EventArgs e)
        {
            TeacherEvaluationForm teacherEvaluationForm = new TeacherEvaluationForm();
            this.Hide();
            teacherEvaluationForm.ShowDialog();
            this.Show();
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            SelectAndSendEmail selectAndSendEmail = new SelectAndSendEmail();
            selectAndSendEmail.ShowDialog();
        }

        private void ValuesRUB_TB_TextChanged(object sender, EventArgs e)
        {
            string currentText = ValuesRUB_TB.Text;
            string newText = "";

            foreach (char c in currentText)
            {
                // Проверяем, является ли символ цифрой
                if (char.IsDigit(c))
                {
                    newText += c;
                }
            }

            // Если текст изменился, обновляем TextBox без недопустимых символов
            if (newText != currentText)
            {
                ValuesRUB_TB.Text = newText;
                ValuesRUB_TB.SelectionStart = newText.Length; // Перемещаем курсор в конец
            }
        }

        // Метод для очистки полей формы для оплаты
        private void ClearPaymentFields()
        {
            Clear_Funk = true;

            PayScoller_CB.SelectedIndex = -1;
            PayTeacher_CB.SelectedIndex = -1;
            Data_Pay_DTP.Text = "";
            ValuesRUB_TB.Text = "";
            PayStatus_CB.SelectedIndex = -1;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------

        private void FillPdfTableFromDataGridView(Aspose.Pdf.Table pdfTable, DataGridView dataGridView)
        {
            // Устанавливаем динамические ширины столбцов на основе содержимого DataGridView
            float[] columnWidths = new float[dataGridView.ColumnCount];
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                columnWidths[i] = dataGridView.Columns[i].Width / 5f; // Подбор ширины; можно изменить коэффициент, чтобы подстроить ширину
            }
            pdfTable.ColumnWidths = string.Join(" ", columnWidths);

            // Добавляем заголовок таблицы
            Aspose.Pdf.Row headerRow = pdfTable.Rows.Add();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                Aspose.Pdf.Cell headerCell = headerRow.Cells.Add(column.HeaderText);

                headerCell.BackgroundColor = Aspose.Pdf.Color.Gray;
                headerCell.DefaultCellTextState.ForegroundColor = Aspose.Pdf.Color.White;
                headerCell.DefaultCellTextState.FontSize = 12;
                //headerCell.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center;
                headerCell.VerticalAlignment = Aspose.Pdf.VerticalAlignment.Center; // Установка вертикального выравнивания
                headerCell.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 0.5f, Aspose.Pdf.Color.Black);
            }

            // Заполняем таблицу данными из DataGridView
            bool isAlternateRow = false;
            foreach (DataGridViewRow gridRow in dataGridView.Rows)
            {
                if (gridRow.IsNewRow) continue; // Пропускаем пустую строку для ввода

                Aspose.Pdf.Row pdfRow = pdfTable.Rows.Add();
                foreach (DataGridViewCell gridCell in gridRow.Cells)
                {
                    Aspose.Pdf.Cell cell = pdfRow.Cells.Add(gridCell.Value?.ToString() ?? string.Empty);
                    cell.DefaultCellTextState.FontSize = 10;
                    //cell.HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Left;
                    cell.VerticalAlignment = Aspose.Pdf.VerticalAlignment.Center; // Установка вертикального выравнивания для данных
                    cell.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, 0.5f, Aspose.Pdf.Color.Black);

                    // Альтернативный цвет для строк
                    if (isAlternateRow)
                    {
                        cell.BackgroundColor = Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray);
                    }
                }
                isAlternateRow = !isAlternateRow; // Чередуем цвет строк
            }

            // Настройки для таблицы
            pdfTable.DefaultCellPadding = new Aspose.Pdf.MarginInfo(5, 5, 5, 5); // Установка отступов в ячейках
            pdfTable.RepeatingRowsCount = 1; // Повтор заголовка таблицы на каждой новой странице
        }



        private void сохранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Настраиваем SaveFileDialog
            saveFileDialog1.Filter = "PDF Файл (*.pdf)|*.pdf";

            saveFileDialog1.FileName = "TableData.pdf";

            // Если пользователь выбрал путь для сохранения
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Создаем документ Aspose.PDF
                Document pdfDocument = new Document();
                Page pdfPage = pdfDocument.Pages.Add();
                Aspose.Pdf.Table pdfTable = new Aspose.Pdf.Table();

                // Определяем, какая вкладка выбрана
                if (TabMenu.SelectedTab == UserTab)
                {
                    FillPdfTableFromDataGridView(pdfTable, UsersDGV); // Сохранить таблицу пользователей
                }

                else if (TabMenu.SelectedTab == SrudentTab)
                {
                    FillPdfTableFromDataGridView(pdfTable, StudentDGV); // Сохранить таблицу студентов
                }
                else if (TabMenu.SelectedTab == RepetTab)
                {
                    FillPdfTableFromDataGridView(pdfTable, TeacherDGV); // Сохранить таблицу репетиторов
                }

                else if (TabMenu.SelectedTab == ScheduleTab)
                {
                    FillPdfTableFromDataGridView(pdfTable, DataLearnDGV); // Сохранить таблицу расписания
                }

                else if (TabMenu.SelectedTab == SubjectTab)
                {
                    FillPdfTableFromDataGridView(pdfTable, LearnThemeDGV); // Сохранить таблицу предметов
                }

                else if (TabMenu.SelectedTab == PaymentTab)
                {
                    FillPdfTableFromDataGridView(pdfTable, PaymentDGV); // Сохранить таблицу оплаты
                }

                // Добавляем таблицу в PDF-документ
                pdfPage.Paragraphs.Add(pdfTable);

                // Сохраняем документ по выбранному пути
                pdfDocument.Save(saveFileDialog1.FileName);
                MessageBox.Show("Таблица успешно сохранена в PDF!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.closeConnection();

            this.Close();
        }

        private void Admin_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataBase.closeConnection();
        }
    }
}