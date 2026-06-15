namespace RKS_Inventory
{
    partial class Quantity
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
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.tbQuantity = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbQuantity
            // 
            this.tbQuantity.AnimateReadOnly = false;
            this.tbQuantity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbQuantity.Depth = 0;
            this.tbQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQuantity.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tbQuantity.Hint = "Input a number";
            this.tbQuantity.LeadingIcon = null;
            this.tbQuantity.Location = new System.Drawing.Point(3, 24);
            this.tbQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.tbQuantity.MaxLength = 50;
            this.tbQuantity.MouseState = MaterialSkin.MouseState.OUT;
            this.tbQuantity.Multiline = false;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbQuantity.Size = new System.Drawing.Size(194, 50);
            this.tbQuantity.TabIndex = 0;
            this.tbQuantity.Text = "";
            this.tbQuantity.TrailingIcon = null;
            this.tbQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQuantity_KeyPress);
            // 
            // Quantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 78);
            this.Controls.Add(this.tbQuantity);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Quantity";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quantity";
            this.Load += new System.EventHandler(this.Quantity_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Quantity_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        private MaterialSkin.Controls.MaterialTextBox tbQuantity;
    }
}