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
    public partial class OrderCard : UserControl
    {
        public OrderCard()
        {
            InitializeComponent();
        }

        public void loadData(Orders order)
        {
            labelArticle.Text = "Артикул: " + order.OrderId.ToString();
            labelStatus.Text = "Статус заказа: " + order.OrderStatus;
            labelDelivery.Text = "Адрес доставки: " + order.PickupPoints.Address;
            labelCreatedDate.Text = "Дата создания:" + order.DateOrder?.ToString("dd:MM:yyyy");
            labelDeliveryDate.Text = "Дата доставки: " + order.DateDelivery?.ToString("dd:MM:yyyy");
        }
    }
}
