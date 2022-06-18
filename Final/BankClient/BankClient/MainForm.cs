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
using BankClient.Forms;

namespace BankClient {
    public partial class MainForm : Form {
        private EmployeeDTO user;

        public MainForm() {
            InitializeComponent();
        }

        public void SetUser(EmployeeDTO user) {
            this.user = user;
            if (user.Position.Name.Equals("director")) {
                this.Text = "Director";
                DirectorDashboard director = new DirectorDashboard(this, user);
                director.Dock = DockStyle.Fill;
                this.Controls.Add(director);
            }
            else {
                this.Text = "Operator";
                OperatorDashboard operatorDashoboard = new OperatorDashboard(this, user);

                operatorDashoboard.Dock = DockStyle.Fill;
                this.Controls.Add(operatorDashoboard);
            }
        }

        public EmployeeDTO GetUser() {
            return this.user;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            if (this.user != null) {
                MessageBox.Show("Logged in");
            }
            else {
                LoginForm login = new LoginForm(this);
                login.Dock = DockStyle.Fill;
                this.Controls.Add(login);
            }
        }
    }
}
