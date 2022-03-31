
namespace InventoryManagementSystem
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLoginAdmin = new System.Windows.Forms.Button();
            this.labelCreateAcc = new System.Windows.Forms.Label();
            this.labelRegister = new System.Windows.Forms.Label();
            this.btnLoginUser = new System.Windows.Forms.Button();
            this.btnLoginGuest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 78);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(34, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "INVENTORY MANAGEMENT SYSTEM";
            // 
            // btnLoginAdmin
            // 
            this.btnLoginAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLoginAdmin.FlatAppearance.BorderSize = 0;
            this.btnLoginAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginAdmin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginAdmin.ForeColor = System.Drawing.Color.White;
            this.btnLoginAdmin.Location = new System.Drawing.Point(34, 164);
            this.btnLoginAdmin.Name = "btnLoginAdmin";
            this.btnLoginAdmin.Size = new System.Drawing.Size(258, 45);
            this.btnLoginAdmin.TabIndex = 5;
            this.btnLoginAdmin.Text = "Administrator";
            this.btnLoginAdmin.UseVisualStyleBackColor = false;
            this.btnLoginAdmin.Click += new System.EventHandler(this.btnLoginAdmin_Click);
            // 
            // labelCreateAcc
            // 
            this.labelCreateAcc.AutoSize = true;
            this.labelCreateAcc.ForeColor = System.Drawing.Color.Red;
            this.labelCreateAcc.Location = new System.Drawing.Point(165, 404);
            this.labelCreateAcc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCreateAcc.Name = "labelCreateAcc";
            this.labelCreateAcc.Size = new System.Drawing.Size(112, 17);
            this.labelCreateAcc.TabIndex = 14;
            this.labelCreateAcc.Text = "Create account";
            this.labelCreateAcc.Click += new System.EventHandler(this.labelCreateAcc_Click);
            // 
            // labelRegister
            // 
            this.labelRegister.AutoSize = true;
            this.labelRegister.Location = new System.Drawing.Point(53, 404);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(107, 17);
            this.labelRegister.TabIndex = 13;
            this.labelRegister.Text = "Not registered?";
            // 
            // btnLoginUser
            // 
            this.btnLoginUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLoginUser.FlatAppearance.BorderSize = 0;
            this.btnLoginUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginUser.ForeColor = System.Drawing.Color.White;
            this.btnLoginUser.Location = new System.Drawing.Point(34, 236);
            this.btnLoginUser.Name = "btnLoginUser";
            this.btnLoginUser.Size = new System.Drawing.Size(258, 45);
            this.btnLoginUser.TabIndex = 15;
            this.btnLoginUser.Text = "User";
            this.btnLoginUser.UseVisualStyleBackColor = false;
            this.btnLoginUser.Click += new System.EventHandler(this.btnLoginUser_Click);
            // 
            // btnLoginGuest
            // 
            this.btnLoginGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLoginGuest.FlatAppearance.BorderSize = 0;
            this.btnLoginGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginGuest.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginGuest.ForeColor = System.Drawing.Color.White;
            this.btnLoginGuest.Location = new System.Drawing.Point(34, 308);
            this.btnLoginGuest.Name = "btnLoginGuest";
            this.btnLoginGuest.Size = new System.Drawing.Size(258, 45);
            this.btnLoginGuest.TabIndex = 16;
            this.btnLoginGuest.Text = "Guest";
            this.btnLoginGuest.UseVisualStyleBackColor = false;
            this.btnLoginGuest.Click += new System.EventHandler(this.btnLoginGuest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(119, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 17;
            this.label1.Text = "Login as:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 447);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoginGuest);
            this.Controls.Add(this.btnLoginUser);
            this.Controls.Add(this.labelCreateAcc);
            this.Controls.Add(this.labelRegister);
            this.Controls.Add(this.btnLoginAdmin);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLoginAdmin;
        private System.Windows.Forms.Label labelCreateAcc;
        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.Button btnLoginUser;
        private System.Windows.Forms.Button btnLoginGuest;
        private System.Windows.Forms.Label label1;
    }
}

