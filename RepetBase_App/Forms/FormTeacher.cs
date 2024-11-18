using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Aspose.Pdf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RepetBase_App
{
    public partial class FormTeacher : Form
    {
        DataBase dataBase = new DataBase();

        int selectdRow;
        int id_raspisanie, id_student, id_teacher;

        public DataTable paymentDataTable;

        public FormTeacher()
        {
            InitializeComponent();

            LoadScoolersToComboBox();
            LoadTeachersToComboBox();
        }

        private void FormTeacher_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = false;
            dataGridView3.ReadOnly = true;

            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            SelectStudent_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectTeacher_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusZanytia_CB.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadData();
        }

        private void LoadData()
        {
            CreateColumns_Students();
            CreateColumns_DataTime();
            CreateColumns_Payment();
        }

        // Метод для получения ID по выбранному имени
        private int GetIDByNameStudent(string selectedName)
        {
            id_student = -1; // Значение по умолчанию, если ID не найден

            try
            {
                dataBase.openConnection(); // Открываем подключение
                string query = "SELECT student_id FROM Student WHERE FIO = @Name";
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Name", selectedName);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        id_student = Convert.ToInt32(result);
                    }
                }
            }

            finally
            {
                dataBase.closeConnection(); // Закрываем подключение
            }

            return id_student;
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

        private void CreateColumns_Students()
        {
            using (SqlCommand com = new SqlCommand(@"SELECT student_id AS 'ID', FIO AS 'ФИО', Date_Birth AS 'Дата рождения', 
                                                 Number_Phone AS 'Номер телефона', Predmet AS 'Предмет для изучения' FROM Student", dataBase.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Student");
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void CreateColumns_DataTime()
        {
            using (SqlCommand com = new SqlCommand(@"SELECT r.schedule_id AS 'ID', s.FIO AS 'Ученик', t.FIO AS 'Учитель', r.Time_Learn AS 'Время начала занятия', 
                                                    r.Learn_Status AS 'Статус занятия' FROM Raspisanie_Zaniyatiy r JOIN Student s ON r.student_id = s.student_id 
                                                    JOIN Repetitors t ON r.tutor_id = t.tutor_id", dataBase.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Raspisanie_Zaniyatiy");
                dataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void CreateColumns_Payment()
        {
            using (SqlCommand com = new SqlCommand(@"SELECT p.payment_id AS 'ID', s.FIO AS 'Студент', t.FIO AS 'Репетитор', p.Date_of_Payment AS 'Дата оплаты', p.Summ_Payment AS 'Сумма оплаты', 
                                                    p.Status_Pay AS 'Статус оплаты' FROM Payment p JOIN Student s ON p.student_id = s.student_id JOIN Repetitors t ON p.tutor_id = t.tutor_id;", dataBase.GetConnection()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Payment");
                dataGridView3.DataSource = ds.Tables[0];
            }
        }

        private void SearchUpStudents(DataGridView DGV)
        {
            string searchapString = "SELECT student_id AS 'ID', FIO AS 'ФИО', Date_Birth AS 'Дата рождения', " +
                "Number_Phone AS 'Номер телефона', Predmet AS 'Предмет для изучения' FROM Student WHERE FIO LIKE @SearchText";

            using (SqlCommand com = new SqlCommand(searchapString, dataBase.GetConnection()))
            {
                com.Parameters.AddWithValue("@SearchText", "%" + textBox1.Text + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "applicant");
                DGV.DataSource = ds.Tables[0];
            }
        }

        private void SearchAppStudents_ChangeText(object sender, EventArgs e)
        {
            SearchUpStudents(dataGridView1);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView2.Rows[selectdRow];

                    id_raspisanie = Convert.ToInt32(row.Cells[0].Value);
                    SelectStudent_CB.Text = row.Cells[1].Value.ToString();
                    SelectTeacher_CB.Text = row.Cells[2].Value.ToString();
                    DateLearn_DTP.Text = row.Cells[3].Value.ToString();
                    StatusZanytia_CB.Text = row.Cells[4].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void LoadScoolersToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            SelectStudent_CB.Items.Clear();

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
                    SelectStudent_CB.Items.Add(reader["FIO"].ToString());
                }
            }
            dataBase.closeConnection();
        }

        public void LoadTeachersToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            SelectTeacher_CB.Items.Clear();

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
                }
            }
            dataBase.closeConnection();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectStudent_CB.Text) || string.IsNullOrEmpty(SelectTeacher_CB.Text) || string.IsNullOrEmpty(DateLearn_DTP.Text) || string.IsNullOrEmpty(StatusZanytia_CB.Text))
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                string delCommand = "DELETE FROM Raspisanie_Zaniyatiy WHERE schedule_id = @IDRaspis";
                ExecuteQuery(delCommand, ("@IDRaspis", id_raspisanie));
                ClearScheduleFields();
                CreateColumns_DataTime();
                MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            string addCommand = "INSERT INTO Raspisanie_Zaniyatiy (student_id, tutor_id, Time_Learn, Learn_Status) VALUES (@StudentID, @TutorID, @TimeBegin, @Learn_Status )";

            id_student = GetIDByNameStudent(SelectStudent_CB.Text);
            id_teacher = GetIDByNameTeacher(SelectTeacher_CB.Text);

            ExecuteQuery(addCommand, ("@StudentID", id_student), ("@TutorID", id_teacher), ("@TimeBegin", DateLearn_DTP.Text), ("@Learn_Status ", StatusZanytia_CB.Text));
            ClearScheduleFields();
            CreateColumns_DataTime();
            MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SelectStudent_CB.Text) || string.IsNullOrEmpty(SelectTeacher_CB.Text) || string.IsNullOrEmpty(DateLearn_DTP.Text) || string.IsNullOrEmpty(StatusZanytia_CB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string changeCommand = "UPDATE Raspisanie_Zaniyatiy SET student_id = @StudentID, tutor_id = @TutorID, Time_Learn = @TimeBegin, Learn_Status = @Learn_Status  WHERE schedule_id = @IDRaspis";

            id_student = GetIDByNameStudent(SelectStudent_CB.Text);
            id_teacher = GetIDByNameTeacher(SelectTeacher_CB.Text);

            ExecuteQuery(changeCommand, ("@StudentID", id_student), ("@TutorID", id_teacher), ("@TimeBegin", DateLearn_DTP.Text), ("@Learn_Status", StatusZanytia_CB.Text), ("@IDRaspis", id_raspisanie));
            ClearScheduleFields();
            CreateColumns_DataTime();
            MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearScheduleFields()
        {
            SelectStudent_CB.SelectedIndex = -1;
            SelectTeacher_CB.SelectedIndex = -1;
            DateLearn_DTP.Text = "";
            StatusZanytia_CB.SelectedIndex = -1;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            // Настраиваем SaveFileDialog
            saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog1.Title = "Сохранить таблицу как PDF";
            saveFileDialog1.FileName = "TableData.pdf";

            // Если пользователь выбрал путь для сохранения
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Создаем документ Aspose.PDF
                Document pdfDocument = new Document();
                Aspose.Pdf.Page pdfPage = pdfDocument.Pages.Add();
                Aspose.Pdf.Table pdfTable = new Aspose.Pdf.Table();

                // Определяем, какая вкладка выбрана
                if (tabControl1.SelectedTab == StudentPage)
                {
                    FillPdfTableFromDataGridView(pdfTable, dataGridView1);
                }

                else if (tabControl1.SelectedTab == TimeOfWorkPage)
                {
                    FillPdfTableFromDataGridView(pdfTable, dataGridView2); 
                }
                else if (tabControl1.SelectedTab == PaymentPage)
                {
                    FillPdfTableFromDataGridView(pdfTable, dataGridView3); 
                }

                // Добавляем таблицу в PDF-документ
                pdfPage.Paragraphs.Add(pdfTable);

                // Сохраняем документ по выбранному пути
                pdfDocument.Save(saveFileDialog1.FileName);
                MessageBox.Show("Таблица успешно сохранена в PDF!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FillPdfTableFromDataGridView(Aspose.Pdf.Table pdfTable, DataGridView dataGridView)
        {
            pdfTable.ColumnWidths = string.Join(" ", Array.ConvertAll(new int[dataGridView.ColumnCount], _ => "100"));

            // Добавляем заголовок таблицы
            Aspose.Pdf.Row headerRow = pdfTable.Rows.Add();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                Aspose.Pdf.Cell headerCell = headerRow.Cells.Add(column.HeaderText);
                headerCell.BackgroundColor = Aspose.Pdf.Color.Gray;
                headerCell.DefaultCellTextState.ForegroundColor = Aspose.Pdf.Color.White;
            }

            // Заполняем таблицу данными из DataGridView
            foreach (DataGridViewRow gridRow in dataGridView.Rows)
            {
                Aspose.Pdf.Row pdfRow = pdfTable.Rows.Add();
                foreach (DataGridViewCell gridCell in gridRow.Cells)
                {
                    pdfRow.Cells.Add(gridCell.Value?.ToString() ?? string.Empty);
                }
            }
        }

        private void выйтиИзПрофиляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.closeConnection();

            this.Close();
        }
    }
}
