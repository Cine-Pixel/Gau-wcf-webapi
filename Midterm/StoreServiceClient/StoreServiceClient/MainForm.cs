using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using StoreServiceClientApp.classes;

namespace StoreServiceClientApp {
    public partial class MainForm : Form {
        string url = "http://localhost:58932/StoreService.svc";
        WebClient client = new WebClient() { Encoding = Encoding.UTF8};

        public MainForm() {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e) {
            var response = client.DownloadString($"{url}/GetProducts");
            List<ProductDTO> products = JsonConvert.DeserializeObject<List<ProductDTO>>(response);
            DtgProducts.DataSource = products;
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void BtnEdit_Click(object sender, EventArgs e) {
            if (DtgProducts.SelectedRows.Count != 1) {
                MessageBox.Show("Please select product first");
                return;
            }

            ProductDTO product = new ProductDTO {
                Id = (int)DtgProducts.SelectedRows[0].Cells[0].Value,
                ProductName = DtgProducts.SelectedRows[0].Cells[1].Value.ToString(),
                Description = DtgProducts.SelectedRows[0].Cells[2].Value.ToString(),
                Quantity = (int)DtgProducts.SelectedRows[0].Cells[3].Value,
                Category = new CategoryDTO { CategoryName = DtgProducts.SelectedRows[0].Cells[4].Value.ToString()}
            };

            ProductForm productForm = new ProductForm(product);
            productForm.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            if (DtgProducts.SelectedRows.Count != 1) {
                MessageBox.Show("Please select product first");
                return;
            }

            string id = DtgProducts.SelectedRows[0].Cells[0].Value.ToString();
            client.Headers["Content-Type"] = "application/json";

            var res = client.UploadData(
                $"{url}/DeleteProduct", 
                "DELETE", 
                Encoding.UTF8.GetBytes(id)
            );
            Response response = JsonConvert.DeserializeObject<Response>(Encoding.UTF8.GetString(res));
            if (response.Success)
                MessageBox.Show("Deleted succesfully");
            else
                MessageBox.Show(response.Message);
        }
    }
}
