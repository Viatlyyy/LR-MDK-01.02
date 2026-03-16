namespace RestaurantOrder
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbMenuGroups = new System.Windows.Forms.ListBox();
            this.llblGroupHeader = new System.Windows.Forms.Label();
            this.cbMenuItems = new System.Windows.Forms.ComboBox();
            this.lblItemHeader = new System.Windows.Forms.Label();
            this.pbItemImage = new System.Windows.Forms.PictureBox();
            this.lblQuantityHeader = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnOrder = new System.Windows.Forms.Button();
            this.rtbOrderSummary = new System.Windows.Forms.RichTextBox();
            this.toolTipManager = new System.Windows.Forms.ToolTip(this.components);
            this.lblItemDetails = new System.Windows.Forms.Label();
            this.lblDetailsHeader = new System.Windows.Forms.Label();
            this.btnLoadData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMenuGroups
            // 
            this.lbMenuGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMenuGroups.FormattingEnabled = true;
            this.lbMenuGroups.Location = new System.Drawing.Point(1, 5);
            this.lbMenuGroups.Name = "lbMenuGroups";
            this.lbMenuGroups.Size = new System.Drawing.Size(120, 433);
            this.lbMenuGroups.TabIndex = 0;
            this.lbMenuGroups.SelectedIndexChanged += new System.EventHandler(this.lbMenuGroups_SelectedIndexChanged);
            // 
            // llblGroupHeader
            // 
            this.llblGroupHeader.AutoSize = true;
            this.llblGroupHeader.Location = new System.Drawing.Point(137, 35);
            this.llblGroupHeader.Name = "llblGroupHeader";
            this.llblGroupHeader.Size = new System.Drawing.Size(124, 13);
            this.llblGroupHeader.TabIndex = 1;
            this.llblGroupHeader.Text = "Выберите группу меню";
            // 
            // cbMenuItems
            // 
            this.cbMenuItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMenuItems.FormattingEnabled = true;
            this.cbMenuItems.Location = new System.Drawing.Point(140, 64);
            this.cbMenuItems.Name = "cbMenuItems";
            this.cbMenuItems.Size = new System.Drawing.Size(166, 21);
            this.cbMenuItems.TabIndex = 2;
            this.cbMenuItems.SelectedIndexChanged += new System.EventHandler(this.cbMenuItems_SelectedIndexChanged);
            // 
            // lblItemHeader
            // 
            this.lblItemHeader.AutoSize = true;
            this.lblItemHeader.Location = new System.Drawing.Point(138, 102);
            this.lblItemHeader.Name = "lblItemHeader";
            this.lblItemHeader.Size = new System.Drawing.Size(92, 13);
            this.lblItemHeader.TabIndex = 3;
            this.lblItemHeader.Text = "Выберите блюдо";
            // 
            // pbItemImage
            // 
            this.pbItemImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbItemImage.Location = new System.Drawing.Point(420, 52);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Size = new System.Drawing.Size(383, 251);
            this.pbItemImage.TabIndex = 4;
            this.pbItemImage.TabStop = false;
            // 
            // lblQuantityHeader
            // 
            this.lblQuantityHeader.AutoSize = true;
            this.lblQuantityHeader.Location = new System.Drawing.Point(138, 144);
            this.lblQuantityHeader.Name = "lblQuantityHeader";
            this.lblQuantityHeader.Size = new System.Drawing.Size(66, 13);
            this.lblQuantityHeader.TabIndex = 5;
            this.lblQuantityHeader.Text = "Количество";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(141, 171);
            this.nudQuantity.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudQuantity.TabIndex = 6;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(141, 322);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 7;
            this.btnOrder.Text = "Заказать";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // rtbOrderSummary
            // 
            this.rtbOrderSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOrderSummary.Location = new System.Drawing.Point(140, 204);
            this.rtbOrderSummary.Name = "rtbOrderSummary";
            this.rtbOrderSummary.Size = new System.Drawing.Size(203, 96);
            this.rtbOrderSummary.TabIndex = 8;
            this.rtbOrderSummary.Text = "";
            // 
            // lblItemDetails
            // 
            this.lblItemDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemDetails.AutoSize = true;
            this.lblItemDetails.Location = new System.Drawing.Point(335, 397);
            this.lblItemDetails.Name = "lblItemDetails";
            this.lblItemDetails.Size = new System.Drawing.Size(35, 13);
            this.lblItemDetails.TabIndex = 9;
            this.lblItemDetails.Text = "label1";
            // 
            // lblDetailsHeader
            // 
            this.lblDetailsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDetailsHeader.AutoSize = true;
            this.lblDetailsHeader.Location = new System.Drawing.Point(417, 18);
            this.lblDetailsHeader.Name = "lblDetailsHeader";
            this.lblDetailsHeader.Size = new System.Drawing.Size(89, 13);
            this.lblDetailsHeader.TabIndex = 10;
            this.lblDetailsHeader.Text = "Карточка блюда";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(141, 376);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 11;
            this.btnLoadData.Text = "Загрузка";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 450);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.lblDetailsHeader);
            this.Controls.Add(this.lblItemDetails);
            this.Controls.Add(this.rtbOrderSummary);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblQuantityHeader);
            this.Controls.Add(this.pbItemImage);
            this.Controls.Add(this.lblItemHeader);
            this.Controls.Add(this.cbMenuItems);
            this.Controls.Add(this.llblGroupHeader);
            this.Controls.Add(this.lbMenuGroups);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbMenuGroups;
        private System.Windows.Forms.Label llblGroupHeader;
        private System.Windows.Forms.ComboBox cbMenuItems;
        private System.Windows.Forms.Label lblItemHeader;
        private System.Windows.Forms.PictureBox pbItemImage;
        private System.Windows.Forms.Label lblQuantityHeader;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.RichTextBox rtbOrderSummary;
        private System.Windows.Forms.ToolTip toolTipManager;
        private System.Windows.Forms.Label lblItemDetails;
        private System.Windows.Forms.Label lblDetailsHeader;
        private System.Windows.Forms.Button btnLoadData;
    }
}

