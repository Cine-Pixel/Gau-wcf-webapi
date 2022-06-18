using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankClient.DTO;

namespace BankClient.Forms {
    public partial class LoginForm : UserControl {
        private MainForm main;

        public LoginForm() {
            InitializeComponent();
        }

        public LoginForm(MainForm main) {
            this.main = main;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            string name = tbName.Text;
            string password = tbPassword.Text;
            string position = cbPosition.Text;

            if(position.Equals("director")) {
                EmployeeDTO user = new EmployeeDTO {
                    Id = 2,
                    BranchId = 1,
                    Position = new PositionDTO { Id = 3, Name = "director"}
                };
                this.main.SetUser(user);
                main.Controls.Remove(this);
            } else {
                EmployeeDTO user = new EmployeeDTO {
                    Id = 1,
                    BranchId = 1,
                    Position = new PositionDTO { Id = 1, Name = "operator"}
                };
                this.main.SetUser(user);
                main.Controls.Remove(this);
            }
        }
    }
}
