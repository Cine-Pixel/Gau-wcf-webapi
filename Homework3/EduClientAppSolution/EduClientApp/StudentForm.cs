using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EduClientApp.Classes;
using EduClientApp.enums;

namespace EduClientApp {
    public partial class StudentForm : Form {
        StudentAction action;
        StudentDTO student;
        string url;

        public StudentForm() {
            InitializeComponent();
        }

        public StudentForm(string url) {
            InitializeComponent();
            this.action = StudentAction.create;
            this.url = url;
        }

        public StudentForm(string url, StudentDTO student) {
            InitializeComponent();
            this.action = StudentAction.update;
            this.student = student;
            this.url = url;
        }

        private void StudentForm_Load(object sender, EventArgs e) {
            if(this.action == StudentAction.create) {
                LblTitle.Text = "Create Student";
            } else {
                LblTitle.Text = "Update Student";
                TbFirstName.Text = student.FirstName;
                TbLastName.Text = student.LastName;
                TbGPA.Text = student.GPA.ToString();
                //DtBirthDate.Value = student.BithDate;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e) {
            if(this.action == StudentAction.create) {
                CreateStudent();
            } else {
                UpdateStudent();
            }
        }

        private void CreateStudent() {
            try
            {
                WebClient webClient = new WebClient {
                    Encoding = UTF8Encoding.UTF8
                };
                webClient.Headers["Content-Type"] = "application/xml";

                StudentDTO student = new StudentDTO {
                    FirstName = TbFirstName.Text,
                    LastName = TbLastName.Text,
                    GPA = float.Parse(TbGPA.Text),
                    BithDate = DtBirthDate.Value
                };

                string response = webClient.UploadString($"{url}/AddNewStudent", 
                    HelpMethods.SerializeToXml<StudentDTO>(student).OuterXml);
                Result result = HelpMethods.Deserialize<Result>(response);
                if(result.IsSuccess) {
                    MessageBox.Show("Student was created succesfully");
                    this.Close();
                } else {
                    MessageBox.Show("Cannot create student\n" + result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateStudent() {
            try
            {
                WebClient webClient = new WebClient {
                    Encoding = UTF8Encoding.UTF8
                };
                webClient.Headers["Content-Type"] = "application/xml";

                StudentDTO student = new StudentDTO {
                    Id = this.student.Id,
                    FirstName = TbFirstName.Text,
                    LastName = TbLastName.Text,
                    GPA = float.Parse(TbGPA.Text),
                    BithDate = DtBirthDate.Value
                };

                string response = webClient.UploadString($"{url}/UpdateStudent", 
                    "PUT",
                    HelpMethods.SerializeToXml<StudentDTO>(student).OuterXml);
                Result result = HelpMethods.Deserialize<Result>(response);
                if(result.IsSuccess) {
                    MessageBox.Show("Student information was updated succesfully");
                    this.Close();
                } else {
                    MessageBox.Show("Cannot update student information\n" + result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
