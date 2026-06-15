namespace RKS_Inventory
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbUser = new MaterialSkin.Controls.MaterialTextBox();
            this.tbPass = new MaterialSkin.Controls.MaterialTextBox();
            this.btnLogin = new MaterialSkin.Controls.MaterialButton();
            this.btnOpenEyes = new MaterialSkin.Controls.MaterialButton();
            this.btnCloseEyes = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cbRemember = new MaterialSkin.Controls.MaterialCheckbox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(85, 217);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // tbUser
            // 
            this.tbUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbUser.AnimateReadOnly = false;
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUser.Depth = 0;
            this.tbUser.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbUser.Hint = "Username";
            this.tbUser.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("tbUser.LeadingIcon")));
            this.tbUser.Location = new System.Drawing.Point(481, 229);
            this.tbUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUser.MaxLength = 50;
            this.tbUser.MouseState = MaterialSkin.MouseState.OUT;
            this.tbUser.Multiline = false;
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(365, 50);
            this.tbUser.TabIndex = 8;
            this.tbUser.Text = "";
            this.tbUser.TrailingIcon = null;
            // 
            // tbPass
            // 
            this.tbPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbPass.AnimateReadOnly = false;
            this.tbPass.BackColor = System.Drawing.Color.White;
            this.tbPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPass.Depth = 0;
            this.tbPass.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPass.Hint = "Password";
            this.tbPass.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("tbPass.LeadingIcon")));
            this.tbPass.Location = new System.Drawing.Point(481, 319);
            this.tbPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPass.MaxLength = 50;
            this.tbPass.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPass.Multiline = false;
            this.tbPass.Name = "tbPass";
            this.tbPass.Password = true;
            this.tbPass.Size = new System.Drawing.Size(365, 50);
            this.tbPass.TabIndex = 9;
            this.tbPass.Text = "";
            this.tbPass.TrailingIcon = null;
            this.tbPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPass_KeyPress);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.AutoSize = false;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(589, 485);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLogin.Size = new System.Drawing.Size(159, 36);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "Login";
            this.btnLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = false;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnOpenEyes
            // 
            this.btnOpenEyes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpenEyes.AutoSize = false;
            this.btnOpenEyes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenEyes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOpenEyes.Depth = 0;
            this.btnOpenEyes.HighEmphasis = true;
            this.btnOpenEyes.Icon = ((System.Drawing.Image)(resources.GetObject("btnOpenEyes.Icon")));
            this.btnOpenEyes.Location = new System.Drawing.Point(796, 319);
            this.btnOpenEyes.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnOpenEyes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenEyes.Name = "btnOpenEyes";
            this.btnOpenEyes.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOpenEyes.Size = new System.Drawing.Size(51, 62);
            this.btnOpenEyes.TabIndex = 14;
            this.btnOpenEyes.Text = "Pass";
            this.btnOpenEyes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnOpenEyes.UseAccentColor = false;
            this.btnOpenEyes.UseVisualStyleBackColor = true;
            this.btnOpenEyes.Click += new System.EventHandler(this.btnOpenEyes_Click);
            // 
            // btnCloseEyes
            // 
            this.btnCloseEyes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCloseEyes.AutoSize = false;
            this.btnCloseEyes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCloseEyes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCloseEyes.Depth = 0;
            this.btnCloseEyes.HighEmphasis = true;
            this.btnCloseEyes.Icon = ((System.Drawing.Image)(resources.GetObject("btnCloseEyes.Icon")));
            this.btnCloseEyes.Location = new System.Drawing.Point(796, 319);
            this.btnCloseEyes.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnCloseEyes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCloseEyes.Name = "btnCloseEyes";
            this.btnCloseEyes.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCloseEyes.Size = new System.Drawing.Size(51, 62);
            this.btnCloseEyes.TabIndex = 15;
            this.btnCloseEyes.Text = "Pass";
            this.btnCloseEyes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnCloseEyes.UseAccentColor = false;
            this.btnCloseEyes.UseVisualStyleBackColor = true;
            this.btnCloseEyes.Click += new System.EventHandler(this.btnCloseEyes_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.materialLabel1.HighEmphasis = true;
            this.materialLabel1.Location = new System.Drawing.Point(517, 75);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialLabel1.Size = new System.Drawing.Size(230, 58);
            this.materialLabel1.TabIndex = 16;
            this.materialLabel1.Text = "WELCOME";
            // 
            // cbRemember
            // 
            this.cbRemember.AutoSize = true;
            this.cbRemember.Depth = 0;
            this.cbRemember.Location = new System.Drawing.Point(665, 388);
            this.cbRemember.Margin = new System.Windows.Forms.Padding(0);
            this.cbRemember.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbRemember.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbRemember.Name = "cbRemember";
            this.cbRemember.ReadOnly = false;
            this.cbRemember.Ripple = true;
            this.cbRemember.Size = new System.Drawing.Size(137, 37);
            this.cbRemember.TabIndex = 20;
            this.cbRemember.Text = "Remember me";
            this.cbRemember.UseVisualStyleBackColor = true;
            this.cbRemember.CheckedChanged += new System.EventHandler(this.cbRemember_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(933, 624);
            this.Controls.Add(this.cbRemember);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.btnOpenEyes);
            this.Controls.Add(this.btnCloseEyes);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.pictureBox1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(4, 30, 3, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox tbUser;
        private MaterialSkin.Controls.MaterialButton btnLogin;
        private MaterialSkin.Controls.MaterialButton btnCloseEyes;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton btnOpenEyes;
        private MaterialSkin.Controls.MaterialCheckbox cbRemember;
        public MaterialSkin.Controls.MaterialTextBox tbPass;
    }
}