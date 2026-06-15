namespace RKS_Inventory
{
    partial class ProductStockIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductStockIn));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProId = new MaterialSkin.Controls.MaterialLabel();
            this.tbSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.Product_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewImageColumn();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rKS_InventoryDataSet = new RKS_Inventory.RKS_InventoryDataSet();
            this.stocksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stocksTableAdapter = new RKS_Inventory.RKS_InventoryDataSetTableAdapters.StocksTableAdapter();
            this.inventoryTableAdapter = new RKS_Inventory.RKS_InventoryDataSetTableAdapters.InventoryTableAdapter();
            this.dataProduct1 = new System.Windows.Forms.DataGridView();
            this.Product_Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProId);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 550);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 81);
            this.panel1.TabIndex = 0;
            // 
            // lblProId
            // 
            this.lblProId.AutoSize = true;
            this.lblProId.Depth = 0;
            this.lblProId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblProId.Location = new System.Drawing.Point(54, 42);
            this.lblProId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblProId.Name = "lblProId";
            this.lblProId.Size = new System.Drawing.Size(55, 19);
            this.lblProId.TabIndex = 17;
            this.lblProId.Text = "lblProId";
            this.lblProId.Visible = false;
            // 
            // tbSearch
            // 
            this.tbSearch.AnimateReadOnly = false;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Depth = 0;
            this.tbSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbSearch.Hint = "Search Product";
            this.tbSearch.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("tbSearch.LeadingIcon")));
            this.tbSearch.Location = new System.Drawing.Point(170, 26);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSearch.Multiline = false;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(283, 50);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "";
            this.tbSearch.TrailingIcon = null;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // Product_Id
            // 
            this.Product_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Product_Id.DataPropertyName = "Product_Id";
            this.Product_Id.HeaderText = "Id";
            this.Product_Id.MinimumWidth = 6;
            this.Product_Id.Name = "Product_Id";
            this.Product_Id.ReadOnly = true;
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
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Select
            // 
            this.Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Select.HeaderText = "";
            this.Select.Image = ((System.Drawing.Image)(resources.GetObject("Select.Image")));
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
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
            // stocksBindingSource
            // 
            this.stocksBindingSource.DataMember = "Stocks";
            this.stocksBindingSource.DataSource = this.rKS_InventoryDataSet;
            // 
            // stocksTableAdapter
            // 
            this.stocksTableAdapter.ClearBeforeFill = true;
            // 
            // inventoryTableAdapter
            // 
            this.inventoryTableAdapter.ClearBeforeFill = true;
            // 
            // dataProduct1
            // 
            this.dataProduct1.AllowUserToAddRows = false;
            this.dataProduct1.AllowUserToDeleteRows = false;
            this.dataProduct1.AllowUserToResizeColumns = false;
            this.dataProduct1.AllowUserToResizeRows = false;
            this.dataProduct1.AutoGenerateColumns = false;
            this.dataProduct1.BackgroundColor = System.Drawing.Color.White;
            this.dataProduct1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataProduct1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProduct1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_Id1,
            this.nameDataGridViewTextBoxColumn1,
            this.brandDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn1,
            this.categoryDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.reOrderDataGridViewTextBoxColumn,
            this.categoryIdDataGridViewTextBoxColumn,
            this.brandIdDataGridViewTextBoxColumn,
            this.Select1});
            this.dataProduct1.DataSource = this.inventoryBindingSource;
            this.dataProduct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataProduct1.Location = new System.Drawing.Point(2, 52);
            this.dataProduct1.Margin = new System.Windows.Forms.Padding(2);
            this.dataProduct1.Name = "dataProduct1";
            this.dataProduct1.ReadOnly = true;
            this.dataProduct1.RowHeadersVisible = false;
            this.dataProduct1.RowHeadersWidth = 51;
            this.dataProduct1.RowTemplate.Height = 24;
            this.dataProduct1.Size = new System.Drawing.Size(596, 498);
            this.dataProduct1.TabIndex = 1;
            this.dataProduct1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProduct1_CellContentClick);
            // 
            // Product_Id1
            // 
            this.Product_Id1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Product_Id1.DataPropertyName = "Product_Id";
            this.Product_Id1.HeaderText = "Id";
            this.Product_Id1.MinimumWidth = 6;
            this.Product_Id1.Name = "Product_Id1";
            this.Product_Id1.ReadOnly = true;
            this.Product_Id1.Width = 41;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // brandDataGridViewTextBoxColumn
            // 
            this.brandDataGridViewTextBoxColumn.DataPropertyName = "Brand";
            this.brandDataGridViewTextBoxColumn.HeaderText = "Brand";
            this.brandDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.brandDataGridViewTextBoxColumn.Name = "brandDataGridViewTextBoxColumn";
            this.brandDataGridViewTextBoxColumn.ReadOnly = true;
            this.brandDataGridViewTextBoxColumn.Visible = false;
            this.brandDataGridViewTextBoxColumn.Width = 125;
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            this.quantityDataGridViewTextBoxColumn1.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn1.Width = 71;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Visible = false;
            this.categoryDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Visible = false;
            this.priceDataGridViewTextBoxColumn.Width = 125;
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
            // Select1
            // 
            this.Select1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Select1.HeaderText = "";
            this.Select1.Image = ((System.Drawing.Image)(resources.GetObject("Select1.Image")));
            this.Select1.MinimumWidth = 6;
            this.Select1.Name = "Select1";
            this.Select1.ReadOnly = true;
            this.Select1.Width = 6;
            // 
            // ProductStockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 633);
            this.Controls.Add(this.dataProduct1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductStockIn";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Stock-In";
            this.Load += new System.EventHandler(this.ProductStockIn_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stocksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialTextBox tbSearch;
        private System.Windows.Forms.DataGridView dataProduct;
        private RKS_InventoryDataSet rKS_InventoryDataSet;
        private System.Windows.Forms.BindingSource stocksBindingSource;
        private RKS_InventoryDataSetTableAdapters.StocksTableAdapter stocksTableAdapter;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private RKS_InventoryDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Select;
        private MaterialSkin.Controls.MaterialLabel lblProId;
        private System.Windows.Forms.DataGridView dataProduct1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Select1;
    }
}