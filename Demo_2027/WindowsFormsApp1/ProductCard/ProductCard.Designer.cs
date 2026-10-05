namespace DemoUIComponents
{
    partial class ProductCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DisposeProductImage();
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCard));
            this.CardLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ProductPictureBox = new System.Windows.Forms.PictureBox();
            this.FieldsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.PartsLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.CardLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).BeginInit();
            this.FieldsLayout.SuspendLayout();
            this.SuspendLayout();
            //
            // CardLayout
            //
            this.CardLayout.ColumnCount = 3;
            this.CardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.CardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CardLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.CardLayout.Controls.Add(this.ProductPictureBox, 0, 0);
            this.CardLayout.Controls.Add(this.FieldsLayout, 1, 0);
            this.CardLayout.Controls.Add(this.PriceLabel, 2, 0);
            this.CardLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardLayout.Location = new System.Drawing.Point(0, 0);
            this.CardLayout.Name = "CardLayout";
            this.CardLayout.Padding = new System.Windows.Forms.Padding(10);
            this.CardLayout.RowCount = 1;
            this.CardLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CardLayout.Size = new System.Drawing.Size(758, 188);
            this.CardLayout.TabIndex = 0;
            //
            // ProductPictureBox
            //
            this.ProductPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ProductPictureBox.Image")));
            this.ProductPictureBox.Location = new System.Drawing.Point(14, 14);
            this.ProductPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.ProductPictureBox.Name = "ProductPictureBox";
            this.ProductPictureBox.Size = new System.Drawing.Size(140, 160);
            this.ProductPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductPictureBox.TabIndex = 0;
            this.ProductPictureBox.TabStop = false;
            //
            // FieldsLayout
            //
            this.FieldsLayout.ColumnCount = 1;
            this.FieldsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FieldsLayout.Controls.Add(this.NameLabel, 0, 0);
            this.FieldsLayout.Controls.Add(this.CategoryLabel, 0, 1);
            this.FieldsLayout.Controls.Add(this.CountLabel, 0, 2);
            this.FieldsLayout.Controls.Add(this.PartsLabel, 0, 3);
            this.FieldsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FieldsLayout.Location = new System.Drawing.Point(168, 10);
            this.FieldsLayout.Margin = new System.Windows.Forms.Padding(10, 0, 6, 0);
            this.FieldsLayout.Name = "FieldsLayout";
            this.FieldsLayout.RowCount = 4;
            this.FieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.FieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.FieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.FieldsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FieldsLayout.Size = new System.Drawing.Size(418, 168);
            this.FieldsLayout.TabIndex = 1;
            //
            // NameLabel
            //
            this.NameLabel.AutoEllipsis = true;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(418, 42);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Производство | Наименование";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CategoryLabel
            //
            this.CategoryLabel.AutoEllipsis = true;
            this.CategoryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryLabel.Location = new System.Drawing.Point(0, 42);
            this.CategoryLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(418, 26);
            this.CategoryLabel.TabIndex = 1;
            this.CategoryLabel.Text = "Категория";
            this.CategoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // CountLabel
            //
            this.CountLabel.AutoEllipsis = true;
            this.CountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountLabel.Location = new System.Drawing.Point(0, 68);
            this.CountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(418, 26);
            this.CountLabel.TabIndex = 2;
            this.CountLabel.Text = "Количество";
            this.CountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // PartsLabel
            //
            this.PartsLabel.AutoEllipsis = true;
            this.PartsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PartsLabel.Location = new System.Drawing.Point(0, 94);
            this.PartsLabel.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.PartsLabel.Name = "PartsLabel";
            this.PartsLabel.Size = new System.Drawing.Size(418, 66);
            this.PartsLabel.TabIndex = 3;
            this.PartsLabel.Text = "Состав";
            this.PartsLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            //
            // PriceLabel
            //
            this.PriceLabel.AutoEllipsis = true;
            this.PriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PriceLabel.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular);
            this.PriceLabel.Location = new System.Drawing.Point(600, 10);
            this.PriceLabel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(148, 168);
            this.PriceLabel.TabIndex = 2;
            this.PriceLabel.Text = "0,00 ₽";
            this.PriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // ProductCard
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.CardLayout);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(760, 190);
            this.CardLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductPictureBox)).EndInit();
            this.FieldsLayout.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel CardLayout;
        private System.Windows.Forms.PictureBox ProductPictureBox;
        private System.Windows.Forms.TableLayoutPanel FieldsLayout;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label PartsLabel;
        private System.Windows.Forms.Label PriceLabel;
    }
}
