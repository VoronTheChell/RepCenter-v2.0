using Aspose.Pdf;
using Aspose.Pdf.Drawing;
using Aspose.Pdf.Text;
using System.Data;

namespace RepCenter_SupabaseEdition.Forms
{
    public partial class Admin_Form : Form
    {
        public int selectdRow;

        public int id_users, id_student,
                   id_teacher, id_raspisanie,
                   id_pridmet, id_payment;

        public bool Clear_Funk = false;

        public bool valueTake = false;

        public Admin_Form()
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
            LoadUsersToGrid();
            LoadStudentsToGrid();
            LoadTutorsToGrid();
            LoadSubjectsToGrid();
            LoadSchedulesToGrid();
            LoadPaymentsToGrid();

            LoadScoolersToComboBox();
            LoadTeachersToComboBox();
            LoadSubjectsToComboBox();
        }

        // --------------------------------- Loading Data ------------------------------------------ //
        public async void LoadScoolersToComboBox()
        {
            SelectScooler_CB.Items.Clear();
            PayScoller_CB.Items.Clear();

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
                SelectScooler_CB.Items.Add(student.FIO);
                PayScoller_CB.Items.Add(student.FIO);
            }
        }

        public async void LoadTeachersToComboBox()
        {
            SelectTeacher_CB.Items.Clear();
            PayTeacher_CB.Items.Clear();

            var service = new SupabaseService();
            await service.InitAsync();

            var response = await service.GetAllTutorsAsync();

            if (response == null || response.Count == 0)
            {
                MessageBox.Show("Список предметов пуст или не загружен.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var tutor in response)
            {
                SelectTeacher_CB.Items.Add(tutor.FIO);
                PayTeacher_CB.Items.Add(tutor.FIO);
            }
        }

        private async void LoadSubjectsToComboBox()
        {
            Users_Primary_CB.Items.Clear();
            Pridmets_CB.Items.Clear();
            PridmetTeacher_CB.Items.Clear();

            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var subjects = await service.GetAllSubjectsAsync();

                if (subjects == null || subjects.Count == 0)
                {
                    MessageBox.Show("Список предметов пуст или не загружен.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (var subject in subjects)
                {
                    Users_Primary_CB.Items.Add(subject.NamePridment);
                    Pridmets_CB.Items.Add(subject.NamePridment);
                    PridmetTeacher_CB.Items.Add(subject.NamePridment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке предметов: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadUsersToGrid()
        {
            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var users = await service.GetAllUsersAsync();

                // Подключение списка как источника данных
                UsersDGV.DataSource = users.Select(u => new
                {
                    u.IdUser,
                    u.LoginUser,
                    u.PasswordUser,
                    u.SubjectUser,
                    u.StatusUser
                }).ToList(); // Можно фильтровать или переименовать поля здесь

                UsersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                UsersDGV.Columns["IdUser"].HeaderText = "ID";
                UsersDGV.Columns["LoginUser"].HeaderText = "Логин";
                UsersDGV.Columns["PasswordUser"].HeaderText = "Хэш пароля";
                UsersDGV.Columns["SubjectUser"].HeaderText = "Название предмета";
                UsersDGV.Columns["StatusUser"].HeaderText = "Тип пользователя";

                UsersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn col in UsersDGV.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }


                UsersDGV.Columns[UsersDGV.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке пользователей: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void LoadTutorsToGrid()
        {
            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var tutors = await service.GetAllTutorsAsync();

                TeacherDGV.DataSource = tutors.Select(t => new
                {
                    t.TutorId,
                    t.FIO,
                    t.PhoneNumber,
                    t.Kvalification,
                    t.Predmets
                }).ToList();

                TeacherDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                TeacherDGV.Columns["TutorId"].HeaderText = "ID";
                TeacherDGV.Columns["FIO"].HeaderText = "ФИО";
                TeacherDGV.Columns["PhoneNumber"].HeaderText = "Номер телефона";
                TeacherDGV.Columns["Kvalification"].HeaderText = "Квалификация";
                TeacherDGV.Columns["Predmets"].HeaderText = "Предмет";

                TeacherDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn col in TeacherDGV.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }


                TeacherDGV.Columns[TeacherDGV.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке репетиторов: " + ex.Message);
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

        private async void LoadSubjectsToGrid()
        {
            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var subjects = await service.GetAllSubjectsAsync();

                LearnThemeDGV.DataSource = subjects.Select(s => new
                {
                    s.SubjectId,
                    s.NamePridment
                }).ToList();

                LearnThemeDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                LearnThemeDGV.Columns["SubjectId"].HeaderText = "ID";
                LearnThemeDGV.Columns["NamePridment"].HeaderText = "Названия предмета";

                LearnThemeDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                foreach (DataGridViewColumn col in LearnThemeDGV.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }


                LearnThemeDGV.Columns[LearnThemeDGV.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке предметов: " + ex.Message);
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

        // ------------------------------- CellClick Logic ------------------------------------ //

        private void UsersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= UsersDGV.Rows.Count)
                return;

            try
            {
                selectdRow = e.RowIndex;

                DataGridViewRow row = UsersDGV.Rows[selectdRow];

                // Получение значений из DataGridView
                var idValue = row.Cells["IdUser"].Value?.ToString();
                var login = row.Cells["LoginUser"].Value?.ToString();
                var subject = row.Cells["SubjectUser"].Value?.ToString();
                var status = row.Cells["StatusUser"].Value?.ToString();

                if (int.TryParse(idValue, out int parsedId))
                    id_users = parsedId;
                else
                    id_users = -1;

                UserLogin_TB.Text = login ?? "";
                UserPass_TB.Text = "******"; // Хэш не отображаем

                Users_Primary_CB.Text = subject ?? "";
                TypeOfUser_CB.Text = status ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе строки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void DataLearnDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectdRow = e.RowIndex;

            valueTake = true;

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

                }
                catch
                {
                    MessageBox.Show("Вы выбрали пустую строчку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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

        // ---------------------------------- Users Buttons -------------------------------------- //

        private async void buttonDel_Click(object sender, EventArgs e)
        {
            if (id_users == -1)
            {
                MessageBox.Show("Не выбрана запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var result = await service.DeleteUserAsync(id_users);

                if (result)
                {
                    ClearUserFields();
                    LoadUsersToGrid();
                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void buttonNew_Click(object sender, EventArgs e)
        {
            var service = new SupabaseService();
            await service.InitAsync();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(UserPass_TB.Text);

            var newUser = new Register
            {
                LoginUser = UserLogin_TB.Text,
                PasswordUser = hashedPassword,
                SubjectUser = Users_Primary_CB.Text,
                StatusUser = TypeOfUser_CB.Text
            };

            var result = await service.AddUserAsync(newUser);

            if (result)
            {
                ClearUserFields();
                LoadUsersToGrid();
                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonChange_Click(object sender, EventArgs e)
        {
            if (id_users == -1)
            {
                MessageBox.Show("Сначала выберите запись для редактирования!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var service = new SupabaseService();
            await service.InitAsync();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(UserPass_TB.Text);

            var updatedUser = new Register
            {
                IdUser = id_users,
                LoginUser = UserLogin_TB.Text,
                PasswordUser = hashedPassword,
                SubjectUser = Users_Primary_CB.Text,
                StatusUser = TypeOfUser_CB.Text
            };

            var result = await service.UpdateUserAsync(updatedUser);

            if (result)
            {
                ClearUserFields();
                LoadUsersToGrid();
                MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при изменении записи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton1_Click(object sender, EventArgs e)
        {
            ClearUserFields();
            UsersDGV.Update();
        }

        private void ClearUserFields()
        {
            UserLogin_TB.Text = "";
            UserPass_TB.Text = "";
            Users_Primary_CB.SelectedIndex = -1;
            TypeOfUser_CB.SelectedIndex = -1;
        }

        // ---------------------------------- Student Buttons ------------------------------------- //

        private async void buttonDel2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FIO_Student_TB.Text))
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var result = await service.DeleteStudentAsync(id_student);

                if (result)
                {
                    ClearStudentFields();
                    LoadStudentsToGrid();
                    LoadScoolersToComboBox();
                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении записи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void buttonNew2_Click(object sender, EventArgs e)
        {
            var service = new SupabaseService();
            await service.InitAsync();

            var student = new Student
            {
                FIO = FIO_Student_TB.Text,
                DateBirth = StudentDataTime_TBM.Text,
                NumberPhone = StudentNumberPhone_TBM.Text,
                EmailAdress = emailValues_TB.Text,
                Predmet = Pridmets_CB.Text
            };

            var result = await service.AddStudentAsync(student);

            if (result)
            {
                ClearStudentFields();
                LoadStudentsToGrid();
                LoadScoolersToComboBox();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при создании записи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonChange2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FIO_Student_TB.Text) ||
                string.IsNullOrWhiteSpace(StudentNumberPhone_TBM.Text) ||
                string.IsNullOrWhiteSpace(Pridmets_CB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var service = new SupabaseService();
            await service.InitAsync();

            var student = new Student
            {
                StudentId = id_student,
                FIO = FIO_Student_TB.Text,
                DateBirth = StudentDataTime_TBM.Text,
                NumberPhone = StudentNumberPhone_TBM.Text,
                EmailAdress = emailValues_TB.Text,
                Predmet = Pridmets_CB.Text
            };

            var result = await service.UpdateStudentAsync(student);

            if (result)
            {
                ClearStudentFields();
                LoadUsersToGrid();
                LoadScoolersToComboBox();
                MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении записи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            ClipUserStudent сlipUserStudent = new ClipUserStudent();
            сlipUserStudent.ShowDialog();
        }

        private void ClearButton2_Click(object sender, EventArgs e)
        {
            ClearStudentFields();
        }

        private void ClearStudentFields()
        {
            FIO_Student_TB.Text = "";
            StudentDataTime_TBM.Text = "";
            StudentNumberPhone_TBM.Text = "";
            Pridmets_CB.SelectedIndex = -1;
        }

        // --------------------------------- Repetitors Buttons ----------------------------------- //

        private async void buttonDel3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeacherFIO_TB.Text))
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var result = await service.DeleteTutorAsync(id_teacher);

                if (result)
                {
                    ClearTeacherFields();
                    LoadTutorsToGrid();
                    LoadTutorsToGrid();
                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении записи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void buttonNew3_Click(object sender, EventArgs e)
        {
            var service = new SupabaseService();
            await service.InitAsync();

            var tutor = new Repetitors
            {
                FIO = TeacherFIO_TB.Text,
                PhoneNumber = RepNumberPhone_TBM.Text,
                Kvalification = Cvalification_TB.Text,
                Predmets = PridmetTeacher_CB.Text
            };

            var result = await service.AddTutorAsync(tutor);

            if (result)
            {
                ClearTeacherFields();
                LoadTutorsToGrid();
                LoadTutorsToGrid();
                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при создании записи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonChange3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TeacherFIO_TB.Text) ||
                string.IsNullOrWhiteSpace(RepNumberPhone_TBM.Text) ||
                string.IsNullOrWhiteSpace(Cvalification_TB.Text) ||
                string.IsNullOrWhiteSpace(PridmetTeacher_CB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var service = new SupabaseService();
            await service.InitAsync();

            var tutor = new Repetitors
            {
                TutorId = id_teacher,
                FIO = TeacherFIO_TB.Text,
                PhoneNumber = RepNumberPhone_TBM.Text,
                Kvalification = Cvalification_TB.Text,
                Predmets = PridmetTeacher_CB.Text
            };

            var result = await service.UpdateTutorAsync(tutor);

            if (result)
            {
                ClearTeacherFields();
                LoadTutorsToGrid();
                LoadTutorsToGrid();
                MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении записи!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPinTeacher_Click(object sender, EventArgs e)
        {
            TeacherEvaluationForm teacherEvaluationForm = new TeacherEvaluationForm();
            this.Hide();
            teacherEvaluationForm.ShowDialog();
            this.Show();
        }

        private void ClearButton3_Click(object sender, EventArgs e)
        {
            ClearTeacherFields();
        }

        private void ClearTeacherFields()
        {
            TeacherFIO_TB.Text = "";
            RepNumberPhone_TBM.Text = "";
            Cvalification_TB.Text = "";
            PridmetTeacher_CB.SelectedIndex = -1;
        }

        // ------------------------------ Raspisanie Buttons -------------------------------------- //

        private async void buttonDel4_Click(object sender, EventArgs e)
        {
            if (id_raspisanie == -1)
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                var service = new SupabaseService();
                await service.InitAsync();

                valueTake = false;

                var result = await service.DeleteScheduleAsync(id_raspisanie);

                if (result)
                {
                    Clear_Funk = true;
                    ClearScheduleFields();
                    LoadSchedulesToGrid();
                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void buttonNew4_Click(object sender, EventArgs e)
        {
            var service = new SupabaseService();
            await service.InitAsync();

            valueTake = false;

            int studentId = await service.GetIDByNameStudentAsync(SelectScooler_CB.Text);
            int tutorId = await service.GetIDByNameTeacherAsync(SelectTeacher_CB.Text);

            var schedule = new RaspisanieZaniyatiy
            {
                StudentId = studentId,
                TutorId = tutorId,
                TimeLearn = DataZanytia_DTP.Text,
                LearnStatus = Status_Zanyria_CB.Text
            };

            var result = await service.AddScheduleAsync(schedule);

            if (result)
            {
                Clear_Funk = true;
                ClearScheduleFields();
                LoadSchedulesToGrid();
                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при создании записи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonChange4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectScooler_CB.Text) ||
                string.IsNullOrWhiteSpace(SelectTeacher_CB.Text) ||
                string.IsNullOrWhiteSpace(Status_Zanyria_CB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var service = new SupabaseService();
            await service.InitAsync();

            valueTake = false;

            int studentId = await service.GetIDByNameStudentAsync(SelectScooler_CB.Text);
            int tutorId = await service.GetIDByNameTeacherAsync(SelectTeacher_CB.Text);

            var schedule = new RaspisanieZaniyatiy
            {
                ScheduleId = id_raspisanie,
                StudentId = studentId,
                TutorId = tutorId,
                TimeLearn = DataZanytia_DTP.Text,
                LearnStatus = Status_Zanyria_CB.Text
            };

            var result = await service.UpdateScheduleAsync(schedule);

            if (result)
            {
                Clear_Funk = true;
                ClearScheduleFields();
                LoadSchedulesToGrid();
                MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении записи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton4_Click(object sender, EventArgs e)
        {
            valueTake = false;
            ClearScheduleFields();
        }

        private void ClearScheduleFields()
        {
            SelectScooler_CB.SelectedIndex = -1;
            SelectTeacher_CB.SelectedIndex = -1;
            DataZanytia_DTP.Text = "";
            Status_Zanyria_CB.SelectedIndex = -1;
        }

        // --------------------------- Disciplina Buttons ---------------------------------------- //

        private async void buttonDel5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewPridmet_TB.Text))
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var result = await service.DeleteSubjectAsync(id_pridmet);

                if (result)
                {
                    ClearSubjectFields();
                    LoadSubjectsToComboBox();
                    LoadSubjectsToComboBox();
                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void buttonNew5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewPridmet_TB.Text))
            {
                MessageBox.Show("Введите название предмета!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var service = new SupabaseService();
            await service.InitAsync();

            var subject = new Pridments
            {
                NamePridment = NewPridmet_TB.Text
            };

            var result = await service.AddSubjectAsync(subject);

            if (result)
            {
                ClearSubjectFields();
                LoadSubjectsToComboBox();
                LoadSubjectsToGrid();
                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении записи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton5_Click(object sender, EventArgs e)
        {
            ClearSubjectFields();
        }

        private void ClearSubjectFields()
        {
            NewPridmet_TB.Text = "";
        }

        // ------------------------------- Pay Learn Buttons --------------------------------------- //

        private async void buttonDel6_Click(object sender, EventArgs e)
        {
            if (id_payment == -1)
            {
                MessageBox.Show("Отсутствует выбранная запись для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult qtdel = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (qtdel == DialogResult.Yes)
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var result = await service.DeletePaymentAsync(id_payment);

                if (result)
                {
                    ClearPaymentFields();
                    LoadSubjectsToComboBox();
                    MessageBox.Show("Запись успешно удалена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении оплаты.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void buttonNew6_Click(object sender, EventArgs e)
        {
            var service = new SupabaseService();
            await service.InitAsync();

            int studentId = await service.GetIDByNameStudentAsync(PayScoller_CB.Text);
            int tutorId = await service.GetIDByNameTeacherAsync(PayTeacher_CB.Text);

            var payment = new Payment
            {
                StudentId = studentId,
                TutorId = tutorId,
                DateOfPayment = Data_Pay_DTP.Text,
                SummPayment = int.Parse(ValuesRUB_TB.Text),
                StatusPay = PayStatus_CB.Text
            };

            var result = await service.AddPaymentAsync(payment);

            if (result)
            {
                ClearPaymentFields();
                LoadSubjectsToComboBox();
                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при создании оплаты.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonChange6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PayScoller_CB.Text) ||
                string.IsNullOrWhiteSpace(PayTeacher_CB.Text) ||
                string.IsNullOrWhiteSpace(ValuesRUB_TB.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var service = new SupabaseService();
            await service.InitAsync();

            int studentId = await service.GetIDByNameStudentAsync(PayScoller_CB.Text);
            int tutorId = await service.GetIDByNameTeacherAsync(PayTeacher_CB.Text);

            var payment = new Payment
            {
                PaymentId = id_payment,
                StudentId = studentId,
                TutorId = tutorId,
                DateOfPayment = Data_Pay_DTP.Text,
                SummPayment = int.Parse(ValuesRUB_TB.Text),
                StatusPay = PayStatus_CB.Text
            };

            var result = await service.UpdatePaymentAsync(payment);

            if (result)
            {
                ClearPaymentFields();
                LoadPaymentsToGrid();
                MessageBox.Show("Запись успешно изменена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении оплаты.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton6_Click(object sender, EventArgs e)
        {
            ClearPaymentFields();
        }

        private void DataZanytia_DTP_ValueChanged(object sender, EventArgs e)
        {
            if (valueTake == true)
            {
                return;
            }
            
            // Проверяем, что выбранная дата меньше текущей
            if (DataZanytia_DTP.Value.Date < DateTime.Now.Date)
            {
                // Выводим сообщение об ошибке
                MessageBox.Show("Ошибка: Нельзя выбрать дату в прошлом. Установлена текущая дата.", "Ошибка даты", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Устанавливаем сегодняшнюю дату
                DataZanytia_DTP.Value = DateTime.Now.Date;
            }
        }

        private void printCheck_button_Click(object sender, EventArgs e)
        {
            var scroller = PayScoller_CB.SelectedItem?.ToString() ?? "Не указано";
            var teacher = PayTeacher_CB.SelectedItem?.ToString() ?? "Не указано";
            var paymentDate = Data_Pay_DTP.Value;

            if (!decimal.TryParse(ValuesRUB_TB.Text, out var amount))
            {
                MessageBox.Show("Введите корректную сумму!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveBeautifulReceipt(
                scroller,
                "Администратор школы",
                "410056, г. Саратов, ул. им. Пугачева Е.И., д.72",
                "Оплата за обучение",
                "Предоплата 100%",
                amount.ToString(),
                DateTime.Now.ToString("dd.MM.yyyy HH:mm"),
                "6"
            );
        }

        public void SaveBeautifulReceipt(string cashierName, string adminRole, string organization,
                         string serviceType, string paymentMethod, string paymentAmount,
                         string paymentDate, string receiptNumber)
        {
            try
            {
                var pdfDocument = new Document();
                var page = pdfDocument.Pages.Add();
                page.PageInfo.Margin = new MarginInfo(20, 20, 20, 20);

                AddHeader(page, $"\nКАССОВЫЙ ЧЕК № {receiptNumber}");
                AddSeparator(page);
                AddText(page, $"\nДата: {paymentDate}\nСмена: 1\nКассир: {cashierName}");
                AddText(page, $"{organization}\nОбразовательные услуги");
                AddSeparator(page);
                AddHeader(page, "\nИТОГ", 12);

                var detailsTable = new Table
                {
                    ColumnWidths = "100 100",
                    DefaultCellTextState = new TextState { FontSize = 10 }
                };

                AddTableRow(detailsTable, "Описание", "Сумма");
                AddTableRow(detailsTable, $"Пополнение счета: {serviceType}", $"{paymentAmount} RUB");
                AddTableRow(detailsTable, "ИТОГО:", $"{paymentAmount} RUB");

                page.Paragraphs.Add(detailsTable);

                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Сохранить чек как..."
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pdfDocument.Save(saveFileDialog.FileName);
                    MessageBox.Show("Чек успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении чека: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddHeader(Page page, string text, int fontSize = 14)
        {
            var header = new TextFragment(text)
            {
                TextState =
        {
            FontSize = fontSize,
            FontStyle = FontStyles.Bold,
            ForegroundColor = Aspose.Pdf.Color.Blue,
            HorizontalAlignment = Aspose.Pdf.HorizontalAlignment.Center
        }
            };
            page.Paragraphs.Add(header);
        }

        private void AddText(Page page, string text, int fontSize = 10)
        {
            var fragment = new TextFragment(text)
            {
                TextState = { FontSize = fontSize }
            };
            page.Paragraphs.Add(fragment);
        }

        private void AddSeparator(Page page)
        {
            var graph = new Graph(500.0, 20.0); // Используем double
            var line = new Line(new[] { 0.0f, 0.0f, 500.0f, 0.0f })
            {
                GraphInfo = new GraphInfo
                {
                    LineWidth = 1.5f,
                    Color = Aspose.Pdf.Color.Gray
                }
            };
            graph.Shapes.Add(line);
            page.Paragraphs.Add(graph);
        }

        private void AddTableRow(Table table, string cell1, string cell2)
        {
            var row = table.Rows.Add();
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
        }

        private void buttonSend_Click(object sender, EventArgs e)
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

        private void ClearPaymentFields()
        {
            Clear_Funk = true;

            PayScoller_CB.SelectedIndex = -1;
            PayTeacher_CB.SelectedIndex = -1;
            Data_Pay_DTP.Text = "";
            ValuesRUB_TB.Text = "";
            PayStatus_CB.SelectedIndex = -1;
        }

        // ---------------------------------- Menu-Bar Logic -------------------------------------- //

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
