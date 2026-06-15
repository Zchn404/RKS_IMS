namespace RKS_Inventory
{
    partial class Reset
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
            this.tbNew = new MaterialSkin.Controls.MaterialTextBox();
            this.tbNewP = new MaterialSkin.Controls.MaterialTextBox();
            this.btnReset = new MaterialSkin.Controls.MaterialButton();
            this.lbluser = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.tbverifcode = new MaterialSkin.Controls.MaterialTextBox();
            this.tbuseremail = new MaterialSkin.Controls.MaterialTextBox();
            this.btnvcsubmit = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(59, 193);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(110, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "New Password:";
            this.materialLabel1.Visible = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(59, 249);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(168, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Confirm new password:";
            this.materialLabel2.Visible = false;
            // 
            // tbNew
            // 
            this.tbNew.AnimateReadOnly = false;
            this.tbNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNew.Depth = 0;
            this.tbNew.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbNew.Hint = "New";
            this.tbNew.LeadingIcon = null;
            this.tbNew.Location = new System.Drawing.Point(246, 168);
            this.tbNew.Margin = new System.Windows.Forms.Padding(2);
            this.tbNew.MaxLength = 50;
            this.tbNew.MouseState = MaterialSkin.MouseState.OUT;
            this.tbNew.Multiline = false;
            this.tbNew.Name = "tbNew";
            this.tbNew.Password = true;
            this.tbNew.Size = new System.Drawing.Size(200, 50);
            this.tbNew.TabIndex = 2;
            this.tbNew.Text = "";
            this.tbNew.TrailingIcon = null;
            this.tbNew.Visible = false;
            // 
            // tbNewP
            // 
            this.tbNewP.AnimateReadOnly = false;
            this.tbNewP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNewP.Depth = 0;
            this.tbNewP.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbNewP.Hint = "Re-type";
            this.tbNewP.LeadingIcon = null;
            this.tbNewP.Location = new System.Drawing.Point(246, 223);
            this.tbNewP.Margin = new System.Windows.Forms.Padding(2);
            this.tbNewP.MaxLength = 50;
            this.tbNewP.MouseState = MaterialSkin.MouseState.OUT;
            this.tbNewP.Multiline = false;
            this.tbNewP.Name = "tbNewP";
            this.tbNewP.Password = true;
            this.tbNewP.Size = new System.Drawing.Size(200, 50);
            this.tbNewP.TabIndex = 3;
            this.tbNewP.Text = "";
            this.tbNewP.TrailingIcon = null;
            this.tbNewP.Visible = false;
            this.tbNewP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNewP_KeyPress);
            // 
            // btnReset
            // 
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReset.Depth = 0;
            this.btnReset.HighEmphasis = true;
            this.btnReset.Icon = null;
            this.btnReset.Location = new System.Drawing.Point(396, 291);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReset.Size = new System.Drawing.Size(65, 36);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReset.UseAccentColor = false;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Depth = 0;
            this.lbluser.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbluser.Location = new System.Drawing.Point(59, 291);
            this.lbluser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbluser.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(31, 19);
            this.lbluser.TabIndex = 5;
            this.lbluser.Text = "user";
            this.lbluser.Visible = false;
            this.lbluser.Click += new System.EventHandler(this.lbluser_Click);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.materialLabel3.Location = new System.Drawing.Point(179, 87);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(148, 24);
            this.materialLabel3.TabIndex = 6;
            this.materialLabel3.Text = "OTP Verification";
            // 
            // tbverifcode
            // 
            this.tbverifcode.AnimateReadOnly = false;
            this.tbverifcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbverifcode.Depth = 0;
            this.tbverifcode.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbverifcode.Hint = "Enter verification code";
            this.tbverifcode.LeadingIcon = null;
            this.tbverifcode.Location = new System.Drawing.Point(87, 249);
            this.tbverifcode.MaxLength = 50;
            this.tbverifcode.MouseState = MaterialSkin.MouseState.OUT;
            this.tbverifcode.Multiline = false;
            this.tbverifcode.Name = "tbverifcode";
            this.tbverifcode.Size = new System.Drawing.Size(327, 50);
            this.tbverifcode.TabIndex = 7;
            this.tbverifcode.Text = "";
            this.tbverifcode.TrailingIcon = null;
            // 
            // tbuseremail
            // 
            this.tbuseremail.AnimateReadOnly = false;
            this.tbuseremail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbuseremail.Depth = 0;
            this.tbuseremail.Enabled = false;
            this.tbuseremail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbuseremail.Hint = "Email";
            this.tbuseremail.LeadingIcon = null;
            this.tbuseremail.Location = new System.Drawing.Point(87, 178);
            this.tbuseremail.MaxLength = 50;
            this.tbuseremail.MouseState = MaterialSkin.MouseState.OUT;
            this.tbuseremail.Multiline = false;
            this.tbuseremail.Name = "tbuseremail";
            this.tbuseremail.Size = new System.Drawing.Size(327, 50);
            this.tbuseremail.TabIndex = 8;
            this.tbuseremail.Text = "";
            this.tbuseremail.TrailingIcon = null;
            // 
            // btnvcsubmit
            // 
            this.btnvcsubmit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnvcsubmit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnvcsubmit.Depth = 0;
            this.btnvcsubmit.HighEmphasis = true;
            this.btnvcsubmit.Icon = null;
            this.btnvcsubmit.Location = new System.Drawing.Point(224, 330);
            this.btnvcsubmit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnvcsubmit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnvcsubmit.Name = "btnvcsubmit";
            this.btnvcsubmit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnvcsubmit.Size = new System.Drawing.Size(75, 36);
            this.btnvcsubmit.TabIndex = 9;
            this.btnvcsubmit.Text = "Submit";
            this.btnvcsubmit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnvcsubmit.UseAccentColor = false;
            this.btnvcsubmit.UseVisualStyleBackColor = true;
            this.btnvcsubmit.Click += new System.EventHandler(this.tbvcsubmit_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.HighEmphasis = true;
            this.materialLabel4.Location = new System.Drawing.Point(104, 128);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(310, 19);
            this.materialLabel4.TabIndex = 10;
            this.materialLabel4.Text = "We\'ve sent a verification code to your email.";
            // 
            // Reset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 391);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.btnvcsubmit);
            this.Controls.Add(this.tbuseremail);
            this.Controls.Add(this.tbverifcode);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.tbNewP);
            this.Controls.Add(this.tbNew);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reset";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset";
            this.Load += new System.EventHandler(this.Reset_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox tbNew;
        private MaterialSkin.Controls.MaterialTextBox tbNewP;
        private MaterialSkin.Controls.MaterialButton btnReset;
        private MaterialSkin.Controls.MaterialLabel lbluser;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox tbverifcode;
        private MaterialSkin.Controls.MaterialTextBox tbuseremail;
        private MaterialSkin.Controls.MaterialButton btnvcsubmit;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}