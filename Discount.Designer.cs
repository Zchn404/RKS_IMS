namespace RKS_Inventory
{
    partial class Discount
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.lblId = new MaterialSkin.Controls.MaterialLabel();
            this.tbTotal = new MaterialSkin.Controls.MaterialTextBox();
            this.tbDiscount = new MaterialSkin.Controls.MaterialTextBox();
            this.tbDiscountAmount = new MaterialSkin.Controls.MaterialTextBox();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(20, 98);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Total Price:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(20, 159);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(95, 19);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Discount (%):";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(20, 218);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(128, 19);
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Discount Amount:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Depth = 0;
            this.lblId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblId.Location = new System.Drawing.Point(20, 262);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(14, 19);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "id";
            this.lblId.Visible = false;
            // 
            // tbTotal
            // 
            this.tbTotal.AnimateReadOnly = false;
            this.tbTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTotal.Depth = 0;
            this.tbTotal.Enabled = false;
            this.tbTotal.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbTotal.LeadingIcon = null;
            this.tbTotal.Location = new System.Drawing.Point(153, 73);
            this.tbTotal.Margin = new System.Windows.Forms.Padding(2);
            this.tbTotal.MaxLength = 50;
            this.tbTotal.MouseState = MaterialSkin.MouseState.OUT;
            this.tbTotal.Multiline = false;
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(270, 50);
            this.tbTotal.TabIndex = 4;
            this.tbTotal.Text = "";
            this.tbTotal.TrailingIcon = null;
            // 
            // tbDiscount
            // 
            this.tbDiscount.AnimateReadOnly = false;
            this.tbDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDiscount.Depth = 0;
            this.tbDiscount.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbDiscount.Hint = "1-100%";
            this.tbDiscount.LeadingIcon = null;
            this.tbDiscount.Location = new System.Drawing.Point(153, 134);
            this.tbDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.tbDiscount.MaxLength = 50;
            this.tbDiscount.MouseState = MaterialSkin.MouseState.OUT;
            this.tbDiscount.Multiline = false;
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(270, 50);
            this.tbDiscount.TabIndex = 5;
            this.tbDiscount.Text = "";
            this.tbDiscount.TrailingIcon = null;
            this.tbDiscount.TextChanged += new System.EventHandler(this.tbDiscount_TextChanged);
            this.tbDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDiscount_KeyPress);
            // 
            // tbDiscountAmount
            // 
            this.tbDiscountAmount.AnimateReadOnly = false;
            this.tbDiscountAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDiscountAmount.Depth = 0;
            this.tbDiscountAmount.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbDiscountAmount.LeadingIcon = null;
            this.tbDiscountAmount.Location = new System.Drawing.Point(153, 193);
            this.tbDiscountAmount.Margin = new System.Windows.Forms.Padding(2);
            this.tbDiscountAmount.MaxLength = 50;
            this.tbDiscountAmount.MouseState = MaterialSkin.MouseState.OUT;
            this.tbDiscountAmount.Multiline = false;
            this.tbDiscountAmount.Name = "tbDiscountAmount";
            this.tbDiscountAmount.Size = new System.Drawing.Size(270, 50);
            this.tbDiscountAmount.TabIndex = 6;
            this.tbDiscountAmount.Text = "";
            this.tbDiscountAmount.TrailingIcon = null;
            this.tbDiscountAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDiscountAmount_KeyPress);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = null;
            this.btnConfirm.Location = new System.Drawing.Point(343, 254);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirm.Size = new System.Drawing.Size(86, 36);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // Discount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 301);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tbDiscountAmount);
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Discount";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount";
            this.Load += new System.EventHandler(this.Discount_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Discount_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel lblId;
        private MaterialSkin.Controls.MaterialTextBox tbTotal;
        private MaterialSkin.Controls.MaterialTextBox tbDiscount;
        private MaterialSkin.Controls.MaterialTextBox tbDiscountAmount;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
    }
}