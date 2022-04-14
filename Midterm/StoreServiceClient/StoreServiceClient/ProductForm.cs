using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using StoreServiceClientApp.classes;
using StoreServiceClientApp.enums;

namespace StoreServiceClientApp {
    public partial class ProductForm : Form {
        string url = "http://localhost:58932/StoreService.svc";
        WebClient client = new WebClient() { Encoding = Encoding.UTF8};
        ProductDTO product;
        ProductAction action;

        public ProductForm() {
            InitializeComponent();
            this.action = ProductAction.create;
        }

        public ProductForm(ProductDTO product) {
            InitializeComponent();
            this.action = ProductAction.update;
            this.product = product;
        }

        private void ProductForm_Load(object sender, EventArgs e) {
            var response = client.DownloadString($"{url}/GetCategories");
            List<CategoryDTO> categories = JsonConvert.DeserializeObject<List<CategoryDTO>>(response);
            CbCategory.DataSource = categories; 
            CbCategory.ValueMember = "Id";
            CbCategory.DisplayMember = "CategoryName";

            if(this.action == ProductAction.update) {
                TbProductname.Text = this.product.ProductName;
                TbDescription.Text = this.product.Description;
                NumQuantity.Value = (decimal)this.product.Quantity;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            ProductDTO product = new ProductDTO {
                ProductName = TbProductname.Text,
                Description = TbDescription.Text,
                Quantity = (int)NumQuantity.Value,
                Category = new CategoryDTO {
                    Id = (int)CbCategory.SelectedValue
                }
            };

            client.Headers["Content-type"] = "application/json";

            string res;
            if(this.action == ProductAction.create) {
                string request = JsonConvert.SerializeObject(product);
                res = client.UploadString($"{url}/CreateProduct", "POST", request);
            } else {
                product.Id = this.product.Id;
                string request = JsonConvert.SerializeObject(product);
                res = client.UploadString($"{url}/UpdateProduct", "PUT", request);
            }

            Response response = JsonConvert.DeserializeObject<Response>(res);

            if (response.Success)
                this.Close();
            else
                MessageBox.Show(response.Message);
        }
    }
}
