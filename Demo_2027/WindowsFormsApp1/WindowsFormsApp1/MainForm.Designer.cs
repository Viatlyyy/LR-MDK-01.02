namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.OrdersPanel = new System.Windows.Forms.Panel();
            this.NavigationLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.CardsButton = new System.Windows.Forms.Button();
            this.OrdersButton = new System.Windows.Forms.Button();
            this.HeaderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.WindowTitleLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.UserInfoPanel = new System.Windows.Forms.Panel();
            this.UserTextLayout = new System.Windows.Forms.TableLayoutPanel();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserRoleLabel = new System.Windows.Forms.Label();
            this.UserStatusPictureBox = new System.Windows.Forms.PictureBox();
            this.ContentPanel.SuspendLayout();
            this.NavigationLayout.SuspendLayout();
            this.HeaderLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.UserInfoPanel.SuspendLayout();
            this.UserTextLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserStatusPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.AutoScroll = true;
            this.MainLayout.BackColor = System.Drawing.Color.White;
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MainLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.MainLayout.Location = new System.Drawing.Point(12, 12);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Size = new System.Drawing.Size(1016, 586);
            this.MainLayout.TabIndex = 0;
            this.MainLayout.WrapContents = false;
            // ContentPanel
            this.ContentPanel.BackColor = System.Drawing.Color.White;
            this.ContentPanel.Controls.Add(this.OrdersPanel);
            this.ContentPanel.Controls.Add(this.MainLayout);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 150);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.ContentPanel.Size = new System.Drawing.Size(1040, 610);
            this.ContentPanel.TabIndex = 2;
            // OrdersPanel
            this.OrdersPanel.BackColor = System.Drawing.Color.White;
            this.OrdersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersPanel.Location = new System.Drawing.Point(12, 12);
            this.OrdersPanel.Name = "OrdersPanel";
            this.OrdersPanel.Size = new System.Drawing.Size(1016, 586);
            this.OrdersPanel.Visible = false;
            // NavigationLayout
            this.NavigationLayout.BackColor = System.Drawing.Color.White;
            this.NavigationLayout.Controls.Add(this.CardsButton);
            this.NavigationLayout.Controls.Add(this.OrdersButton);
            this.NavigationLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.NavigationLayout.Location = new System.Drawing.Point(0, 100);
            this.NavigationLayout.Name = "NavigationLayout";
            this.NavigationLayout.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);
            this.NavigationLayout.Size = new System.Drawing.Size(1040, 50);
            this.NavigationLayout.TabIndex = 1;
            this.NavigationLayout.WrapContents = false;
            // CardsButton
            this.CardsButton.BackColor = System.Drawing.Color.FromArgb(112, 178, 175);
            this.CardsButton.FlatAppearance.BorderSize = 0;
            this.CardsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CardsButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.CardsButton.Name = "CardsButton";
            this.CardsButton.Size = new System.Drawing.Size(160, 36);
            this.CardsButton.TabIndex = 0;
            this.CardsButton.Text = "Карточки";
            this.CardsButton.UseVisualStyleBackColor = false;
            this.CardsButton.Click += new System.EventHandler(this.CardsButton_Click);
            // OrdersButton
            this.OrdersButton.BackColor = System.Drawing.Color.FromArgb(210, 246, 231);
            this.OrdersButton.FlatAppearance.BorderSize = 0;
            this.OrdersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrdersButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.OrdersButton.Name = "OrdersButton";
            this.OrdersButton.Size = new System.Drawing.Size(160, 36);
            this.OrdersButton.TabIndex = 1;
            this.OrdersButton.Text = "Заказы";
            this.OrdersButton.UseVisualStyleBackColor = false;
            this.OrdersButton.Click += new System.EventHandler(this.OrdersButton_Click);
            // HeaderLayout
            this.HeaderLayout.BackColor = System.Drawing.Color.FromArgb(210, 246, 231);
            this.HeaderLayout.ColumnCount = 3;
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.HeaderLayout.Controls.Add(this.WindowTitleLabel, 0, 0);
            this.HeaderLayout.Controls.Add(this.LogoPictureBox, 1, 0);
            this.HeaderLayout.Controls.Add(this.UserInfoPanel, 2, 0);
            this.HeaderLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderLayout.Location = new System.Drawing.Point(0, 0);
            this.HeaderLayout.Name = "HeaderLayout";
            this.HeaderLayout.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.HeaderLayout.RowCount = 1;
            this.HeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeaderLayout.Size = new System.Drawing.Size(1040, 100);
            this.HeaderLayout.TabIndex = 0;
            // WindowTitleLabel
            this.WindowTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowTitleLabel.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold);
            this.WindowTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.WindowTitleLabel.Name = "WindowTitleLabel";
            this.WindowTitleLabel.Size = new System.Drawing.Size(408, 84);
            this.WindowTitleLabel.Text = "Карточки товаров";
            this.WindowTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // LogoPictureBox
            this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(84, 84);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabStop = false;
            // UserInfoPanel
            this.UserInfoPanel.Controls.Add(this.UserTextLayout);
            this.UserInfoPanel.Controls.Add(this.UserStatusPictureBox);
            this.UserInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserInfoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UserInfoPanel.Name = "UserInfoPanel";
            this.UserInfoPanel.Size = new System.Drawing.Size(500, 84);
            // UserTextLayout
            this.UserTextLayout.ColumnCount = 1;
            this.UserTextLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UserTextLayout.Controls.Add(this.UserNameLabel, 0, 0);
            this.UserTextLayout.Controls.Add(this.UserRoleLabel, 0, 1);
            this.UserTextLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserTextLayout.Name = "UserTextLayout";
            this.UserTextLayout.RowCount = 2;
            this.UserTextLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.UserTextLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.UserTextLayout.Size = new System.Drawing.Size(448, 84);
            // UserNameLabel
            this.UserNameLabel.AutoEllipsis = true;
            this.UserNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 8, 4);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Text = "Фамилия Имя Отчество";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // UserRoleLabel
            this.UserRoleLabel.AutoEllipsis = true;
            this.UserRoleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRoleLabel.Font = new System.Drawing.Font("Calibri", 10F);
            this.UserRoleLabel.ForeColor = System.Drawing.Color.FromArgb(65, 85, 80);
            this.UserRoleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.UserRoleLabel.Name = "UserRoleLabel";
            this.UserRoleLabel.Text = "Пользователь";
            this.UserRoleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // UserStatusPictureBox
            this.UserStatusPictureBox.AccessibleName = "Статус пользователя";
            this.UserStatusPictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.UserStatusPictureBox.Name = "UserStatusPictureBox";
            this.UserStatusPictureBox.Size = new System.Drawing.Size(52, 84);
            this.UserStatusPictureBox.TabStop = false;
            this.UserStatusPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.UserStatusPictureBox_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 760);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.NavigationLayout);
            this.Controls.Add(this.HeaderLayout);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 620);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чудо Обувь — Карточки";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ContentPanel.ResumeLayout(false);
            this.NavigationLayout.ResumeLayout(false);
            this.NavigationLayout.PerformLayout();
            this.HeaderLayout.ResumeLayout(false);
            this.HeaderLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.UserInfoPanel.ResumeLayout(false);
            this.UserInfoPanel.PerformLayout();
            this.UserTextLayout.ResumeLayout(false);
            this.UserTextLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserStatusPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MainLayout;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel OrdersPanel;
        private System.Windows.Forms.FlowLayoutPanel NavigationLayout;
        private System.Windows.Forms.Button CardsButton;
        private System.Windows.Forms.Button OrdersButton;
        private System.Windows.Forms.TableLayoutPanel HeaderLayout;
        private System.Windows.Forms.Label WindowTitleLabel;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Panel UserInfoPanel;
        private System.Windows.Forms.TableLayoutPanel UserTextLayout;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label UserRoleLabel;
        private System.Windows.Forms.PictureBox UserStatusPictureBox;
    }
}

