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
            this.PagesTabControl = new System.Windows.Forms.TabControl();
            this.CardsTabPage = new System.Windows.Forms.TabPage();
            this.OrdersTabPage = new System.Windows.Forms.TabPage();
            this.HeaderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.WindowTitleLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.UserAvatarPictureBox = new System.Windows.Forms.PictureBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserRoleLabel = new System.Windows.Forms.Label();
            this.ContentPanel.SuspendLayout();
            this.PagesTabControl.SuspendLayout();
            this.CardsTabPage.SuspendLayout();
            this.HeaderLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserAvatarPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.AutoScroll = true;
            this.MainLayout.BackColor = System.Drawing.Color.White;
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.MainLayout.Location = new System.Drawing.Point(4, 4);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Size = new System.Drawing.Size(1000, 584);
            this.MainLayout.TabIndex = 0;
            this.MainLayout.WrapContents = true;
            // ContentPanel
            this.ContentPanel.BackColor = System.Drawing.Color.White;
            this.ContentPanel.Controls.Add(this.PagesTabControl);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 100);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.ContentPanel.Size = new System.Drawing.Size(1040, 660);
            this.ContentPanel.TabIndex = 2;
            // PagesTabControl
            this.PagesTabControl.Controls.Add(this.CardsTabPage);
            this.PagesTabControl.Controls.Add(this.OrdersTabPage);
            this.PagesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagesTabControl.ItemSize = new System.Drawing.Size(160, 36);
            this.PagesTabControl.Location = new System.Drawing.Point(12, 12);
            this.PagesTabControl.Name = "PagesTabControl";
            this.PagesTabControl.SelectedIndex = 0;
            this.PagesTabControl.Size = new System.Drawing.Size(1016, 636);
            this.PagesTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.PagesTabControl.TabIndex = 0;
            this.PagesTabControl.SelectedIndexChanged += new System.EventHandler(this.PagesTabControl_SelectedIndexChanged);
            // CardsTabPage
            this.CardsTabPage.BackColor = System.Drawing.Color.White;
            this.CardsTabPage.Controls.Add(this.MainLayout);
            this.CardsTabPage.Location = new System.Drawing.Point(4, 40);
            this.CardsTabPage.Name = "CardsTabPage";
            this.CardsTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.CardsTabPage.Size = new System.Drawing.Size(1008, 592);
            this.CardsTabPage.TabIndex = 0;
            this.CardsTabPage.Text = "Карточки";
            // OrdersTabPage
            this.OrdersTabPage.BackColor = System.Drawing.Color.White;
            this.OrdersTabPage.Location = new System.Drawing.Point(4, 40);
            this.OrdersTabPage.Name = "OrdersTabPage";
            this.OrdersTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.OrdersTabPage.Size = new System.Drawing.Size(1008, 592);
            this.OrdersTabPage.TabIndex = 1;
            this.OrdersTabPage.Text = "Заказы";
            // HeaderLayout
            this.HeaderLayout.BackColor = System.Drawing.Color.FromArgb(210, 246, 231);
            this.HeaderLayout.ColumnCount = 4;
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.HeaderLayout.Controls.Add(this.WindowTitleLabel, 0, 0);
            this.HeaderLayout.Controls.Add(this.LogoPictureBox, 1, 0);
            this.HeaderLayout.Controls.Add(this.UserNameLabel, 2, 0);
            this.HeaderLayout.Controls.Add(this.UserRoleLabel, 2, 1);
            this.HeaderLayout.Controls.Add(this.UserAvatarPictureBox, 3, 0);
            this.HeaderLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderLayout.Location = new System.Drawing.Point(0, 0);
            this.HeaderLayout.Name = "HeaderLayout";
            this.HeaderLayout.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.HeaderLayout.RowCount = 2;
            this.HeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.HeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.HeaderLayout.Size = new System.Drawing.Size(1040, 100);
            this.HeaderLayout.TabIndex = 0;
            // WindowTitleLabel
            this.WindowTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowTitleLabel.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold);
            this.WindowTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.WindowTitleLabel.Name = "WindowTitleLabel";
            this.HeaderLayout.SetRowSpan(this.WindowTitleLabel, 2);
            this.WindowTitleLabel.Size = new System.Drawing.Size(379, 84);
            this.WindowTitleLabel.Text = "Карточки товаров";
            this.WindowTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // LogoPictureBox
            this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.HeaderLayout.SetRowSpan(this.LogoPictureBox, 2);
            this.LogoPictureBox.Size = new System.Drawing.Size(84, 84);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabStop = false;
            // UserAvatarPictureBox
            this.UserAvatarPictureBox.AccessibleName = "Профиль пользователя";
            this.UserAvatarPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserAvatarPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("UserAvatarPictureBox.Image")));
            this.UserAvatarPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserAvatarPictureBox.Name = "UserAvatarPictureBox";
            this.HeaderLayout.SetRowSpan(this.UserAvatarPictureBox, 2);
            this.UserAvatarPictureBox.Size = new System.Drawing.Size(64, 84);
            this.UserAvatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserAvatarPictureBox.TabStop = false;
            // UserNameLabel
            this.UserNameLabel.AutoEllipsis = true;
            this.UserNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 8, 4);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Text = "Гость";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // UserRoleLabel
            this.UserRoleLabel.AutoEllipsis = true;
            this.UserRoleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRoleLabel.Font = new System.Drawing.Font("Calibri", 10F);
            this.UserRoleLabel.ForeColor = System.Drawing.Color.FromArgb(65, 85, 80);
            this.UserRoleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.UserRoleLabel.Name = "UserRoleLabel";
            this.UserRoleLabel.Text = "Гостевой режим";
            this.UserRoleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 760);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.HeaderLayout);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(960, 620);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чудо Обувь — Карточки";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ContentPanel.ResumeLayout(false);
            this.PagesTabControl.ResumeLayout(false);
            this.CardsTabPage.ResumeLayout(false);
            this.HeaderLayout.ResumeLayout(false);
            this.HeaderLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserAvatarPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel MainLayout;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TabControl PagesTabControl;
        private System.Windows.Forms.TabPage CardsTabPage;
        private System.Windows.Forms.TabPage OrdersTabPage;
        private System.Windows.Forms.TableLayoutPanel HeaderLayout;
        private System.Windows.Forms.Label WindowTitleLabel;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.PictureBox UserAvatarPictureBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label UserRoleLabel;
    }
}

