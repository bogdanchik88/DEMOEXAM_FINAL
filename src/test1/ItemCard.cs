using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace test1
{
    public partial class ItemCard : UserControl
    {
        public ItemCard()
        {
            InitializeComponent();
        }

        public void setData(Items item)
        {
            labelNameAndCategory.Text = item.Category + " | " + item.ItemName;
            labelDescription.Text = "Описание: " + item.Description;
            labelProducer.Text = "Производитель: " + item.Producer;
            labelSupplier.Text = "Поставщик: " + item.Supplier;

            var price = item.Price;
            labelPrice.Text = "Цена: " + item.Price.ToString() + " руб.";

            labelStock.Text = "единица измерения: " + item.Stocking;
            labelQuantity.Text = "Всего на складе: " + item.Quantity.ToString();

            double discount = item.CurrentDiscount ?? 0;
            labelDiscount.Text = discount > 0 ? "Скидка " + discount + "%" : "";

            string fileName = item.Image ?? "";
            string path = Path.Combine(Application.StartupPath, "Images", fileName);

            if(discount > 0)
            {
                price = price / 100 * (100 - discount);
            }

            labelPrice.Text = "Цена: " + price.ToString() + " руб.";

            if (File.Exists(path))
            {
                using (var temp = Image.FromFile(path))
                    pictureBoxImage.Image = new Bitmap(temp);
            }
            else
            {
                string place = Path.Combine(Application.StartupPath, "Images", "placeholder.png");
                if (File.Exists(place))
                    using (var temp = Image.FromFile(place))
                        pictureBoxImage.Image = new Bitmap(temp);
                else
                    pictureBoxImage.Image = null;
            }

            if (item.Quantity == 0)
            {
                this.BackColor = Color.Aqua;
                labelDiscount.BackColor = Color.Aqua;
            }
            else if (discount > 15)
            {
                this.BackColor = ColorTranslator.FromHtml("#2E8B57");
                labelDiscount.BackColor = ColorTranslator.FromHtml("#2E8B57");
            }
        }
    }
}