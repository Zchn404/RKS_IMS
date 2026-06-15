namespace RKS_Inventory
{
    partial class SupplierProduct
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierProduct));
            this.txtPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox();
            this.lblId = new MaterialSkin.Controls.MaterialLabel();
            this.btnItemAdd = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.dataSuppProduct = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.rKS_InventoryDataSet = new RKS_Inventory.RKS_InventoryDataSet();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryTableAdapter = new RKS_Inventory.RKS_InventoryDataSetTableAdapters.InventoryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSuppProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.AnimateReadOnly = false;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Depth = 0;
            this.txtPrice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrice.Hint = "Price";
            this.txtPrice.LeadingIcon = null;
            this.txtPrice.Location = new System.Drawing.Point(298, 91);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrice.MaxLength = 50;
            this.txtPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPrice.Multiline = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(143, 50);
            this.txtPrice.TabIndex = 27;
            this.txtPrice.Text = "";
            this.txtPrice.TrailingIcon = null;
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.Hint = "Name";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(30, 91);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.MaxLength = 50;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 50);
            this.txtName.TabIndex = 26;
            this.txtName.Text = "";
            this.txtName.TrailingIcon = null;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblId.Location = new System.Drawing.Point(466, 110);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(11, 19);
            this.lblId.TabIndex = 28;
            this.lblId.Text = "#";
            this.lblId.Visible = false;
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnItemAdd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnItemAdd.Depth = 0;
            this.btnItemAdd.HighEmphasis = true;
            this.btnItemAdd.Icon = null;
            this.btnItemAdd.Location = new System.Drawing.Point(503, 100);
            this.btnItemAdd.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnItemAdd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnItemAdd.Size = new System.Drawing.Size(121, 36);
            this.btnItemAdd.TabIndex = 29;
            this.btnItemAdd.Text = "Add Product";
            this.btnItemAdd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnItemAdd.UseAccentColor = false;
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Top;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 64);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(662, 103);
            this.materialCard1.TabIndex = 30;
            // 
            // dataSuppProduct
            // 
            this.dataSuppProduct.AllowUserToAddRows = false;
            this.dataSuppProduct.AllowUserToDeleteRows = false;
            this.dataSuppProduct.AllowUserToResizeColumns = false;
            this.dataSuppProduct.AllowUserToResizeRows = false;
            this.dataSuppProduct.BackgroundColor = System.Drawing.Color.White;
            this.dataSuppProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataSuppProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSuppProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Edit3});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataSuppProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataSuppProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataSuppProduct.Location = new System.Drawing.Point(3, 167);
            this.dataSuppProduct.Margin = new System.Windows.Forms.Padding(2);
            this.dataSuppProduct.Name = "dataSuppProduct";
            this.dataSuppProduct.ReadOnly = true;
            this.dataSuppProduct.RowHeadersVisible = false;
            this.dataSuppProduct.RowHeadersWidth = 51;
            this.dataSuppProduct.RowTemplate.Height = 24;
            this.dataSuppProduct.Size = new System.Drawing.Size(662, 337);
            this.dataSuppProduct.TabIndex = 31;
            this.dataSuppProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSuppProduct_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.DataPropertyName = "SP_Id";
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "SP_Name";
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "SP_Price";
            this.Column3.HeaderText = "Price";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 56;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "Supplier_Id";
            this.Column4.HeaderText = "Supplier_Id";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Edit3
            // 
            this.Edit3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit3.HeaderText = "";
            this.Edit3.Image = ((System.Drawing.Image)(resources.GetObject("Edit3.Image")));
            this.Edit3.MinimumWidth = 6;
            this.Edit3.Name = "Edit3";
            this.Edit3.ReadOnly = true;
            this.Edit3.Width = 6;
            // 
            // rKS_InventoryDataSet
            // 
            this.rKS_InventoryDataSet.DataSetName = "RKS_InventoryDataSet";
            this.rKS_InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryBindingSource
            // 
            this.inventoryBindingSource.DataMember = "Inventory";
            this.inventoryBindingSource.DataSource = this.rKS_InventoryDataSet;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // SupplierProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 507);
            this.Controls.Add(this.dataSuppProduct);
            this.Controls.Add(this.btnItemAdd);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.materialCard1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Product";
            this.Load += new System.EventHandler(this.SupplierProduct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SupplierProduct_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataSuppProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtPrice;
        private MaterialSkin.Controls.MaterialTextBox txtName;
        private MaterialSkin.Controls.MaterialLabel lblId;
        private MaterialSkin.Controls.MaterialButton btnItemAdd;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.DataGridView dataSuppProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn Edit3;
        private RKS_InventoryDataSet rKS_InventoryDataSet;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private RKS_InventoryDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
    }
}