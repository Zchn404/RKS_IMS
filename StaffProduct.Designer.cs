namespace RKS_Inventory
{
    partial class StaffProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffProduct));
            this.dataProduct = new System.Windows.Forms.DataGridView();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rKS_InventoryDataSet = new RKS_Inventory.RKS_InventoryDataSet();
            this.tbSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.inventoryTableAdapter = new RKS_Inventory.RKS_InventoryDataSetTableAdapters.InventoryTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.productIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataProduct
            // 
            this.dataProduct.AllowUserToAddRows = false;
            this.dataProduct.AllowUserToDeleteRows = false;
            this.dataProduct.AllowUserToResizeColumns = false;
            this.dataProduct.AllowUserToResizeRows = false;
            this.dataProduct.AutoGenerateColumns = false;
            this.dataProduct.BackgroundColor = System.Drawing.Color.White;
            this.dataProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.brandDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.reOrderDataGridViewTextBoxColumn,
            this.categoryIdDataGridViewTextBoxColumn,
            this.brandIdDataGridViewTextBoxColumn,
            this.Select});
            this.dataProduct.DataSource = this.inventoryBindingSource;
            this.dataProduct.Location = new System.Drawing.Point(2, 99);
            this.dataProduct.Margin = new System.Windows.Forms.Padding(2);
            this.dataProduct.Name = "dataProduct";
            this.dataProduct.ReadOnly = true;
            this.dataProduct.RowHeadersVisible = false;
            this.dataProduct.RowHeadersWidth = 51;
            this.dataProduct.RowTemplate.Height = 24;
            this.dataProduct.Size = new System.Drawing.Size(769, 418);
            this.dataProduct.TabIndex = 9;
            this.dataProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProduct_CellContentClick);
            // 
            // inventoryBindingSource
            // 
            this.inventoryBindingSource.DataMember = "Inventory";
            this.inventoryBindingSource.DataSource = this.rKS_InventoryDataSet;
            // 
            // rKS_InventoryDataSet
            // 
            this.rKS_InventoryDataSet.DataSetName = "RKS_InventoryDataSet";
            this.rKS_InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbSearch
            // 
            this.tbSearch.AnimateReadOnly = false;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Depth = 0;
            this.tbSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbSearch.Hint = "Search";
            this.tbSearch.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("tbSearch.LeadingIcon")));
            this.tbSearch.Location = new System.Drawing.Point(21, 12);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSearch.Multiline = false;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(168, 50);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "";
            this.tbSearch.TrailingIcon = null;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Location = new System.Drawing.Point(0, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 73);
            this.panel1.TabIndex = 10;
            // 
            // productIdDataGridViewTextBoxColumn
            // 
            this.productIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.productIdDataGridViewTextBoxColumn.DataPropertyName = "Product_Id";
            this.productIdDataGridViewTextBoxColumn.HeaderText = "Id";
            this.productIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.productIdDataGridViewTextBoxColumn.Name = "productIdDataGridViewTextBoxColumn";
            this.productIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.productIdDataGridViewTextBoxColumn.Width = 41;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // brandDataGridViewTextBoxColumn
            // 
            this.brandDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.brandDataGridViewTextBoxColumn.DataPropertyName = "Brand";
            this.brandDataGridViewTextBoxColumn.HeaderText = "Brand";
            this.brandDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.brandDataGridViewTextBoxColumn.Name = "brandDataGridViewTextBoxColumn";
            this.brandDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 71;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 56;
            // 
            // reOrderDataGridViewTextBoxColumn
            // 
            this.reOrderDataGridViewTextBoxColumn.DataPropertyName = "Re_Order";
            this.reOrderDataGridViewTextBoxColumn.HeaderText = "Re_Order";
            this.reOrderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.reOrderDataGridViewTextBoxColumn.Name = "reOrderDataGridViewTextBoxColumn";
            this.reOrderDataGridViewTextBoxColumn.ReadOnly = true;
            this.reOrderDataGridViewTextBoxColumn.Visible = false;
            this.reOrderDataGridViewTextBoxColumn.Width = 125;
            // 
            // categoryIdDataGridViewTextBoxColumn
            // 
            this.categoryIdDataGridViewTextBoxColumn.DataPropertyName = "Category_Id";
            this.categoryIdDataGridViewTextBoxColumn.HeaderText = "Category_Id";
            this.categoryIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoryIdDataGridViewTextBoxColumn.Name = "categoryIdDataGridViewTextBoxColumn";
            this.categoryIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryIdDataGridViewTextBoxColumn.Visible = false;
            this.categoryIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // brandIdDataGridViewTextBoxColumn
            // 
            this.brandIdDataGridViewTextBoxColumn.DataPropertyName = "Brand_Id";
            this.brandIdDataGridViewTextBoxColumn.HeaderText = "Brand_Id";
            this.brandIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.brandIdDataGridViewTextBoxColumn.Name = "brandIdDataGridViewTextBoxColumn";
            this.brandIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.brandIdDataGridViewTextBoxColumn.Visible = false;
            this.brandIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Select.HeaderText = "";
            this.Select.Image = ((System.Drawing.Image)(resources.GetObject("Select.Image")));
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Width = 6;
            // 
            // StaffProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 521);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataProduct);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffProduct";
            this.Padding = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Product";
            this.Load += new System.EventHandler(this.StaffProduct_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StaffProduct_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataProduct;
        private MaterialSkin.Controls.MaterialTextBox tbSearch;
        private RKS_InventoryDataSet rKS_InventoryDataSet;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private RKS_InventoryDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Select;
    }
}