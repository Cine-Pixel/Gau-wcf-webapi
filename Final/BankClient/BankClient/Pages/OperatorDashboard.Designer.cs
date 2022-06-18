
namespace BankClient.Forms {
    partial class OperatorDashboard {
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
            this.dtgClients = new System.Windows.Forms.DataGridView();
            this.dtgApplications = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnEditClient = new System.Windows.Forms.Button();
            this.btnRemoveClient = new System.Windows.Forms.Button();
            this.btnOpenApplication = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgClients
            // 
            this.dtgClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClients.Location = new System.Drawing.Point(14, 133);
            this.dtgClients.Name = "dtgClients";
            this.dtgClients.Size = new System.Drawing.Size(381, 314);
            this.dtgClients.TabIndex = 0;
            // 
            // dtgApplications
            // 
            this.dtgApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgApplications.Location = new System.Drawing.Point(416, 133);
            this.dtgApplications.Name = "dtgApplications";
            this.dtgApplications.Size = new System.Drawing.Size(381, 314);
            this.dtgApplications.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Applications";
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(14, 104);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(75, 23);
            this.btnAddClient.TabIndex = 2;
            this.btnAddClient.Text = "Add";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.Location = new System.Drawing.Point(95, 104);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(75, 23);
            this.btnEditClient.TabIndex = 3;
            this.btnEditClient.Text = "Edit";
            this.btnEditClient.UseVisualStyleBackColor = true;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // btnRemoveClient
            // 
            this.btnRemoveClient.Location = new System.Drawing.Point(176, 104);
            this.btnRemoveClient.Name = "btnRemoveClient";
            this.btnRemoveClient.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveClient.TabIndex = 3;
            this.btnRemoveClient.Text = "Remove";
            this.btnRemoveClient.UseVisualStyleBackColor = true;
            this.btnRemoveClient.Click += new System.EventHandler(this.btnRemoveClient_Click);
            // 
            // btnOpenApplication
            // 
            this.btnOpenApplication.Location = new System.Drawing.Point(418, 104);
            this.btnOpenApplication.Name = "btnOpenApplication";
            this.btnOpenApplication.Size = new System.Drawing.Size(75, 23);
            this.btnOpenApplication.TabIndex = 2;
            this.btnOpenApplication.Text = "Open";
            this.btnOpenApplication.UseVisualStyleBackColor = true;
            this.btnOpenApplication.Click += new System.EventHandler(this.btnOpenApplication_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(14, 51);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // OperatorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnRemoveClient);
            this.Controls.Add(this.btnOpenApplication);
            this.Controls.Add(this.btnEditClient);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgApplications);
            this.Controls.Add(this.dtgClients);
            this.Name = "OperatorDashboard";
            this.Size = new System.Drawing.Size(810, 461);
            this.Load += new System.EventHandler(this.OperatorDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgClients;
        private System.Windows.Forms.DataGridView dtgApplications;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnEditClient;
        private System.Windows.Forms.Button btnRemoveClient;
        private System.Windows.Forms.Button btnOpenApplication;
        private System.Windows.Forms.Button btnLoad;
    }
}
