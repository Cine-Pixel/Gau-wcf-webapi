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
using BankClient.DTO;
using Newtonsoft.Json;

namespace BankClient.Forms {
    public partial class OperatorDashboard : UserControl {
        string url = "http://localhost:51521/BankService.svc";
        private MainForm main;
        private EmployeeDTO oper;

        WebClient client = new WebClient() { Encoding = Encoding.UTF8 };

        public OperatorDashboard() {
            InitializeComponent();
        }

        public OperatorDashboard(MainForm main, EmployeeDTO oper) {
            this.main = main;
            this.oper = oper;
            InitializeComponent();
        }

        private void OperatorDashboard_Load(object sender, EventArgs e) {
            this.LoadGrids();
        }

        private void btnLoad_Click(object sender, EventArgs e) {
            this.LoadGrids();
        }

        private void LoadGrids() {
            dtgClients.DataSource = null;
            dtgApplications.DataSource = null;
            LoadClients();
            LoadApplications();
        }

        private void LoadClients() {
            var response = client.DownloadString($"{url}/GetClients");
            List<ClientDTO> clients = JsonConvert.DeserializeObject<List<ClientDTO>>(response);
            dtgClients.DataSource = clients;
        }

        private void LoadApplications() {
            var response = client.DownloadString($"{url}/GetApplications?id={oper.BranchId}");
            List<ApplicationDTO> applications = JsonConvert.DeserializeObject<List<ApplicationDTO>>(response);
            dtgApplications.DataSource = applications;
        }

        private void btnAddClient_Click(object sender, EventArgs e) {
            ClientForm clientForm = new ClientForm(oper);
            clientForm.Show();
        }

        private void btnEditClient_Click(object sender, EventArgs e) {
            if (dtgClients.SelectedRows.Count != 1) {
                MessageBox.Show("Please select client first");
                return;
            }

            ClientDTO client = new ClientDTO {
                Id = (int)dtgClients.SelectedRows[0].Cells[0].Value,
                FirstName = dtgClients.SelectedRows[0].Cells[1].Value.ToString(),
                LastName = dtgClients.SelectedRows[0].Cells[2].Value.ToString(),
                PersonalNumber = dtgClients.SelectedRows[0].Cells[4].Value.ToString(),
                Phone = dtgClients.SelectedRows[0].Cells[8].Value.ToString(),
                Email = dtgClients.SelectedRows[0].Cells[9].Value.ToString(),
                City = new CityDTO {
                    Name = dtgClients.SelectedRows[0].Cells[11].Value.ToString(),
                },
                Country = new CountryDTO {
                    Name = dtgClients.SelectedRows[0].Cells[12].Value.ToString(),
                }
            };

            ClientForm clientForm = new ClientForm(oper, client, "edit");
            clientForm.Show();
        }

        private void btnRemoveClient_Click(object sender, EventArgs e) {
            if (dtgClients.SelectedRows.Count != 1) {
                MessageBox.Show("Please select client first");
                return;
            }

            string id = dtgClients.SelectedRows[0].Cells[0].Value.ToString();
            client.Headers["Content-Type"] = "application/json";

            var res = client.UploadData(
                $"{url}/DeleteClient",
                "DELETE",
                Encoding.UTF8.GetBytes(id)
            );

            Response response = JsonConvert.DeserializeObject<Response>(Encoding.UTF8.GetString(res));
            if (response.Success)
                MessageBox.Show("Deleted succesfully");
            else
                MessageBox.Show(response.Message);
        }

        private void btnOpenApplication_Click(object sender, EventArgs e) {
            ApplicationForm applicationForm = new ApplicationForm(oper);
            applicationForm.Show();
        }
    }
}
