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
            this.MainLayout = new BufferedFlowLayoutPanel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.PagesTabControl = new System.Windows.Forms.TabControl();
            this.CardsTabPage = new System.Windows.Forms.TabPage();
            this.CatalogToolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CatalogSortLabel = new System.Windows.Forms.Label();
            this.SortComboBox = new System.Windows.Forms.ComboBox();
            this.SearchNameLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.OrdersTabPage = new System.Windows.Forms.TabPage();
            this.HeaderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.WindowTitleLabel = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserRoleLabel = new System.Windows.Forms.Label();
            this.UserAvatarPictureBox = new System.Windows.Forms.PictureBox();
            this.ContentPanel.SuspendLayout();
            this.PagesTabControl.SuspendLayout();
            this.CardsTabPage.SuspendLayout();
            this.CatalogToolsPanel.SuspendLayout();
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
            this.MainLayout.Location = new System.Drawing.Point(4, 47);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.Size = new System.Drawing.Size(1000, 497);
            this.MainLayout.TabIndex = 1;
            //
            // ContentPanel
            //
            this.ContentPanel.BackColor = System.Drawing.Color.White;
            this.ContentPanel.Controls.Add(this.PagesTabControl);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 144);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(12);
            this.ContentPanel.Size = new System.Drawing.Size(1040, 616);
            this.ContentPanel.TabIndex = 2;
            //
            // PagesTabControl
            //
            this.PagesTabControl.Controls.Add(this.CardsTabPage);
            this.PagesTabControl.Controls.Add(this.OrdersTabPage);
            this.PagesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagesTabControl.ItemSize = new System.Drawing.Size(160, 36);
            this.PagesTabControl.Location = new System.Drawing.Point(12, 12);
            this.PagesTabControl.Name = "PagesTabControl";
            this.PagesTabControl.SelectedIndex = 0;
            this.PagesTabControl.Size = new System.Drawing.Size(1016, 592);
            this.PagesTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.PagesTabControl.TabIndex = 0;
            //
            // CardsTabPage
            //
            this.CardsTabPage.BackColor = System.Drawing.Color.White;
            this.CardsTabPage.Controls.Add(this.MainLayout);
            this.CardsTabPage.Controls.Add(this.CatalogToolsPanel);
            this.CardsTabPage.Location = new System.Drawing.Point(4, 40);
            this.CardsTabPage.Name = "CardsTabPage";
            this.CardsTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.CardsTabPage.Size = new System.Drawing.Size(1008, 548);
            this.CardsTabPage.TabIndex = 0;
            this.CardsTabPage.Text = "Карточки";
            //
            // CatalogToolsPanel
            //
            this.CatalogToolsPanel.AutoSize = true;
            this.CatalogToolsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CatalogToolsPanel.Controls.Add(this.CatalogSortLabel);
            this.CatalogToolsPanel.Controls.Add(this.SortComboBox);
            this.CatalogToolsPanel.Controls.Add(this.SearchNameLabel);
            this.CatalogToolsPanel.Controls.Add(this.SearchTextBox);
            this.CatalogToolsPanel.Controls.Add(this.SearchButton);
            this.CatalogToolsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CatalogToolsPanel.Location = new System.Drawing.Point(4, 4);
            this.CatalogToolsPanel.Name = "CatalogToolsPanel";
            this.CatalogToolsPanel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 6);
            this.CatalogToolsPanel.Size = new System.Drawing.Size(1000, 43);
            this.CatalogToolsPanel.TabIndex = 0;
            //
            // CatalogSortLabel
            //
            this.CatalogSortLabel.AutoSize = true;
            this.CatalogSortLabel.Location = new System.Drawing.Point(3, 9);
            this.CatalogSortLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.CatalogSortLabel.Name = "CatalogSortLabel";
            this.CatalogSortLabel.Size = new System.Drawing.Size(92, 19);
            this.CatalogSortLabel.TabIndex = 0;
            this.CatalogSortLabel.Text = "Сортировка:";
            //
            // SortComboBox
            //
            this.SortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortComboBox.FormattingEnabled = true;
            this.SortComboBox.Items.AddRange(new object[] {
            "Без сортировки",
            "По возрастанию цены",
            "По убыванию цены"});
            this.SortComboBox.Location = new System.Drawing.Point(101, 5);
            this.SortComboBox.Name = "SortComboBox";
            this.SortComboBox.Size = new System.Drawing.Size(220, 27);
            this.SortComboBox.TabIndex = 1;
            this.SortComboBox.SelectedIndexChanged += new System.EventHandler(this.SortComboBox_SelectedIndexChanged);
            //
            // SearchNameLabel
            //
            this.SearchNameLabel.AutoSize = true;
            this.SearchNameLabel.Location = new System.Drawing.Point(336, 9);
            this.SearchNameLabel.Margin = new System.Windows.Forms.Padding(12, 7, 3, 0);
            this.SearchNameLabel.Name = "SearchNameLabel";
            this.SearchNameLabel.Size = new System.Drawing.Size(80, 19);
            this.SearchNameLabel.TabIndex = 2;
            this.SearchNameLabel.Text = "Название:";
            //
            // SearchTextBox
            //
            this.SearchTextBox.Location = new System.Drawing.Point(422, 5);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(285, 27);
            this.SearchTextBox.TabIndex = 3;
            this.SearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchTextBox_KeyDown);
            //
            // SearchButton
            //
            this.SearchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(178)))), ((int)(((byte)(175)))));
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Location = new System.Drawing.Point(713, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(100, 29);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Найти";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            //
            // OrdersTabPage
            //
            this.OrdersTabPage.BackColor = System.Drawing.Color.White;
            this.OrdersTabPage.Location = new System.Drawing.Point(4, 40);
            this.OrdersTabPage.Name = "OrdersTabPage";
            this.OrdersTabPage.Padding = new System.Windows.Forms.Padding(8);
            this.OrdersTabPage.Size = new System.Drawing.Size(1008, 548);
            this.OrdersTabPage.TabIndex = 1;
            this.OrdersTabPage.Text = "Заказы";
            //
            // HeaderLayout
            //
            this.HeaderLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(246)))), ((int)(((byte)(231)))));
            this.HeaderLayout.ColumnCount = 4;
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.HeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.HeaderLayout.Controls.Add(this.WindowTitleLabel, 0, 0);
            this.HeaderLayout.Controls.Add(this.LogoPictureBox, 1, 0);
            this.HeaderLayout.Controls.Add(this.UserNameLabel, 2, 0);
            this.HeaderLayout.Controls.Add(this.UserRoleLabel, 2, 1);
            this.HeaderLayout.Controls.Add(this.UserAvatarPictureBox, 3, 0);
            this.HeaderLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderLayout.Location = new System.Drawing.Point(0, 0);
            this.HeaderLayout.Name = "HeaderLayout";
            this.HeaderLayout.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.HeaderLayout.RowCount = 2;
            this.HeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.HeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.HeaderLayout.Size = new System.Drawing.Size(1040, 144);
            this.HeaderLayout.TabIndex = 0;
            //
            // WindowTitleLabel
            //
            this.WindowTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowTitleLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold);
            this.WindowTitleLabel.Location = new System.Drawing.Point(20, 12);
            this.WindowTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.WindowTitleLabel.Name = "WindowTitleLabel";
            this.HeaderLayout.SetRowSpan(this.WindowTitleLabel, 2);
            this.WindowTitleLabel.Size = new System.Drawing.Size(327, 120);
            this.WindowTitleLabel.TabIndex = 0;
            this.WindowTitleLabel.Text = "ООО «Чудо Обувь»";
            this.WindowTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // LogoPictureBox
            //
            this.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(355, 12);
            this.LogoPictureBox.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.HeaderLayout.SetRowSpan(this.LogoPictureBox, 2);
            this.LogoPictureBox.Size = new System.Drawing.Size(144, 120);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 1;
            this.LogoPictureBox.TabStop = false;
            //
            // UserNameLabel
            //
            this.UserNameLabel.AutoEllipsis = true;
            this.UserNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserNameLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.UserNameLabel.Location = new System.Drawing.Point(507, 12);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 8, 4);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(391, 62);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "Гость";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            //
            // UserRoleLabel
            //
            this.UserRoleLabel.AutoEllipsis = true;
            this.UserRoleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRoleLabel.Font = new System.Drawing.Font("Calibri", 10F);
            this.UserRoleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(85)))), ((int)(((byte)(80)))));
            this.UserRoleLabel.Location = new System.Drawing.Point(507, 78);
            this.UserRoleLabel.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.UserRoleLabel.Name = "UserRoleLabel";
            this.UserRoleLabel.Size = new System.Drawing.Size(391, 54);
            this.UserRoleLabel.TabIndex = 3;
            this.UserRoleLabel.Text = "Гостевой режим";
            this.UserRoleLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //
            // UserAvatarPictureBox
            //
            this.UserAvatarPictureBox.AccessibleName = "Профиль пользователя";
            this.UserAvatarPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserAvatarPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("UserAvatarPictureBox.Image")));
            this.UserAvatarPictureBox.Location = new System.Drawing.Point(906, 12);
            this.UserAvatarPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserAvatarPictureBox.Name = "UserAvatarPictureBox";
            this.HeaderLayout.SetRowSpan(this.UserAvatarPictureBox, 2);
            this.UserAvatarPictureBox.Size = new System.Drawing.Size(114, 120);
            this.UserAvatarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserAvatarPictureBox.TabIndex = 4;
            this.UserAvatarPictureBox.TabStop = false;
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
            this.Text = "ООО «Чудо Обувь»";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ContentPanel.ResumeLayout(false);
            this.PagesTabControl.ResumeLayout(false);
            this.CardsTabPage.ResumeLayout(false);
            this.CardsTabPage.PerformLayout();
            this.CatalogToolsPanel.ResumeLayout(false);
            this.CatalogToolsPanel.PerformLayout();
            this.HeaderLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserAvatarPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BufferedFlowLayoutPanel MainLayout;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TabControl PagesTabControl;
        private System.Windows.Forms.TabPage CardsTabPage;
        private System.Windows.Forms.TabPage OrdersTabPage;
        private System.Windows.Forms.FlowLayoutPanel CatalogToolsPanel;
        private System.Windows.Forms.Label CatalogSortLabel;
        private System.Windows.Forms.ComboBox SortComboBox;
        private System.Windows.Forms.Label SearchNameLabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TableLayoutPanel HeaderLayout;
        private System.Windows.Forms.Label WindowTitleLabel;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.PictureBox UserAvatarPictureBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label UserRoleLabel;
    }
}
