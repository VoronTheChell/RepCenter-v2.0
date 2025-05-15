using System.Data;
using Aspose.Pdf;
using Aspose.Pdf.Drawing;
using Aspose.Pdf.Text;

namespace RepCenter_SupabaseEdition.Forms
{
    public partial class FormTeacher : Form
    {
        int selectdRow, id_raspisanie;
        public FormTeacher()
        {
            InitializeComponent();
            AppOptions();
            CreateColumns();
        }

        // -------------------- Options\Loading Data -------------------- //
        private void AppOptions()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            SelectStudent_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            StatusZanytia_CB.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CreateColumns()
        {
            LoadStudentsToGrid();
            LoadSchedulesToGrid();
            LoadPaymentsToGrid();

            LoadScoolersToComboBox();
        }

        public async void LoadScoolersToComboBox()
        {
            SelectStudent_CB.Items.Clear();

            var service = new SupabaseService();
            await service.InitAsync();

            var response = await service.GetAllStudentsAsync();

            if (response == null || response.Count == 0)
            {
                MessageBox.Show("Список предметов пуст или не загружен.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var student in response)
            {
                SelectStudent_CB.Items.Add(student.FIO);

            }
        }
        private async void LoadStudentsToGrid()
        {
            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var students = await service.GetAllStudentsAsync();

                StudentDGV.DataSource = students.Select(s => new
                {
                    s.StudentId,
                    s.FIO,
                    s.DateBirth,
                    s.NumberPhone,
                    s.EmailAdress,
                    s.Predmet
                }).ToList();

                StudentDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                StudentDGV.Columns["StudentId"].HeaderText = "ID";
                StudentDGV.Columns["FIO"].HeaderText = "ФИО";
                StudentDGV.Columns["DateBirth"].HeaderText = "Дата рождения";
                StudentDGV.Columns["NumberPhone"].HeaderText = "Телефон";
                StudentDGV.Columns["EmailAdress"].HeaderText = "Эл. почта";
                StudentDGV.Columns["Predmet"].HeaderText = "Предмет";

                StudentDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn col in StudentDGV.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }


                StudentDGV.Columns[StudentDGV.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке студентов: " + ex.Message);
            }
        }
        private async void LoadSchedulesToGrid()
        {
            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var schedules = await service.GetAllSchedulesAsync();
                var students = await service.GetAllStudentsAsync();
                var tutors = await service.GetAllTutorsAsync();

                DataLearnDGV.DataSource = schedules.Select(s =>
                {
                    var student = students.FirstOrDefault(st => st.StudentId == s.StudentId);
                    var tutor = tutors.FirstOrDefault(t => t.TutorId == s.TutorId);

                    return new
                    {
                        ID = s.ScheduleId,
                        Студент = student?.FIO ?? $"ID {s.StudentId}",
                        Репетитор = tutor?.FIO ?? $"ID {s.TutorId}",
                        Время_занятий = s.TimeLearn,
                        Статус_занятия = s.LearnStatus
                    };
                }).ToList();

                // Автостилизация
                DataLearnDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn col in DataLearnDGV.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

                DataLearnDGV.Columns[DataLearnDGV.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке расписания: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void LoadPaymentsToGrid()
        {
            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var payments = await service.GetAllPaymentsAsync();
                var students = await service.GetAllStudentsAsync();
                var tutors = await service.GetAllTutorsAsync();

                var view = payments.Select(p =>
                {
                    var student = students.FirstOrDefault(s => s.StudentId == p.StudentId);
                    var tutor = tutors.FirstOrDefault(t => t.TutorId == p.TutorId);

                    return new
                    {
                        ID = p.PaymentId,
                        Студент = student?.FIO ?? $"ID {p.StudentId}",
                        Репетитор = tutor?.FIO ?? $"ID {p.TutorId}",
                        Дата_оплаты = p.DateOfPayment,
                        Стоимость = $"{p.SummPayment:C0}",
                        Статус = p.StatusPay
                    };
                }).ToList();

                PaymentDGV.DataSource = view;
                PaymentDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn col in PaymentDGV.Columns)
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                PaymentDGV.Columns[^1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке платежей: " + ex.Message);
            }
        }

        private void DataLearnDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = DataLearnDGV.Rows[selectdRow];

                    id_raspisanie = Convert.ToInt32(row.Cells[0].Value);
                    SelectStudent_CB.Text = row.Cells[1].Value.ToString();
                    DateLearn_DTP.Text = row.Cells[2].Value.ToString();
                    StatusZanytia_CB.Text = row.Cells[3].Value.ToString();
                }
                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void оценкаУспеваемостиУченикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentEvaluationForm studentEvaluationForm = new StudentEvaluationForm();
            this.Hide();
            studentEvaluationForm.ShowDialog();
            this.Show();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PDF Файл (*.pdf)|*.pdf";

            saveFileDialog1.FileName = "TableData.pdf";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipTitle = "Пожалуйста подождите!";
                    notifyIcon1.BalloonTipText = "Выполняеться сохранение файла....";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.ShowBalloonTip(350);

                    Document pdfDocument = new Document();
                    Page pdfPage = pdfDocument.Pages.Add();
                    Aspose.Pdf.Table pdfTable = new Aspose.Pdf.Table();

                    // Определяем, какая вкладка выбрана
                    if (TabMenu.SelectedTab == StudentPage)
                    {
                        FillPdfTableFromDataGridView(pdfTable, StudentDGV); // Сохранить таблицу пользователей
                    }

                    else if (TabMenu.SelectedTab == TimeOfWorkPage)
                    {
                        FillPdfTableFromDataGridView(pdfTable, DataLearnDGV); // Сохранить таблицу студентов
                    }

                    else if (TabMenu.SelectedTab == PaymentPage)
                    {
                        FillPdfTableFromDataGridView(pdfTable, PaymentDGV); // Сохранить таблицу репетиторов
                    }

                    // Добавляем таблицу в PDF-документ
                    pdfPage.Paragraphs.Add(pdfTable);

                    // Сохраняем документ по выбранному пути
                    pdfDocument.Save(saveFileDialog1.FileName);
                    MessageBox.Show("Таблица успешно сохранена в PDF!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("При сохранении файла произошла ошибка:\n" + ex, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
            this.Close();
        }
    }
}
