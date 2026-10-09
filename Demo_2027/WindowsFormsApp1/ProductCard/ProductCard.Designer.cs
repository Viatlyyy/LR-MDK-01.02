namespace DemoUIComponents
{
    partial class ProductCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCard));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.PartsLabel = new System.Windows.Forms.Label();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.SupplierLabel = new System.Windows.Forms.Label();
            this.PriceProductLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F);
            this.label1.Location = new System.Drawing.Point(210, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Категория";
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11F);
            this.label2.Location = new System.Drawing.Point(210, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количество";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.label3.Location = new System.Drawing.Point(210, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Состав";
            //
            // CategoryLabel
            //
            this.CategoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.CategoryLabel.AutoEllipsis = true;
            this.CategoryLabel.Font = new System.Drawing.Font("Calibri", 12F);
            this.CategoryLabel.Location = new System.Drawing.Point(332, 52);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(380, 24);
            this.CategoryLabel.TabIndex = 3;
            this.CategoryLabel.Text = "";
            //
            // CountLabel
            //
            this.CountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.CountLabel.AutoEllipsis = true;
            this.CountLabel.Font = new System.Drawing.Font("Calibri", 11F);
            this.CountLabel.Location = new System.Drawing.Point(332, 81);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(380, 20);
            this.CountLabel.TabIndex = 4;
            this.CountLabel.Text = "";
            //
            // PartsLabel
            //
            this.PartsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.PartsLabel.AutoEllipsis = true;
            this.PartsLabel.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.PartsLabel.Location = new System.Drawing.Point(263, 106);
            this.PartsLabel.Name = "PartsLabel";
            this.PartsLabel.Size = new System.Drawing.Size(449, 40);
            this.PartsLabel.TabIndex = 5;
            this.PartsLabel.Text = "";
            //
            // ImagePictureBox
            //
            this.ImagePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ImagePictureBox.Image")));
            this.ImagePictureBox.Location = new System.Drawing.Point(10, 10);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(180, 135);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePictureBox.TabIndex = 6;
            this.ImagePictureBox.TabStop = false;
            //
            // SupplierLabel
            //
            this.SupplierLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierLabel.AutoEllipsis = true;
            this.SupplierLabel.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.SupplierLabel.Location = new System.Drawing.Point(204, 8);
            this.SupplierLabel.Name = "SupplierLabel";
            this.SupplierLabel.Size = new System.Drawing.Size(690, 36);
            this.SupplierLabel.TabIndex = 8;
            this.SupplierLabel.Text = "Производство | Наименование";
            this.SupplierLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // PriceProductLabel
            //
            this.PriceProductLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PriceProductLabel.AutoEllipsis = true;
            this.PriceProductLabel.Font = new System.Drawing.Font("Calibri", 18F);
            this.PriceProductLabel.Location = new System.Drawing.Point(732, 48);
            this.PriceProductLabel.Name = "PriceProductLabel";
            this.PriceProductLabel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.PriceProductLabel.Size = new System.Drawing.Size(166, 98);
            this.PriceProductLabel.TabIndex = 11;
            this.PriceProductLabel.Text = "0,00 ₽";
            this.PriceProductLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // ProductCard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(210, 246, 231);
            this.Controls.Add(this.PriceProductLabel);
            this.Controls.Add(this.SupplierLabel);
            this.Controls.Add(this.ImagePictureBox);
            this.Controls.Add(this.PartsLabel);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(900, 156);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProductCard_Paint);
            this.MouseLeave += new System.EventHandler(this.ProductCard_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProductCard_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label PartsLabel;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.Label SupplierLabel;
        private System.Windows.Forms.Label PriceProductLabel;
    }
}
