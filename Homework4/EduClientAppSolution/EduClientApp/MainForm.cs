using EduClientApp.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace EduClientApp
{
    public partial class MainForm : Form
    {
        string url = ConfigurationSettings.AppSettings["TestWCFService"];
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadGrid();
        }

        private void LoadGrid() {
            try
            {
                WebClient webClient = new WebClient {
                    Encoding = UTF8Encoding.UTF8
                };

                string json = webClient.DownloadString($"{url}/GetAllStudents");

                List<StudentDTO> result = HelpMethods.Deserialize<List<StudentDTO>>(json);

                DtgStudents.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StudentManagementToolStripMenuItem_Click(object sender, EventArgs e) {
            LoadGrid();
        }

        private void BtnFind_Click(object sender, EventArgs e) {
            try
            {
                WebClient webClient = new WebClient {
                    Encoding = UTF8Encoding.UTF8
                };
                webClient.Headers["Content-Type"] = "application/json";

                string id = NumId.Value.ToString();

                string response = webClient.DownloadString($"{url}/GetStudentById/{id}");
                StudentDTO student = HelpMethods.Deserialize<StudentDTO>(response);
                DtgStudents.DataSource = new List<StudentDTO> { student };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e) {
            StudentForm studentForm = new StudentForm(url);
            studentForm.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e) {
            if (DtgStudents.SelectedRows.Count != 1) {
                MessageBox.Show("Please select student first");
                return;
            }

            StudentDTO student = new StudentDTO {
                Id = (int)DtgStudents.SelectedRows[0].Cells[0].Value,
                FirstName = (string)DtgStudents.SelectedRows[0].Cells[2].Value,
                LastName = (string)DtgStudents.SelectedRows[0].Cells[3].Value,
                GPA = (float)DtgStudents.SelectedRows[0].Cells[4].Value,
                BithDate = (DateTime)DtgStudents.SelectedRows[0].Cells[5].Value
            };

            StudentForm studentForm = new StudentForm(url, student);
            studentForm.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            try
            {
                WebClient webClient = new WebClient {
                    Encoding = UTF8Encoding.UTF8
                };
                webClient.Headers["Content-Type"] = "application/json";

                string id = DtgStudents.SelectedRows[0].Cells[0].Value.ToString();

                string response = webClient.UploadString($"{url}/DeleteStudent/{id}", 
                    "DELETE",
                    HelpMethods.SerializeToXml<string>(id));
                Result result = HelpMethods.Deserialize<Result>(response);

                if(result.IsSuccess) {
                    MessageBox.Show("Student was delete succesfully");
                    LoadGrid();
                } else {
                    MessageBox.Show("Cannot delete student\n" + result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
