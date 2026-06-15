namespace RKS_Inventory
{
    partial class UpdateUser
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
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.tbUser = new MaterialSkin.Controls.MaterialTextBox();
            this.tbFn = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.cbRole = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.tbPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.cbStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(70, 100);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(78, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "UserName:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(70, 217);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(73, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "FullName:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(70, 279);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(36, 19);
            this.materialLabel4.TabIndex = 3;
            this.materialLabel4.Text = "Role:";
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(426, 400);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(77, 36);
            this.materialButton3.TabIndex = 15;
            this.materialButton3.Text = "Update";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // tbUser
            // 
            this.tbUser.AnimateReadOnly = false;
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUser.Depth = 0;
            this.tbUser.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbUser.Hint = "User";
            this.tbUser.LeadingIcon = null;
            this.tbUser.Location = new System.Drawing.Point(172, 74);
            this.tbUser.Margin = new System.Windows.Forms.Padding(2);
            this.tbUser.MaxLength = 50;
            this.tbUser.MouseState = MaterialSkin.MouseState.OUT;
            this.tbUser.Multiline = false;
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(302, 50);
            this.tbUser.TabIndex = 16;
            this.tbUser.Text = "";
            this.tbUser.TrailingIcon = null;
            // 
            // tbFn
            // 
            this.tbFn.AnimateReadOnly = false;
            this.tbFn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFn.Depth = 0;
            this.tbFn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbFn.LeadingIcon = null;
            this.tbFn.Location = new System.Drawing.Point(172, 192);
            this.tbFn.Margin = new System.Windows.Forms.Padding(2);
            this.tbFn.MaxLength = 50;
            this.tbFn.MouseState = MaterialSkin.MouseState.OUT;
            this.tbFn.Multiline = false;
            this.tbFn.Name = "tbFn";
            this.tbFn.Size = new System.Drawing.Size(302, 50);
            this.tbFn.TabIndex = 17;
            this.tbFn.Text = "FullName";
            this.tbFn.TrailingIcon = null;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(58, 410);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(14, 19);
            this.materialLabel5.TabIndex = 20;
            this.materialLabel5.Text = "Id";
            this.materialLabel5.Visible = false;
            // 
            // cbRole
            // 
            this.cbRole.AutoResize = false;
            this.cbRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbRole.Depth = 0;
            this.cbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbRole.DropDownHeight = 174;
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.DropDownWidth = 121;
            this.cbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbRole.FormattingEnabled = true;
            this.cbRole.IntegralHeight = false;
            this.cbRole.ItemHeight = 43;
            this.cbRole.Items.AddRange(new object[] {
            "Administrator",
            "Staff"});
            this.cbRole.Location = new System.Drawing.Point(172, 262);
            this.cbRole.Margin = new System.Windows.Forms.Padding(2);
            this.cbRole.MaxDropDownItems = 4;
            this.cbRole.MouseState = MaterialSkin.MouseState.OUT;
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(233, 49);
            this.cbRole.StartIndex = 0;
            this.cbRole.TabIndex = 21;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(70, 154);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(50, 19);
            this.materialLabel3.TabIndex = 22;
            this.materialLabel3.Text = "Phone:";
            // 
            // tbPhone
            // 
            this.tbPhone.AnimateReadOnly = false;
            this.tbPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPhone.Depth = 0;
            this.tbPhone.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPhone.Hint = "Phone";
            this.tbPhone.LeadingIcon = null;
            this.tbPhone.Location = new System.Drawing.Point(172, 128);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(2);
            this.tbPhone.MaxLength = 50;
            this.tbPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPhone.Multiline = false;
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(302, 50);
            this.tbPhone.TabIndex = 24;
            this.tbPhone.Text = "";
            this.tbPhone.TrailingIcon = null;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(70, 346);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(51, 19);
            this.materialLabel7.TabIndex = 26;
            this.materialLabel7.Text = "Status:";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoResize = false;
            this.cbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbStatus.Depth = 0;
            this.cbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbStatus.DropDownHeight = 174;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.DropDownWidth = 121;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.IntegralHeight = false;
            this.cbStatus.ItemHeight = 43;
            this.cbStatus.Items.AddRange(new object[] {
            "Active",
            "Resigned"});
            this.cbStatus.Location = new System.Drawing.Point(172, 321);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cbStatus.MaxDropDownItems = 4;
            this.cbStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(233, 49);
            this.cbStatus.StartIndex = 0;
            this.cbStatus.TabIndex = 27;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // UpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 463);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.tbFn);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateUser";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateUser";
            this.Load += new System.EventHandler(this.UpdateUser_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UpdateUser_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialTextBox tbUser;
        private MaterialSkin.Controls.MaterialTextBox tbFn;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialComboBox cbRole;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox tbPhone;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialComboBox cbStatus;
    }
}