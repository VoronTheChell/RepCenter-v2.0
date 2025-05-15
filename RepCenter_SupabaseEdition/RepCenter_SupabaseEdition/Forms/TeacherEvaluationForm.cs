using System.Data;

namespace RepCenter_SupabaseEdition.Forms
{
    public partial class TeacherEvaluationForm : Form
    {
        private int selectedRow = -1;

        private readonly SupabaseService _service = new SupabaseService();

        public TeacherEvaluationForm()
        {
            InitializeComponent();
            AppConfig();
        }

        private async void AppConfig()
        {
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            selectTeacher_CB.DropDownStyle = ComboBoxStyle.DropDownList;

            SelectUserTeacher_DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            await _service.InitAsync();
            await LoadUnlinkedTeachersToComboBoxAsync();

            await LoadTeachersToGridAsync();
        }

        private async Task LoadUnlinkedTeachersToComboBoxAsync()
        {
            selectTeacher_CB.Items.Clear();

            var response = await _service.supabase
                .From<Repetitors>()
                .Filter("id_user", Supabase.Postgrest.Constants.Operator.Is, "null")
                .Get();

            foreach (var rep in response.Models)
            {
                if (!string.IsNullOrWhiteSpace(rep.FIO))
                    selectTeacher_CB.Items.Add(rep.FIO);
            }
        }

        private async Task LoadTeachersToGridAsync()
        {
            try
            {
                var service = new SupabaseService();
                await service.InitAsync();

                var response = await service.supabase
                    .From<Register>()
                    .Filter("status_user", Supabase.Postgrest.Constants.Operator.Equals, "учитель")
                    .Get();

                var data = response.Models.Select(u => new
                {
                    Логин = u.LoginUser,
                    Пароли = u.PasswordUser,
                    Предметы = u.SubjectUser
                }).ToList();

                SelectUserTeacher_DGV.DataSource = data;
                SelectUserTeacher_DGV.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке пользователей: " + ex.Message);
            }
        }

        private void SelectUserTeacher_DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                var row = SelectUserTeacher_DGV.Rows[selectedRow];
                nameUser_TB.Text = row.Cells["Логин"].Value.ToString();
                passUser_TB.Text = "******"; // не раскрываем хеш
            }
        }

        private async void buttonPublication_Click(object sender, EventArgs e)
        {
            if (selectTeacher_CB.SelectedIndex == -1 || selectedRow == -1)
            {
                MessageBox.Show("Выберите и учителя, и пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedLogin = nameUser_TB.Text;
            string selectedFIO = selectTeacher_CB.Text;

            var userResp = await _service.supabase
                .From<Register>()
                .Filter("login_user", Supabase.Postgrest.Constants.Operator.Equals, selectedLogin)
                .Get();
            int userID = userResp.Models.FirstOrDefault()?.IdUser ?? -1;

            var teacherResp = await _service.supabase
                .From<Repetitors>()
                .Filter("fio", Supabase.Postgrest.Constants.Operator.Equals, selectedFIO)
                .Get();
            var teacher = teacherResp.Models.FirstOrDefault();
            int tutorID = teacher?.TutorId ?? -1;

            if (userID == -1 || tutorID == -1)
            {
                MessageBox.Show("Не удалось найти данные.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            teacher.IdUser = userID;
            var result = await teacher.Update<Repetitors>(); // ✅

            if (result != null)
            {
                MessageBox.Show("Пользователь успешно привязан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUnlinkedTeachersToComboBoxAsync();
                await LoadTeachersToGridAsync();
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
