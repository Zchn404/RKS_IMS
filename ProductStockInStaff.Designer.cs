namespace RKS_Inventory
{
    partial class ProductStockInStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductStockInStaff));
            this.dataProduct1 = new System.Windows.Forms.DataGridView();
            this.lblProId = new MaterialSkin.Controls.MaterialLabel();
            this.tbSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rKS_InventoryDataSet = new RKS_Inventory.RKS_InventoryDataSet();
            this.inventoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryTableAdapter = new RKS_Inventory.RKS_InventoryDataSetTableAdapters.InventoryTableAdapter();
            this.Product_Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.nameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.Select1});
            this.dataProduct1.DataSource = this.inventoryBindingSource;
            this.dataProduct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataProduct1.Location = new System.Drawing.Point(3, 64);
            this.dataProduct1.Name = "dataProduct1";
            this.dataProduct1.ReadOnly = true;
            this.dataProduct1.RowHeadersVisible = false;
            this.dataProduct1.RowHeadersWidth = 51;
            this.dataProduct1.RowTemplate.Height = 24;
            this.dataProduct1.Size = new System.Drawing.Size(794, 612);
            this.dataProduct1.TabIndex = 3;
            this.dataProduct1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProduct1_CellContentClick);
            // 
            // lblProId
            // 
            this.lblProId.AutoSize = true;
            this.lblProId.Depth = 0;
            this.lblProId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblProId.Location = new System.Drawing.Point(72, 52);
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
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbSearch.Hint = "Search Product";
            this.tbSearch.LeadingIcon = ((System.Drawing.Image)(resources.GetObject("tbSearch.LeadingIcon")));
            this.tbSearch.Location = new System.Drawing.Point(227, 32);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.tbSearch.Multiline = false;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(377, 50);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "";
            this.tbSearch.TrailingIcon = null;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProId);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 676);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 100);
            this.panel1.TabIndex = 2;
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
            // Product_Id1
            // 
            this.Product_Id1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Product_Id1.DataPropertyName = "Product_Id";
            this.Product_Id1.HeaderText = "Id";
            this.Product_Id1.MinimumWidth = 6;
            this.Product_Id1.Name = "Product_Id1";
            this.Product_Id1.ReadOnly = true;
            this.Product_Id1.Width = 47;
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
            this.quantityDataGridViewTextBoxColumn.Width = 84;
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
            // ProductStockInStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 779);
            this.Controls.Add(this.dataProduct1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductStockInStaff";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Stock In";
            this.Load += new System.EventHandler(this.ProductStockInStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataProduct1;
        private MaterialSkin.Controls.MaterialLabel lblProId;
        private MaterialSkin.Controls.MaterialTextBox tbSearch;
        private System.Windows.Forms.Panel panel1;
        private RKS_InventoryDataSet rKS_InventoryDataSet;
        private System.Windows.Forms.BindingSource inventoryBindingSource;
        private RKS_InventoryDataSetTableAdapters.InventoryTableAdapter inventoryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Select1;
    }
}