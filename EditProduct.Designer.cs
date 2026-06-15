namespace RKS_Inventory
{
    partial class EditProduct
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
            this.tbName = new MaterialSkin.Controls.MaterialTextBox();
            this.tbPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.btnEdit = new MaterialSkin.Controls.MaterialButton();
            this.lblid = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.AnimateReadOnly = false;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Depth = 0;
            this.tbName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbName.Hint = "Name";
            this.tbName.LeadingIcon = null;
            this.tbName.Location = new System.Drawing.Point(44, 67);
            this.tbName.MaxLength = 50;
            this.tbName.MouseState = MaterialSkin.MouseState.OUT;
            this.tbName.Multiline = false;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(250, 50);
            this.tbName.TabIndex = 0;
            this.tbName.Text = "";
            this.tbName.TrailingIcon = null;
            // 
            // tbPrice
            // 
            this.tbPrice.AnimateReadOnly = false;
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.Depth = 0;
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPrice.Hint = "Price";
            this.tbPrice.LeadingIcon = null;
            this.tbPrice.Location = new System.Drawing.Point(44, 142);
            this.tbPrice.MaxLength = 50;
            this.tbPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPrice.Multiline = false;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(250, 50);
            this.tbPrice.TabIndex = 1;
            this.tbPrice.Text = "";
            this.tbPrice.TrailingIcon = null;
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEdit.Depth = 0;
            this.btnEdit.HighEmphasis = true;
            this.btnEdit.Icon = null;
            this.btnEdit.Location = new System.Drawing.Point(129, 222);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEdit.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnEdit.Size = new System.Drawing.Size(77, 36);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Update";
            this.btnEdit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEdit.UseAccentColor = false;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEdit_KeyDown);
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Depth = 0;
            this.lblid.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblid.Location = new System.Drawing.Point(41, 232);
            this.lblid.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(11, 19);
            this.lblid.TabIndex = 3;
            this.lblid.Text = "#";
            this.lblid.Visible = false;
            // 
            // EditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 285);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbName);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProduct";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditProduct";
            this.Load += new System.EventHandler(this.EditProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox tbName;
        private MaterialSkin.Controls.MaterialTextBox tbPrice;
        private MaterialSkin.Controls.MaterialButton btnEdit;
        private MaterialSkin.Controls.MaterialLabel lblid;
    }
}