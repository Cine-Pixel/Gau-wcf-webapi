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
    public partial class MainForm : Form {
        StoreServiceReference.StoreServiceClient client = new StoreServiceReference.StoreServiceClient();

        public MainForm() {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e) {
            DtgProducts.DataSource = client.GetProducts().ToList();
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            if (DtgProducts.SelectedRows.Count != 1) {
                MessageBox.Show("Please select product first");
                return;
            }

            int id = (int)DtgProducts.SelectedRows[0].Cells[2].Value;
            if (client.DeleteProduct(id))
                MessageBox.Show("Deleted succesfully");
            else
                MessageBox.Show("Cannot delete item");
        }
    }
}
