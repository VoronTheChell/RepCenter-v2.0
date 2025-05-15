using Aspose.Pdf;
using Aspose.Pdf.Text;
using System.Data;

namespace RepCenter_SupabaseEdition.Forms
{
    public partial class FormScoller : Form
    {
        int selectdRow;
        public FormScoller()
        {
            InitializeComponent();
            AppOptions();
            CreateColumns();
        }

        private void AppOptions()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            LoadSchedulesToGrid();
            LoadPaymentsToGrid();
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

        private void FillPdfTableFromDataGridView(Aspose.Pdf.Table pdfTable, DataGridView dgv)
        {
            pdfTable.DefaultCellPadding = new MarginInfo(5, 5, 5, 5);
            pdfTable.Border = new BorderInfo(BorderSide.All, 0.5f);
            pdfTable.DefaultCellBorder = new BorderInfo(BorderSide.All, 0.5f);
            pdfTable.RepeatingRowsCount = 1;
            pdfTable.DefaultColumnWidth = "100"; // базовая ширина колонок

            // Заголовки
            Aspose.Pdf.Row headerRow = pdfTable.Rows.Add();
            headerRow.DefaultCellTextState = new TextState("Arial", true, true);
            headerRow.BackgroundColor = Aspose.Pdf.Color.Gray;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                var cell = headerRow.Cells.Add(column.HeaderText);
                cell.Alignment = Aspose.Pdf.HorizontalAlignment.Center;
            }

            // Данные
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                Aspose.Pdf.Row dataRow = pdfTable.Rows.Add();
                dataRow.DefaultCellTextState = new TextState("Arial", 10);

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string value = cell.Value?.ToString() ?? string.Empty;
                    dataRow.Cells.Add(value);
                }
            }

            // Автоматическая ширина колонок по содержимому
            pdfTable.ColumnAdjustment = ColumnAdjustment.AutoFitToContent;
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

                    if (TabMenu.SelectedTab == TimeOfWorkPage)
                    {
                        FillPdfTableFromDataGridView(pdfTable, DataLearnDGV); // Сохранить таблицу расписания
                    }

                    else if (TabMenu.SelectedTab == PaymentPage)
                    {
                        FillPdfTableFromDataGridView(pdfTable, PaymentDGV); // Сохранить таблицу оплаты
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

        private void выйтиСАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
