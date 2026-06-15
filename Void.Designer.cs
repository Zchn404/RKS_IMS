namespace RKS_Inventory
{
    partial class Void
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
            this.tbUser = new MaterialSkin.Controls.MaterialTextBox();
            this.tbPass = new MaterialSkin.Controls.MaterialTextBox();
            this.btnVoid = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // tbUser
            // 
            this.tbUser.AnimateReadOnly = false;
            this.tbUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUser.Depth = 0;
            this.tbUser.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbUser.Hint = "Username";
            this.tbUser.LeadingIcon = null;
            this.tbUser.Location = new System.Drawing.Point(29, 82);
            this.tbUser.MaxLength = 50;
            this.tbUser.MouseState = MaterialSkin.MouseState.OUT;
            this.tbUser.Multiline = false;
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(318, 50);
            this.tbUser.TabIndex = 0;
            this.tbUser.Text = "";
            this.tbUser.TrailingIcon = null;
            // 
            // tbPass
            // 
            this.tbPass.AnimateReadOnly = false;
            this.tbPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPass.Depth = 0;
            this.tbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPass.Hint = "Password";
            this.tbPass.LeadingIcon = null;
            this.tbPass.Location = new System.Drawing.Point(29, 154);
            this.tbPass.MaxLength = 50;
            this.tbPass.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPass.Multiline = false;
            this.tbPass.Name = "tbPass";
            this.tbPass.Password = true;
            this.tbPass.Size = new System.Drawing.Size(318, 50);
            this.tbPass.TabIndex = 1;
            this.tbPass.Text = "";
            this.tbPass.TrailingIcon = null;
            this.tbPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPass_KeyPress);
            // 
            // btnVoid
            // 
            this.btnVoid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVoid.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnVoid.Depth = 0;
            this.btnVoid.HighEmphasis = true;
            this.btnVoid.Icon = null;
            this.btnVoid.Location = new System.Drawing.Point(156, 213);
            this.btnVoid.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnVoid.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnVoid.Size = new System.Drawing.Size(64, 36);
            this.btnVoid.TabIndex = 2;
            this.btnVoid.Text = "Void";
            this.btnVoid.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnVoid.UseAccentColor = false;
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            // 
            // Void
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 267);
            this.Controls.Add(this.btnVoid);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Void";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Void";
            this.Load += new System.EventHandler(this.Void_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialTextBox tbPass;
        private MaterialSkin.Controls.MaterialButton btnVoid;
        public MaterialSkin.Controls.MaterialTextBox tbUser;
    }
}