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
    public partial class ApplicationForm : Form {
        string url = "http://localhost:51521/BankService.svc";
        private EmployeeDTO oper;

        WebClient webclient = new WebClient() { Encoding = Encoding.UTF8 };

        public ApplicationForm() {
            InitializeComponent();
        }

        public ApplicationForm(EmployeeDTO oper) {
            this.oper = oper;
            InitializeComponent();
        }

        private void ApplicationForm_Load(object sender, EventArgs e) {
            try {
                var rawClients = webclient.DownloadString($"{url}/GetClients");
                List<ClientDTO> clients = JsonConvert.DeserializeObject<List<ClientDTO>>(rawClients);
                cbClient.DataSource = clients;
                cbClient.DisplayMember = "PersonalNumber";
                cbClient.ValueMember = "Id";

                var rawTypes = webclient.DownloadString($"{url}/GetTypes");
                List<TypeDTO> types = JsonConvert.DeserializeObject<List<TypeDTO>>(rawTypes);
                cbType.DataSource = types;
                cbType.DisplayMember = "Name";
                cbType.ValueMember = "Id";
            }
            catch (Exception ex) {
                MessageBox.Show($"Error during loading data: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(!decimal.TryParse(tbAmount.Text, out decimal amount)) {
                MessageBox.Show("Amount Must be Number");
                return;
            }
            ApplicationDTO application = new ApplicationDTO {
                TypeId = (int)cbType.SelectedValue,
                //TypeId = 1,
                ClientId = (int)cbClient.SelectedValue,
                BranchId = this.oper.BranchId,
                Amount = amount
            };
            webclient.Headers["Content-type"] = "application/json";
            Request<ApplicationDTO> request = new Request<ApplicationDTO> {
                Id=this.oper.Id, 
                Token = "token", 
                Object = application
            };
            string rawRequest = JsonConvert.SerializeObject(request);
            string res = webclient.UploadString($"{url}/CreateApplication", "POST", rawRequest);

            Response response = JsonConvert.DeserializeObject<Response>(res);

            if (response.Success)
                this.Close();
            else
                MessageBox.Show(response.Message);
        }

    }
}
