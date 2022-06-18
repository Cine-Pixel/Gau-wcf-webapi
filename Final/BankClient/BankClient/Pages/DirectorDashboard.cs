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
    public partial class DirectorDashboard : UserControl {
        string url = "http://localhost:51521/BankService.svc";
        private MainForm main;
        private EmployeeDTO director;

        WebClient client = new WebClient() { Encoding = Encoding.UTF8 };

        public DirectorDashboard() {
            InitializeComponent();
        }

        public DirectorDashboard(MainForm main, EmployeeDTO director) {
            this.main = main;
            this.director = director;
            InitializeComponent();
        }


        private void DirectorDashboard_Load(object sender, EventArgs e) {
            try {
                var rawGenders = client.DownloadString($"{url}/GetGenders");
                List<GenderDTO> genders = JsonConvert.DeserializeObject<List<GenderDTO>>(rawGenders);
                cbGender.DataSource = genders;
                cbGender.DisplayMember = "Name";
                cbGender.ValueMember = "Id";

                var rawCities = client.DownloadString($"{url}/GetCities");
                List<CityDTO> cities = JsonConvert.DeserializeObject<List<CityDTO>>(rawCities);
                cbCity.DataSource = cities;
                cbCity.DisplayMember = "Name";
                cbCity.ValueMember = "Id";
            }

            catch (Exception ex) {
                MessageBox.Show($"Error during loading data: {ex.Message}");
            }

            LoadClients();
            btnViewClients.BackColor = Color.Green;
            btnViewApplications.BackColor = default(Color);
        }

        private void LoadClients() {
            btnViewClients.BackColor = Color.Green;
            btnViewApplications.BackColor = default(Color);
            showClients();
            var response = client.DownloadString($"{url}/GetClients");
            List<ClientDTO> clients = JsonConvert.DeserializeObject<List<ClientDTO>>(response);
            dtgItems.DataSource = clients;
            btnApprove.Visible = false;
        }

        private void LoadApplications() {
            btnViewClients.BackColor = default(Color);
            hideClients();
            btnViewApplications.BackColor = Color.Green;
            var response = client.DownloadString($"{url}/GetApplications?id={director.BranchId}");
            List<ApplicationDTO> applications = JsonConvert.DeserializeObject<List<ApplicationDTO>>(response);
            dtgItems.DataSource = applications;
            btnApprove.Visible = true;
        }

        public void hideClients() {
            tbName.Visible = false;
            lbName.Visible = false;
            cbGender.Visible = false;
            lbGender.Visible = false;
            cbCity.Visible = false;
            lbCity.Visible = false;
            btnFilter.Visible = false;
        }

        public void showClients() {
            tbName.Visible = true;
            lbName.Visible = true;
            cbGender.Visible = true;
            lbGender.Visible = true;
            cbCity.Visible = true;
            lbCity.Visible = true;
            btnFilter.Visible = true;
        }

        private void btnViewClients_Click(object sender, EventArgs e) {
            dtgItems.DataSource = null;
            LoadClients();
        }

        private void btnViewApplications_Click(object sender, EventArgs e) {
            dtgItems.DataSource = null;
            LoadApplications();
        }

        private void btnApprove_Click(object sender, EventArgs e) {
            if (dtgItems.SelectedRows.Count != 1) {
                MessageBox.Show("Please select client first");
                return;
            }

            ApplicationDTO application = new ApplicationDTO {
                Id = (int)dtgItems.SelectedRows[0].Cells[0].Value,
            };

            client.Headers["Content-type"] = "application/json";

            Request<ApplicationDTO> request = new Request<ApplicationDTO> {
                Id = this.director.Id,
                Token = "token",
                Object = application
            };
            string rawRequest = JsonConvert.SerializeObject(request);
            string res = client.UploadString($"{url}/ApproveApplication", "PUT", rawRequest);

            Response response = JsonConvert.DeserializeObject<Response>(res);

            if (response.Success)
                MessageBox.Show("Approved");
            else
                MessageBox.Show(response.Message);
            
        }

        private void btnFilter_Click(object sender, EventArgs e) {
            string name = tbName.Text;
            string gender = ((GenderDTO)cbGender.SelectedItem).Name;
            string city = ((CityDTO)cbCity.SelectedItem).Name;

            var response = client.DownloadString($"{url}/FilterClients?name={name}&gender={gender}&city={city}");
            List<ClientDTO> clients= JsonConvert.DeserializeObject<List<ClientDTO>>(response);
            dtgItems.DataSource = clients;
        }
    }
}
