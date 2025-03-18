using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;

using System.Windows.Forms;

namespace RepetBase_App.Forms
{
    public partial class StudentEvaluationForm : Form
    {
        DataBase dataBase = new DataBase();

        public StudentEvaluationForm()
        {
            InitializeComponent();

            LoadScoolersToComboBox();
            LoadSubjectsToComboBox();
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

        private void StudentEvaluationForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            SelectScooler_CB.DropDownStyle = ComboBoxStyle.DropDownList;
            PridmetSelect_CB.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void LoadScoolersToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            SelectScooler_CB.Items.Clear();

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
                }
            }
            dataBase.closeConnection();
        }

        public void LoadSubjectsToComboBox()
        {
            // Очищаем ComboBox перед заполнением
            PridmetSelect_CB.Items.Clear();

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
                    PridmetSelect_CB.Items.Add(reader["Name_Pridment"].ToString());
                }
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

        private void AskToExportGrade()
        {
            DialogResult result = MessageBox.Show(
                "Вы хотите распечатать или сохранить оценку учащегося?\n\n" +
                "Нажмите \"Да\" для сохранения в PDF, \"Нет\" для печати.",
                "Сохранение или печать оценки",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    SaveGradeToFile();
                    break;
                case DialogResult.No:
                    PrintGrade();
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("Действие отменено.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void SaveGradeToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Сохранить оценку"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                if (filePath.EndsWith(".pdf"))
                {
                    SaveToPdf(filePath);
                }

                MessageBox.Show("Файл успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveToPdf(string filePath)
        {
            // Создаем документ PDF
            var pdfDocument = new Aspose.Pdf.Document();
            var page = pdfDocument.Pages.Add();

            // Настраиваем шрифт и форматирование текста
            var textFragment = new Aspose.Pdf.Text.TextFragment("Оценка учащегося")
            {
                TextState =
        {
            FontSize = 16,
            Font = Aspose.Pdf.Text.FontRepository.FindFont("Arial"),
            FontStyle = Aspose.Pdf.Text.FontStyles.Bold
        }
            };
            page.Paragraphs.Add(textFragment);

            // Добавляем данные об оценке
            var studentInfo = new Aspose.Pdf.Text.TextFragment(
                $"Имя: {SelectScooler_CB.Text}\n" +
                $"Предмет: {PridmetSelect_CB.Text}\n" +
                $"Оценка: {valuesSucsses_TB.Value}/50 баллов.\n" +
                $"Комментарий: {plusDesc_TB.Text}"
            )
            {
                TextState =
        {
            FontSize = 12,
            Font = Aspose.Pdf.Text.FontRepository.FindFont("Arial")
        }
            };
            page.Paragraphs.Add(studentInfo);

            // Сохраняем PDF в файл
            pdfDocument.Save(filePath);

            MessageBox.Show($"Оценка успешно сохранена в PDF:\n{filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void PrintGrade()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                string gradeDetails = $"Результат обучение ученика:" +
                                      $"Имя: {SelectScooler_CB.Text}\n" +
                                      $"Предмет: {PridmetSelect_CB.Text}\n" +
                                      $"Оценка: {valuesSucsses_TB.Value}/50 баллов.\n" +
                                      $"Комментарий: {plusDesc_TB.Text}";
                e.Graphics.DrawString(gradeDetails, new System.Drawing.Font("Arial", 12), Brushes.Black, new PointF(100, 100));
            };

            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
                MessageBox.Show("Документ успешно отправлен на печать!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void buttonPublic_Click(object sender, EventArgs e)
        {
            int studentId = GetIDByNameStudent(SelectScooler_CB.Text); // ID ученика передается из основной формы
            string subject = PridmetSelect_CB.SelectedItem.ToString();
            decimal grade = valuesSucsses_TB.Value;
            string comments = plusDesc_TB.Text;

            dataBase.openConnection();

            string addCommandString = "INSERT INTO StudentGrades (StudentId, Subject, Grade, Comments) " +
                                      "VALUES (@StudentId, @Subject, @Grade, @Comments)";

            ExecuteQuery(addCommandString,
                            ("@StudentId", studentId),
                            ("@Subject", subject),
                            ("@Grade", grade),
                            ("@Comments", comments));

            dataBase.closeConnection();
            
            MessageBox.Show("Оценка успешно сохранена!");
            AskToExportGrade();

            this.Close();
        }

        private void valuesSucsses_TB_Scroll(object sender, EventArgs e)
        {
            var values = valuesSucsses_TB.Value;
            label5.Text = values.ToString();
        }

        
    }
}
