namespace RKS_Inventory
{
    partial class EditOrders
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
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.cbStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.btnUpdate = new MaterialSkin.Controls.MaterialButton();
            this.lblId = new MaterialSkin.Controls.MaterialLabel();
            this.tbRB = new MaterialSkin.Controls.MaterialTextBox();
            this.lblRB = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(11, 117);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(51, 19);
            this.materialLabel2.TabIndex = 18;
            this.materialLabel2.Text = "Status:";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoResize = false;
            this.cbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbStatus.Depth = 0;
            this.cbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbStatus.DropDownHeight = 174;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.DropDownWidth = 121;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.IntegralHeight = false;
            this.cbStatus.ItemHeight = 43;
            this.cbStatus.Items.AddRange(new object[] {
            "On The Way",
            "Delivered",
            "Cancelled"});
            this.cbStatus.Location = new System.Drawing.Point(117, 87);
            this.cbStatus.MaxDropDownItems = 4;
            this.cbStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(225, 49);
            this.cbStatus.StartIndex = 0;
            this.cbStatus.TabIndex = 19;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUpdate.Depth = 0;
            this.btnUpdate.HighEmphasis = true;
            this.btnUpdate.Icon = null;
            this.btnUpdate.Location = new System.Drawing.Point(157, 280);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdate.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUpdate.Size = new System.Drawing.Size(77, 36);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUpdate.UseAccentColor = false;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblId.Location = new System.Drawing.Point(10, 297);
            this.lblId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(14, 19);
            this.lblId.TabIndex = 21;
            this.lblId.Text = "id";
            this.lblId.Visible = false;
            // 
            // tbRB
            // 
            this.tbRB.AnimateReadOnly = false;
            this.tbRB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbRB.Depth = 0;
            this.tbRB.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbRB.LeadingIcon = null;
            this.tbRB.Location = new System.Drawing.Point(117, 180);
            this.tbRB.MaxLength = 50;
            this.tbRB.MouseState = MaterialSkin.MouseState.OUT;
            this.tbRB.Multiline = false;
            this.tbRB.Name = "tbRB";
            this.tbRB.Size = new System.Drawing.Size(225, 50);
            this.tbRB.TabIndex = 22;
            this.tbRB.Text = "";
            this.tbRB.TrailingIcon = null;
            this.tbRB.Visible = false;
            // 
            // lblRB
            // 
            this.lblRB.AutoSize = true;
            this.lblRB.Depth = 0;
            this.lblRB.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRB.Location = new System.Drawing.Point(11, 211);
            this.lblRB.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRB.Name = "lblRB";
            this.lblRB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRB.Size = new System.Drawing.Size(90, 19);
            this.lblRB.TabIndex = 23;
            this.lblRB.Text = "Received By:";
            this.lblRB.Visible = false;
            // 
            // EditOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 343);
            this.Controls.Add(this.lblRB);
            this.Controls.Add(this.tbRB);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.materialLabel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.EditOrders_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditOrders_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox cbStatus;
        private MaterialSkin.Controls.MaterialButton btnUpdate;
        private MaterialSkin.Controls.MaterialLabel lblId;
        private MaterialSkin.Controls.MaterialTextBox tbRB;
        private MaterialSkin.Controls.MaterialLabel lblRB;
    }
}