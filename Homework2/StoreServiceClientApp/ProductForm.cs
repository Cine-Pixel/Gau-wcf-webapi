using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreServiceClientApp {
    public partial class ProductForm : Form {
        StoreServiceReference.StoreServiceClient client = new StoreServiceReference.StoreServiceClient();
        public ProductForm() {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e) {
            CbCategory.DataSource = client.GetCategories().ToList();
            CbCategory.ValueMember = "Id";
            CbCategory.DisplayMember = "CategoryName";
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            StoreServiceReference.Product p = new StoreServiceReference.Product {
                ProductName = TbProductname.Text,
                Description = TbDescription.Text,
                Quantity = (int)NumQuantity.Value,
                Category = new StoreServiceReference.Category {
                    Id = (int)CbCategory.SelectedValue
                }
            };

            if (client.CreateProduct(p))
                this.Close();
            else
                MessageBox.Show("Cannot complete request");
        }
    }
}
