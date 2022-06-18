
namespace BankClient.Forms {
    partial class DirectorDashboard {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dtgItems = new System.Windows.Forms.DataGridView();
            this.btnViewClients = new System.Windows.Forms.Button();
            this.btnViewApplications = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.lbGender = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbCity = new System.Windows.Forms.Label();
            this.cbCity = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgItems
            // 
            this.dtgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItems.Location = new System.Drawing.Point(12, 129);
            this.dtgItems.Name = "dtgItems";
            this.dtgItems.Size = new System.Drawing.Size(781, 344);
            this.dtgItems.TabIndex = 0;
            // 
            // btnViewClients
            // 
            this.btnViewClients.Location = new System.Drawing.Point(12, 100);
            this.btnViewClients.Name = "btnViewClients";
            this.btnViewClients.Size = new System.Drawing.Size(121, 23);
            this.btnViewClients.TabIndex = 1;
            this.btnViewClients.Text = "Clients";
            this.btnViewClients.UseVisualStyleBackColor = true;
            this.btnViewClients.Click += new System.EventHandler(this.btnViewClients_Click);
            // 
            // btnViewApplications
            // 
            this.btnViewApplications.Location = new System.Drawing.Point(139, 100);
            this.btnViewApplications.Name = "btnViewApplications";
            this.btnViewApplications.Size = new System.Drawing.Size(121, 23);
            this.btnViewApplications.TabIndex = 2;
            this.btnViewApplications.Text = "Applications";
            this.btnViewApplications.UseVisualStyleBackColor = true;
            this.btnViewApplications.Click += new System.EventHandler(this.btnViewApplications_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(654, 100);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(139, 23);
            this.btnApprove.TabIndex = 3;
            this.btnApprove.Text = "Approve Application";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // cbGender
            // 
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(139, 70);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(121, 21);
            this.cbGender.TabIndex = 4;
            // 
            // lbGender
            // 
            this.lbGender.AutoSize = true;
            this.lbGender.Location = new System.Drawing.Point(136, 54);
            this.lbGender.Name = "lbGender";
            this.lbGender.Size = new System.Drawing.Size(42, 13);
            this.lbGender.TabIndex = 5;
            this.lbGender.Text = "Gender";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(393, 68);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 71);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 7;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(9, 54);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(35, 13);
            this.lbName.TabIndex = 8;
            this.lbName.Text = "Name";
            // 
            // lbCity
            // 
            this.lbCity.AutoSize = true;
            this.lbCity.Location = new System.Drawing.Point(263, 54);
            this.lbCity.Name = "lbCity";
            this.lbCity.Size = new System.Drawing.Size(24, 13);
            this.lbCity.TabIndex = 5;
            this.lbCity.Text = "City";
            // 
            // cbCity
            // 
            this.cbCity.FormattingEnabled = true;
            this.cbCity.Location = new System.Drawing.Point(266, 70);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(121, 21);
            this.cbCity.TabIndex = 4;
            // 
            // DirectorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lbCity);
            this.Controls.Add(this.lbGender);
            this.Controls.Add(this.cbCity);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnViewApplications);
            this.Controls.Add(this.btnViewClients);
            this.Controls.Add(this.dtgItems);
            this.Name = "DirectorDashboard";
            this.Size = new System.Drawing.Size(810, 489);
            this.Load += new System.EventHandler(this.DirectorDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgItems;
        private System.Windows.Forms.Button btnViewClients;
        private System.Windows.Forms.Button btnViewApplications;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label lbGender;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbCity;
        private System.Windows.Forms.ComboBox cbCity;
    }
}
