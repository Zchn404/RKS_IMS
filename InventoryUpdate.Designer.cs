namespace RKS_Inventory
{
    partial class InventoryUpdate
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
            this.tbPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.tbName = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.tbProductId = new MaterialSkin.Controls.MaterialTextBox();
            this.btnItemUpdate = new MaterialSkin.Controls.MaterialButton();
            this.tbBrand = new MaterialSkin.Controls.MaterialTextBox();
            this.tbCategory = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPrice
            // 
            this.tbPrice.AnimateReadOnly = false;
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.Depth = 0;
            this.tbPrice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbPrice.LeadingIcon = null;
            this.tbPrice.Location = new System.Drawing.Point(222, 313);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tbPrice.MaxLength = 50;
            this.tbPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.tbPrice.Multiline = false;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(246, 50);
            this.tbPrice.TabIndex = 52;
            this.tbPrice.Text = "";
            this.tbPrice.TrailingIcon = null;
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // tbName
            // 
            this.tbName.AnimateReadOnly = false;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Depth = 0;
            this.tbName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbName.LeadingIcon = null;
            this.tbName.Location = new System.Drawing.Point(338, 87);
            this.tbName.Margin = new System.Windows.Forms.Padding(2);
            this.tbName.MaxLength = 50;
            this.tbName.MouseState = MaterialSkin.MouseState.OUT;
            this.tbName.Multiline = false;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(246, 50);
            this.tbName.TabIndex = 51;
            this.tbName.Text = "";
            this.tbName.TrailingIcon = null;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(133, 398);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(65, 19);
            this.materialLabel5.TabIndex = 50;
            this.materialLabel5.Text = "Re-Order:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(152, 339);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(40, 19);
            this.materialLabel4.TabIndex = 49;
            this.materialLabel4.Text = "Price:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(289, 112);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(47, 19);
            this.materialLabel3.TabIndex = 48;
            this.materialLabel3.Text = "Name:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(147, 263);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(47, 19);
            this.materialLabel2.TabIndex = 47;
            this.materialLabel2.Text = "Brand:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(131, 179);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 19);
            this.materialLabel1.TabIndex = 46;
            this.materialLabel1.Text = "Category:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(222, 395);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(138, 20);
            this.numericUpDown1.TabIndex = 43;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(40, 112);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(18, 19);
            this.materialLabel6.TabIndex = 53;
            this.materialLabel6.Text = "Id:";
            // 
            // tbProductId
            // 
            this.tbProductId.AnimateReadOnly = false;
            this.tbProductId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProductId.Depth = 0;
            this.tbProductId.Enabled = false;
            this.tbProductId.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbProductId.LeadingIcon = null;
            this.tbProductId.Location = new System.Drawing.Point(67, 87);
            this.tbProductId.Margin = new System.Windows.Forms.Padding(2);
            this.tbProductId.MaxLength = 50;
            this.tbProductId.MouseState = MaterialSkin.MouseState.OUT;
            this.tbProductId.Multiline = false;
            this.tbProductId.Name = "tbProductId";
            this.tbProductId.Size = new System.Drawing.Size(206, 50);
            this.tbProductId.TabIndex = 54;
            this.tbProductId.Text = "";
            this.tbProductId.TrailingIcon = null;
            // 
            // btnItemUpdate
            // 
            this.btnItemUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnItemUpdate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnItemUpdate.Depth = 0;
            this.btnItemUpdate.HighEmphasis = true;
            this.btnItemUpdate.Icon = null;
            this.btnItemUpdate.Location = new System.Drawing.Point(274, 463);
            this.btnItemUpdate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnItemUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnItemUpdate.Name = "btnItemUpdate";
            this.btnItemUpdate.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnItemUpdate.Size = new System.Drawing.Size(115, 36);
            this.btnItemUpdate.TabIndex = 55;
            this.btnItemUpdate.Text = "Update Item";
            this.btnItemUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnItemUpdate.UseAccentColor = false;
            this.btnItemUpdate.UseVisualStyleBackColor = true;
            this.btnItemUpdate.Click += new System.EventHandler(this.btnItemUpdate_Click);
            // 
            // tbBrand
            // 
            this.tbBrand.AnimateReadOnly = false;
            this.tbBrand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBrand.Depth = 0;
            this.tbBrand.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbBrand.LeadingIcon = null;
            this.tbBrand.Location = new System.Drawing.Point(222, 154);
            this.tbBrand.Margin = new System.Windows.Forms.Padding(2);
            this.tbBrand.MaxLength = 50;
            this.tbBrand.MouseState = MaterialSkin.MouseState.OUT;
            this.tbBrand.Multiline = false;
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(246, 50);
            this.tbBrand.TabIndex = 56;
            this.tbBrand.Text = "";
            this.tbBrand.TrailingIcon = null;
            // 
            // tbCategory
            // 
            this.tbCategory.AnimateReadOnly = false;
            this.tbCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCategory.Depth = 0;
            this.tbCategory.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbCategory.LeadingIcon = null;
            this.tbCategory.Location = new System.Drawing.Point(222, 238);
            this.tbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.tbCategory.MaxLength = 50;
            this.tbCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.tbCategory.Multiline = false;
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(246, 50);
            this.tbCategory.TabIndex = 57;
            this.tbCategory.Text = "";
            this.tbCategory.TrailingIcon = null;
            // 
            // InventoryUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 581);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.tbBrand);
            this.Controls.Add(this.btnItemUpdate);
            this.Controls.Add(this.tbProductId);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.numericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryUpdate";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Update";
            this.Load += new System.EventHandler(this.InventoryUpdate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InventoryUpdate_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox tbPrice;
        private MaterialSkin.Controls.MaterialTextBox tbName;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox tbProductId;
        private MaterialSkin.Controls.MaterialButton btnItemUpdate;
        private MaterialSkin.Controls.MaterialTextBox tbBrand;
        private MaterialSkin.Controls.MaterialTextBox tbCategory;
    }
}