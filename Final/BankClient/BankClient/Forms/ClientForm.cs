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
    public partial class ClientForm : Form {
        string url = "http://localhost:51521/BankService.svc";
        private MainForm main;
        private EmployeeDTO oper;
        private ClientDTO client;
        private string action;

        WebClient webclient = new WebClient() { Encoding = Encoding.UTF8 };

        public ClientForm() {
            InitializeComponent();
            this.action = "add";
        }

        public ClientForm(EmployeeDTO oper) {
            this.oper = oper;
            InitializeComponent();
            this.action = "add";
        }

        public ClientForm(EmployeeDTO oper, ClientDTO client, string action) {
            this.oper = oper;
            InitializeComponent();
            this.action = action;
            this.client = client;
        }

        private void ClientForm_Load(object sender, EventArgs e) {
            try {
                var rawGenders = webclient.DownloadString($"{url}/GetGenders");
                List<GenderDTO> genders = JsonConvert.DeserializeObject<List<GenderDTO>>(rawGenders);
                cbGender.DataSource = genders;
                cbGender.DisplayMember = "Name";
                cbGender.ValueMember = "Id";

                var rawCountries = webclient.DownloadString($"{url}/GetCountries");
                List<CountryDTO> countries = JsonConvert.DeserializeObject<List<CountryDTO>>(rawCountries);
                cbCountry.DataSource = countries;
                cbCountry.DisplayMember = "Name";
                cbCountry.ValueMember = "Id";

                var rawCities = webclient.DownloadString($"{url}/GetCities");
                List<CityDTO> cities = JsonConvert.DeserializeObject<List<CityDTO>>(rawCities);
                cbCity.DataSource = cities;
                cbCity.DisplayMember = "Name";
                cbCity.ValueMember = "Id";

                var rawGuarantors = webclient.DownloadString($"{url}/GetGuarantors");
                List<GuarantorDTO> guarantors= JsonConvert.DeserializeObject<List<GuarantorDTO>>(rawGuarantors);
                cbGuarantor.DataSource = guarantors;
                cbGuarantor.DisplayMember = "Relationship";
                cbGuarantor.ValueMember = "Id";
            }
            catch (Exception ex) {
                MessageBox.Show($"Error during loading data: {ex.Message}");
            }

            if(this.action == "edit") {
                tbFirstname.Text = this.client.FirstName;
                tbLastname.Text = this.client.LastName;
                tbPhone.Text = this.client.Phone;
                tbEmail.Text = this.client.Email;
                tbPersonalNumber.Text = this.client.PersonalNumber;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            ClientDTO client = new ClientDTO {
                FirstName = tbFirstname.Text,
                LastName = tbLastname.Text,
                Phone = tbPhone.Text,
                Email = tbEmail.Text,
                PersonalNumber = tbPersonalNumber.Text,
                //BirthDate = dateBirth.Value,
                CountryId = (int)cbCountry.SelectedValue,
                Country = new CountryDTO{
                    Id = (int)cbCountry.SelectedValue
                },
                CityId = (int)cbCity.SelectedValue,
                City = new CityDTO{
                    Id = (int)cbCity.SelectedValue
                },
                GenderId = (int)cbGender.SelectedValue,
                Gender = new GenderDTO{
                    Id = (int)cbGender.SelectedValue
                },
                GuarantorId = (int)cbGender.SelectedValue,
                Guarantor = new GuarantorDTO{
                    Id = (int)cbGuarantor.SelectedValue
                }
            };
            webclient.Headers["Content-type"] = "application/json";

            string res;
            if (this.action == "add") {
                Request<ClientDTO> request = new Request<ClientDTO> {
                    Id=this.oper.Id, 
                    Token = "token", 
                    Object = client 
                };
                string rawRequest = JsonConvert.SerializeObject(request);
                res = webclient.UploadString($"{url}/AddClient", "POST", rawRequest);
            }
            else {
                client.Id = this.client.Id;
                Request<ClientDTO> request = new Request<ClientDTO> {
                    Id=this.oper.Id, 
                    Token = "token", 
                    Object = client 
                };
                string rawRequest = JsonConvert.SerializeObject(request);
                res = webclient.UploadString($"{url}/UpdateClient", "PUT", rawRequest);
            }

            Response response = JsonConvert.DeserializeObject<Response>(res);

            if (response.Success)
                this.Close();
            else
                MessageBox.Show(response.Message);
        }
    }
}
