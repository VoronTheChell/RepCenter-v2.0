using RepCenter_SupabaseEdition.Forms;
using System.Reflection;

namespace RepCenter_SupabaseEdition
{
    public class SupabaseService
    {
        public Supabase.Client? supabase;

        public async Task InitAsync()
        {
            // TODO: Проверить работоспособность в полевых условиях
            EmbeddedEnvLoader.LoadEmbeddedEnv();

            string url = Environment.GetEnvironmentVariable("SUPABASE_URL") ?? throw new Exception("SUPABASE_URL не найден в переменных окружения");
            string key = Environment.GetEnvironmentVariable("SUPABASE_KEY") ?? throw new Exception("SUPABASE_KEY не найден в переменных окружения");

            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            supabase = new Supabase.Client(url, key, options);
            await supabase.InitializeAsync();
        }

        public Supabase.Client? Getsupabase()
        {
            return supabase;
        }

        public async Task<int> GetIDByNameStudentAsync(string selectedName)
        {

            if (string.IsNullOrWhiteSpace(selectedName))
            {
                MessageBox.Show("Имя студента не указано.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                var students = await supabase
                    .From<Student>()
                    .Where(x => x.FIO == selectedName)
                    .Get();

                var student = students.Models.FirstOrDefault();
                return student?.StudentId ?? -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении студента: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public async Task<int> GetIDByNameTeacherAsync(string selectedName)
        {
            if (string.IsNullOrWhiteSpace(selectedName))
            {
                MessageBox.Show("Имя преподавателя не указано.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                var teachers = await supabase
                    .From<Repetitors>()
                    .Where(x => x.FIO == selectedName)
                    .Get();

                var teacher = teachers.Models.FirstOrDefault();
                return teacher?.TutorId ?? -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении преподавателя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        // Метод для авторизации пользователя
        public async Task<Register> LoginAsync(string login, Supabase.Client? supabase)
        {
            var response = await supabase.From<Register>()
                .Where(x => x.LoginUser == login)
                .Get();

            #pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return response.Models.FirstOrDefault();
            #pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }


        // Метод для Регистрации пользователя
        public async Task<bool> RegisterStudent(string fullName, string birthDate, string phone, string email, string subject)
        {
            var student = new Student
            {
                FIO = fullName,
                DateBirth = birthDate,
                NumberPhone = phone,
                EmailAdress = email,
                Predmet = subject
            };

            var response = await supabase.From<Student>().Insert(student);
            return response.Models != null && response.Models.Count > 0;
        }

        public async Task<List<Pridments>> GetSubjects()
        {
            try
            {
                var response = await supabase.From<Pridments>()
                    .Get();
                return response.Models.ToList();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении предметов: {ex.Message}");
                return null;
            }
        }

        // --------------------- REGISTER (users) ---------------------
        public async Task<List<Register>> GetAllUsersAsync()
        {
            var response = await supabase.From<Register>().Get();
            return response.Models;
        }

        public async Task<bool> AddUserAsync(Register user)
        {
            var result = await supabase.From<Register>().Insert(user);
            return result.Models.Count > 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await supabase.From<Register>()
                    .Where(x => x.IdUser == id)
                    .Delete();
            return true;
        }

        public async Task<bool> UpdateUserAsync(Register user)
        {
            var result = await supabase.From<Register>().Update(user);
            return result.Models.Count > 0;
        }

        // --------------------- STUDENTS ---------------------
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            var response = await supabase.From<Student>().Get();
            return response.Models;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            var result = await supabase.From<Student>().Insert(student);
            return result.Models.Count > 0;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            await supabase.From<Student>()
                .Where(x => x.StudentId == id)
                .Delete();
            return true;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var result = await supabase.From<Student>().Update(student);
            return result.Models.Count > 0;
        }

        // --------------------- REPETITORS (tutors) ---------------------
        public async Task<List<Repetitors>> GetAllTutorsAsync()
        {
            var response = await supabase.From<Repetitors>().Get();
            return response.Models;
        }

        public async Task<bool> AddTutorAsync(Repetitors tutor)
        {
            var result = await supabase.From<Repetitors>().Insert(tutor);
            return result.Models.Count > 0;
        }

        public async Task<bool> DeleteTutorAsync(int id)
        {
            await supabase.From<Repetitors>()
                         .Where(x => x.TutorId == id)
                         .Delete();

            return true; // если ошибок не возникло — считаем, что успешно
        }


        public async Task<bool> UpdateTutorAsync(Repetitors tutor)
        {
            var result = await supabase.From<Repetitors>().Update(tutor);
            return result.Models.Count > 0;
        }

        // --------------------- PRIDMENTS (subjects) ---------------------
        public async Task<List<Pridments>> GetAllSubjectsAsync()
        {
            var response = await supabase.From<Pridments>().Get();
            return response.Models;
        }

        public async Task<bool> AddSubjectAsync(Pridments subject)
        {
            var result = await supabase.From<Pridments>().Insert(subject);
            return result.Models.Count > 0;
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            await supabase.From<Pridments>()
                .Where(x => x.SubjectId == id)
                .Delete();
            return true;
        }

        public async Task<bool> UpdateSubjectAsync(Pridments subject)
        {
            var result = await supabase.From<Pridments>().Update(subject);
            return result.Models.Count > 0;
        }

        // --------------------- RASPISANIE (schedules) ---------------------
        public async Task<List<RaspisanieZaniyatiy>> GetAllSchedulesAsync()
        {
            var response = await supabase.From<RaspisanieZaniyatiy>().Get();
            return response.Models;
        }

        public async Task<bool> AddScheduleAsync(RaspisanieZaniyatiy sched)
        {
            var result = await supabase.From<RaspisanieZaniyatiy>().Insert(sched);
            return result.Models.Count > 0;
        }

        public async Task<bool> DeleteScheduleAsync(int id)
        {
            await supabase.From<RaspisanieZaniyatiy>()
                    .Where(x => x.ScheduleId == id)
                    .Delete();
            return true;
        }

        public async Task<bool> UpdateScheduleAsync(RaspisanieZaniyatiy sched)
        {
            var result = await supabase.From<RaspisanieZaniyatiy>().Update(sched);
            return result.Models.Count > 0;
        }

        // --------------------- PAYMENTS ---------------------
        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            var response = await supabase.From<Payment>().Get();
            return response.Models;
        }

        public async Task<bool> AddPaymentAsync(Payment pay)
        {
            var result = await supabase.From<Payment>().Insert(pay);
            return result.Models.Count > 0;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            await supabase.From<Payment>()
                    .Where(x => x.PaymentId == id)
                    .Delete();
            return true;
        }

        public async Task<bool> UpdatePaymentAsync(Payment pay)
        {
            var result = await supabase.From<Payment>().Update(pay);
            return result.Models.Count > 0;
        }

        // --------------------- Оценки студентов ---------------------
        public async Task<List<StudentGrades>> GetAllGradesAsync()
        {
            var response = await supabase.From<StudentGrades>().Get();
            return response.Models;
        }

        public async Task<bool> AddGradeAsync(StudentGrades grade)
        {
            var result = await supabase.From<StudentGrades>().Insert(grade);
            return result.Models.Count > 0;
        }

        public async Task<bool> DeleteGradeAsync(int id)
        {
            await supabase.From<StudentGrades>()
                        .Where(x => x.GradeId == id)
                        .Delete();
            return true;
        }

        public async Task<bool> UpdateGradeAsync(StudentGrades grade)
        {
            var result = await supabase.From<StudentGrades>().Update(grade);
            return result.Models.Count > 0;
        }

    }

    public static class EmbeddedEnvLoader
    {
        public static void LoadEmbeddedEnv()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames()
                                       .FirstOrDefault(name => name.EndsWith(".env"));

            if (resourceName == null)
            {
                throw new Exception(".env not found in embedded resources.");
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourceName) ?? throw new Exception("Ошибка чтения файла!"))
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                    var parts = line.Split('=', 2);
                    if (parts.Length == 2)
                        Environment.SetEnvironmentVariable(parts[0].Trim(), parts[1].Trim());
                }
            }
        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new loginUp_Form());
        }
    }
}