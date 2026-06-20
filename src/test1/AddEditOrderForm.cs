using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test1
{
    public partial class AddEditOrderForm : Form
    {
        private DEMOEKZ_TESTEntities db = new DEMOEKZ_TESTEntities();
        private Orders editingOrder;
        public AddEditOrderForm(Orders item)
        {
            InitializeComponent();
            loadComboboxes();

            if (item != null)
            {
                this.Text = "Редактирование заказа";
                editingOrder = db.Orders.Find(item.OrderId);   // свой контекст
                fillOrder(editingOrder);
            }
            else
            {
                this.Text = "Добавление заказа";
            }
        }

        private void loadComboboxes()
        {
            comboBoxPickUpPoint.DataSource = db.PickupPoints.ToList();
            comboBoxPickUpPoint.DisplayMember = "Address";
            comboBoxPickUpPoint.ValueMember = "AddressId";

            comboBoxStatus.Items.Clear();
            var statuses = db.Orders
                .Select(o => o.OrderStatus)
                .Where(s => s != null)
                .Distinct()
                .ToList()
                .Select(s => s.Trim())
                .Distinct()
                .ToList();

            comboBoxStatus.DataSource = statuses;
        }

        private void fillOrder(Orders order)
        {
            textBoxArticle.Text = order.OrderId.ToString();
            comboBoxStatus.Text = order.OrderStatus.Trim();
            comboBoxPickUpPoint.SelectedValue = order.AddressId;
            dateTimePickerOrderDate.Value = order.DateOrder ?? DateTime.Now;
            dateTimePickerDeliveryDate.Value = order.DateDelivery ?? DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int GetNextOrderId()
        {
            return db.Orders.Any() ? db.Orders.Max(o => o.OrderId) + 1 : 1;
        }
        private void buttonSaveOrder_Click(object sender, EventArgs e)
        {
            if (editingOrder == null)
            {
                // ДОБАВЛЕНИЕ
                var order = new Orders
                {
                    OrderId = GetNextOrderId(),
                    OrderStatus = comboBoxStatus.Text,
                    AddressId = (int)comboBoxPickUpPoint.SelectedValue,
                    DateOrder = dateTimePickerOrderDate.Value,
                    DateDelivery = dateTimePickerDeliveryDate.Value,
                    UserId = 1   // обязательное поле — см. пояснение ниже
                };
                db.Orders.Add(order);
            }
            else
            {
                // РЕДАКТИРОВАНИЕ
                editingOrder.OrderStatus = comboBoxStatus.Text;
                editingOrder.AddressId = (int)comboBoxPickUpPoint.SelectedValue;
                editingOrder.DateOrder = dateTimePickerOrderDate.Value;
                editingOrder.DateDelivery = dateTimePickerDeliveryDate.Value;
            }

            db.SaveChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
