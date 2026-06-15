namespace RKS_Inventory
{
    partial class InventoryAdd
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cbBrand = new MaterialSkin.Controls.MaterialComboBox();
            this.cbCategory = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.btnItemAdd = new MaterialSkin.Controls.MaterialButton();
            this.lblId = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(158, 424);
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
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbBrand
            // 
            this.cbBrand.AutoResize = false;
            this.cbBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbBrand.Depth = 0;
            this.cbBrand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbBrand.DropDownHeight = 174;
            this.cbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrand.DropDownWidth = 121;
            this.cbBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Hint = "Select Brand";
            this.cbBrand.IntegralHeight = false;
            this.cbBrand.ItemHeight = 43;
            this.cbBrand.Location = new System.Drawing.Point(158, 253);
            this.cbBrand.Margin = new System.Windows.Forms.Padding(2);
            this.cbBrand.MaxDropDownItems = 4;
            this.cbBrand.MouseState = MaterialSkin.MouseState.OUT;
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(247, 49);
            this.cbBrand.StartIndex = 0;
            this.cbBrand.TabIndex = 11;
            this.cbBrand.SelectedIndexChanged += new System.EventHandler(this.cbBrand_SelectedIndexChanged);
            // 
            // cbCategory
            // 
            this.cbCategory.AutoResize = false;
            this.cbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbCategory.Depth = 0;
            this.cbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbCategory.DropDownHeight = 174;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.DropDownWidth = 121;
            this.cbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Hint = "Select Category";
            this.cbCategory.IntegralHeight = false;
            this.cbCategory.ItemHeight = 43;
            this.cbCategory.Location = new System.Drawing.Point(158, 169);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbCategory.MaxDropDownItems = 4;
            this.cbCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(247, 49);
            this.cbCategory.StartIndex = 0;
            this.cbCategory.TabIndex = 12;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(68, 194);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(68, 19);
            this.materialLabel1.TabIndex = 13;
            this.materialLabel1.Text = "Category:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(84, 277);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(47, 19);
            this.materialLabel2.TabIndex = 14;
            this.materialLabel2.Text = "Brand:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(84, 119);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(47, 19);
            this.materialLabel3.TabIndex = 15;
            this.materialLabel3.Text = "Name:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(89, 353);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(40, 19);
            this.materialLabel4.TabIndex = 16;
            this.materialLabel4.Text = "Price:";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(70, 426);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(65, 19);
            this.materialLabel5.TabIndex = 17;
            this.materialLabel5.Text = "Re-Order:";
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.Hint = "Name";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(158, 94);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MaxLength = 50;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 50);
            this.txtName.TabIndex = 18;
            this.txtName.Text = "";
            this.txtName.TrailingIcon = null;
            // 
            // txtPrice
            // 
            this.txtPrice.AnimateReadOnly = false;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Depth = 0;
            this.txtPrice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrice.Hint = "Price";
            this.txtPrice.LeadingIcon = null;
            this.txtPrice.Location = new System.Drawing.Point(158, 328);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrice.MaxLength = 50;
            this.txtPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPrice.Multiline = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(246, 50);
            this.txtPrice.TabIndex = 19;
            this.txtPrice.Text = "";
            this.txtPrice.TrailingIcon = null;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnItemAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnItemAdd.Depth = 0;
            this.btnItemAdd.HighEmphasis = true;
            this.btnItemAdd.Icon = null;
            this.btnItemAdd.Location = new System.Drawing.Point(230, 512);
            this.btnItemAdd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnItemAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnItemAdd.Size = new System.Drawing.Size(88, 36);
            this.btnItemAdd.TabIndex = 20;
            this.btnItemAdd.Text = "Add Item";
            this.btnItemAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnItemAdd.UseAccentColor = false;
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblId.Location = new System.Drawing.Point(68, 520);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(11, 19);
            this.lblId.TabIndex = 21;
            this.lblId.Text = "#";
            this.lblId.Visible = false;
            // 
            // InventoryAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 640);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnItemAdd);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbBrand);
            this.Controls.Add(this.numericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventoryAdd";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.InventoryAdd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InventoryAdd_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MaterialSkin.Controls.MaterialComboBox cbBrand;
        private MaterialSkin.Controls.MaterialComboBox cbCategory;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialTextBox txtPrice;
        private MaterialSkin.Controls.MaterialButton btnItemAdd;
        private MaterialSkin.Controls.MaterialLabel lblId;
    }
}