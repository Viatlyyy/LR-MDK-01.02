using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RestaurantOrder
{
    public partial class MainForm : Form
    {
        private Dictionary<string, MenuGroup> MenuData;
        private const string CsvFileName = "data.csv";
        public MainForm()
        {
            InitializeComponent();
            LoadInitialUI();
        }

        private void LoadInitialUI()
        {
            
            nudQuantity.Minimum = 1;
            nudQuantity.Value = 1;

            

            ClearItemCard();
        }

        private void LoadDataFromCsv()
        {
            MenuData = new Dictionary<string, MenuGroup>();
            

            
            if (!File.Exists(CsvFileName))
            {
                
                return;
            }

            string[] lines = File.ReadAllLines(CsvFileName, Encoding.GetEncoding(1251));
            int processedCount = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;

               
                string[] parts = line.Split(';');

                
                if (parts.Length < 5)
                {
                    
                    continue;
                }

                string groupName = parts[0].Trim();
                string itemName = parts[1].Trim();
                string priceStr = parts[2].Trim();
                string ingredients = parts[3].Trim();
                string imagePath = parts[4].Trim();

               
                double price = Convert.ToDouble(priceStr);

                MenuItem item = new MenuItem();
                item.Name = itemName;
                item.Price = price;
                item.Ingredients = ingredients;
                item.ImagePath = imagePath;

            
                if (!MenuData.ContainsKey(groupName))
                {
                    MenuGroup newGroup = new MenuGroup();
                    newGroup.Name = groupName;
                    MenuData.Add(groupName, newGroup);
                }

                
                MenuData[groupName].Items.Add(item);
                processedCount++;
            }

            

            
            List<string> groupNames = new List<string>(MenuData.Keys);
            lbMenuGroups.DataSource = groupNames;
        }

        private void lbMenuGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMenuGroups.SelectedItem == null) return;

            string selectedGroupName = lbMenuGroups.SelectedItem.ToString();

            if (MenuData.ContainsKey(selectedGroupName))
            {
                MenuGroup group = MenuData[selectedGroupName];

                cbMenuItems.DataSource = group.Items;
                cbMenuItems.DisplayMember = "Name";
                cbMenuItems.SelectedIndex = -1;

                ClearItemCard();
            }
        }

        private void cbMenuItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMenuItems.SelectedItem == null)
            {
                ClearItemCard();
                return;
            }

            MenuItem selectedItem = (MenuItem)cbMenuItems.SelectedItem;

            lblItemDetails.Text = selectedItem.GetDescription();

            
            LoadItemImage(selectedItem.ImagePath);

            nudQuantity.Value = 1;


        }
        private void LoadItemImage(string path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
            {
                pbItemImage.Image = null;
                return;
            }

            
            pbItemImage.Image = System.Drawing.Image.FromFile(path);
            pbItemImage.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (lbMenuGroups.SelectedItem == null || cbMenuItems.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать группу и блюдо.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            MenuItem orderedItem = (MenuItem)cbMenuItems.SelectedItem;
            int quantity = (int)nudQuantity.Value;
            string groupName = lbMenuGroups.SelectedItem.ToString();

            double totalCost = orderedItem.Price * quantity;

            
            string orderLine =
                "Группа: " + groupName +
                " | Позиция: " + orderedItem.Name +
                " | Кол-во: " + quantity +
                " | Сумма: " + totalCost.ToString("F2") + " руб.\n";

            rtbOrderSummary.AppendText(orderLine);

           
            cbMenuItems.SelectedIndex = -1;
            nudQuantity.Value = 1;
        }
        private void ClearItemCard()
        {
            lblItemDetails.Text = "Выберите блюдо для просмотра деталей.";
            pbItemImage.Image = null;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadDataFromCsv();
        }
    }
  }
    
