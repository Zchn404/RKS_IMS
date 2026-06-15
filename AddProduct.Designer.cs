namespace RKS_Inventory
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblProId = new MaterialSkin.Controls.MaterialLabel();
            this.tbSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.dataProduct1 = new System.Windows.Forms.DataGridView();
            this.SP_Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.suppliersProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rKS_InventoryDataSet = new RKS_Inventory.RKS_InventoryDataSet();
            this.suppliersProductTableAdapter = new RKS_Inventory.RKS_InventoryDataSetTableAdapters.SuppliersProductTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProId);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 549);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 81);
            this.panel1.TabIndex = 1;
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
            this.lblProId.Size = new System.Drawing.Size(68, 19);
            this.lblProId.TabIndex = 17;
            this.lblProId.Text = "lblSuppId";
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
            this.SP_Id1,
            this.sPNameDataGridViewTextBoxColumn,
            this.sPPriceDataGridViewTextBoxColumn,
            this.supplierIdDataGridViewTextBoxColumn,
            this.Select1});
            this.dataProduct1.DataSource = this.suppliersProductBindingSource;
            this.dataProduct1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataProduct1.Location = new System.Drawing.Point(3, 64);
            this.dataProduct1.Margin = new System.Windows.Forms.Padding(2);
            this.dataProduct1.Name = "dataProduct1";
            this.dataProduct1.ReadOnly = true;
            this.dataProduct1.RowHeadersVisible = false;
            this.dataProduct1.RowHeadersWidth = 51;
            this.dataProduct1.RowTemplate.Height = 24;
            this.dataProduct1.Size = new System.Drawing.Size(594, 485);
            this.dataProduct1.TabIndex = 2;
            this.dataProduct1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProduct1_CellContentClick);
            // 
            // SP_Id1
            // 
            this.SP_Id1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SP_Id1.DataPropertyName = "SP_Id";
            this.SP_Id1.HeaderText = "SP_Id";
            this.SP_Id1.Name = "SP_Id1";
            this.SP_Id1.ReadOnly = true;
            this.SP_Id1.Visible = false;
            // 
            // sPNameDataGridViewTextBoxColumn
            // 
            this.sPNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sPNameDataGridViewTextBoxColumn.DataPropertyName = "SP_Name";
            this.sPNameDataGridViewTextBoxColumn.HeaderText = "SP_Name";
            this.sPNameDataGridViewTextBoxColumn.Name = "sPNameDataGridViewTextBoxColumn";
            this.sPNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sPPriceDataGridViewTextBoxColumn
            // 
            this.sPPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sPPriceDataGridViewTextBoxColumn.DataPropertyName = "SP_Price";
            this.sPPriceDataGridViewTextBoxColumn.HeaderText = "SP_Price";
            this.sPPriceDataGridViewTextBoxColumn.Name = "sPPriceDataGridViewTextBoxColumn";
            this.sPPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.sPPriceDataGridViewTextBoxColumn.Width = 76;
            // 
            // supplierIdDataGridViewTextBoxColumn
            // 
            this.supplierIdDataGridViewTextBoxColumn.DataPropertyName = "Supplier_Id";
            this.supplierIdDataGridViewTextBoxColumn.HeaderText = "Supplier_Id";
            this.supplierIdDataGridViewTextBoxColumn.Name = "supplierIdDataGridViewTextBoxColumn";
            this.supplierIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplierIdDataGridViewTextBoxColumn.Visible = false;
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
            // suppliersProductBindingSource
            // 
            this.suppliersProductBindingSource.DataMember = "SuppliersProduct";
            this.suppliersProductBindingSource.DataSource = this.rKS_InventoryDataSet;
            // 
            // rKS_InventoryDataSet
            // 
            this.rKS_InventoryDataSet.DataSetName = "RKS_InventoryDataSet";
            this.rKS_InventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // suppliersProductTableAdapter
            // 
            this.suppliersProductTableAdapter.ClearBeforeFill = true;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 633);
            this.Controls.Add(this.dataProduct1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProduct1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rKS_InventoryDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel lblProId;
        private MaterialSkin.Controls.MaterialTextBox tbSearch;
        private System.Windows.Forms.DataGridView dataProduct1;
        private RKS_InventoryDataSet rKS_InventoryDataSet;
        private System.Windows.Forms.BindingSource suppliersProductBindingSource;
        private RKS_InventoryDataSetTableAdapters.SuppliersProductTableAdapter suppliersProductTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn SP_Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sPPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn Select1;
    }
}