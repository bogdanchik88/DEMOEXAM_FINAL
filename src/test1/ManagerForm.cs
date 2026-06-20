using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class ManagerForm : Form
    {
        private DEMOEKZ_TESTEntities db = new DEMOEKZ_TESTEntities();
        private Users currentUser;
        private bool isAdmin;

        private List<Items> allItems;
        public ManagerForm(Users user, bool isAdmin)
        {
            InitializeComponent();

            currentUser = user;
            this.isAdmin = isAdmin;
            labelGreeting.Text = "Здравствуйте, " + currentUser.Name + "!";

            if (isAdmin)
            {
                labelInfo.Visible = true;
                buttonAddItem.Visible = true;
                buttonAddOrder.Visible = true;
            }

            allItems = db.Items.ToList();
            loadSuppliers();
            applyFilters();
            renderCards(allItems);
            loadOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadSuppliers()
        {

            var suppliers = allItems
                .Select(i => i.Supplier?.Trim())
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct()
                .OrderBy(s => s)
                .ToList();

            suppliers.Insert(0, "Все поставщики");

            comboBoxSuppliers.DataSource = suppliers;
        }

        private void applyFilters()
        {
            IEnumerable<Items> items = allItems;

            string search = textBoxSearch.Text.Trim().ToLower();

            if (!string.IsNullOrEmpty(search))
            {
                items = items.Where(i =>
                    (i.Category.ToLower().Contains(search)) ||
                    (i.ItemName.ToLower().Contains(search)) ||
                    (i.Producer.ToLower().Contains(search)) ||
                    (i.Description.ToLower().Contains(search))
                    );
            }

            if (comboBoxSuppliers.SelectedIndex > 0)
            {
                string supplier = comboBoxSuppliers.SelectedItem.ToString();

                items = items.Where(i => i.Supplier == supplier);
            }

            if (radioButtonasc.Checked)
            {
                items = items.OrderBy(i => i.Quantity);
            }
            else
            {
                items = items.OrderByDescending(i => i.Quantity);
            }

            renderCards(items.ToList());
        }

        private void renderCards(List<Items> items)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in items)
            {
                var card = new ItemCard();
                card.setData(item);
                if (isAdmin)
                {
                    card.Cursor = Cursors.Hand;
                    card.MouseClick += (s,e) => card_click(item, e);
                }
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void loadOrders()
        {
            flowLayoutPanel2.Controls.Clear();

            var orders = db.Orders
                .Include(o => o.PickupPoints)
                .Include(o => o.Users)
                .ToList();

            foreach (var item in orders)
            {
                var card = new OrderCard();
                card.loadData(item);
                if(isAdmin)
                {
                    card.Cursor = Cursors.Hand;
                    card.MouseClick += (s, e) => order_click(item, e);
                }

                flowLayoutPanel2.Controls.Add(card);
            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void comboBoxSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void radioButtonasc_CheckedChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void card_click(Items item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                openEditor(item);
            }
            else if(e.Button == MouseButtons.Right)
            {
                DeleteItem(item);
            }
        }

        private void order_click(Orders item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                openOrder(item);
            }
            else if (e.Button == MouseButtons.Right)
            {
                deleteOrder(item);
            }
        }

        private void DeleteItem(Items item)
        {
            if (MessageBox.Show($"Удалить товар \"{item.ItemName}\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                db.Items.Remove(item);
                db.SaveChanges();
                reloadItems();
            }
            catch (Exception)
            {
                MessageBox.Show("Нельзя удалить товар, который есть в заказах.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteOrder(Orders item)
        {
            if (MessageBox.Show($"Удалить товар \"{item.OrderId}\"?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                db.Orders.Remove(item);
                db.SaveChanges();
                reloadItems();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при удалении заказа.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openEditor(Items item)
        {
            var form = new AddEditItemForm(item);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //allItems = db.Items.ToList();
                //applyFilters();
                reloadItems();
            }
        }

        private void openOrder(Orders item)
        {
            var form = new AddEditOrderForm(item);
            if (form.ShowDialog() == DialogResult.OK)
            {
                allItems = db.Items.ToList();
                reloadItems();
            }
        }

        private void reloadItems()
        {
            db.Dispose();                          
            db = new DEMOEKZ_TESTEntities();        
            allItems = db.Items.ToList();
            loadOrders();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            openEditor(null);
        }

        private void buttonAddOrder_Click(object sender, EventArgs e)
        {
            openOrder(null);
        }
    }
}
