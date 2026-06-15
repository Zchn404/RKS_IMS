namespace RKS_Inventory
{
    partial class SystemLock
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tbPass = new MaterialSkin.Controls.MaterialTextBox();
            this.lblStaff = new MaterialSkin.Controls.MaterialLabel();
            this.btnEnter = new MaterialSkin.Controls.MaterialButton();
            this.lblRole = new MaterialSkin.Controls.MaterialLabel();
            this.lblUserSA = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(36, 63);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(75, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Password:";
            // 
            // tbPass
            // 
            this.tbPass.AnimateReadOnly = false;
            this.tbPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPass.Depth = 0;
            this.tbPass.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPass.Hint = "Password";
            this.tbPass.LeadingIcon = null;
            this.tbPass.Location = new System.Drawing.Point(163, 25);
            this.tbPass.Margin = new System.Windows.Forms.Padding(4);
            this.tbPass.MaxLength = 50;
            this.tbPass.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPass.Multiline = false;
            this.tbPass.Name = "tbPass";
            this.tbPass.Password = true;
            this.tbPass.Size = new System.Drawing.Size(271, 50);
            this.tbPass.TabIndex = 1;
            this.tbPass.Text = "";
            this.tbPass.TrailingIcon = null;
            this.tbPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPass_KeyPress);
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Depth = 0;
            this.lblStaff.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStaff.Location = new System.Drawing.Point(36, 139);
            this.lblStaff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStaff.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(37, 19);
            this.lblStaff.TabIndex = 3;
            this.lblStaff.Text = "Staff";
            this.lblStaff.Visible = false;
            // 
            // btnEnter
            // 
            this.btnEnter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEnter.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEnter.Depth = 0;
            this.btnEnter.HighEmphasis = true;
            this.btnEnter.Icon = null;
            this.btnEnter.Location = new System.Drawing.Point(195, 118);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnEnter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEnter.Size = new System.Drawing.Size(79, 36);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "Unlock";
            this.btnEnter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEnter.UseAccentColor = false;
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Depth = 0;
            this.lblRole.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRole.Location = new System.Drawing.Point(402, 139);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 19);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "Role";
            this.lblRole.Visible = false;
            // 
            // lblUserSA
            // 
            this.lblUserSA.AutoSize = true;
            this.lblUserSA.Depth = 0;
            this.lblUserSA.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUserSA.Location = new System.Drawing.Point(327, 139);
            this.lblUserSA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserSA.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUserSA.Name = "lblUserSA";
            this.lblUserSA.Size = new System.Drawing.Size(52, 19);
            this.lblUserSA.TabIndex = 6;
            this.lblUserSA.Text = "UserSA";
            this.lblUserSA.Visible = false;
            // 
            // SystemLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 187);
            this.Controls.Add(this.lblUserSA);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lblStaff);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.materialLabel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemLock";
            this.Padding = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Lock";
            this.Load += new System.EventHandler(this.SystemLock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox tbPass;
        private MaterialSkin.Controls.MaterialLabel lblStaff;
        private MaterialSkin.Controls.MaterialButton btnEnter;
        private MaterialSkin.Controls.MaterialLabel lblRole;
        private MaterialSkin.Controls.MaterialLabel lblUserSA;
    }
}