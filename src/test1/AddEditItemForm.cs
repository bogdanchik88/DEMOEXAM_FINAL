using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test1
{
    public partial class AddEditItemForm : Form
    {
        private DEMOEKZ_TESTEntities db = new DEMOEKZ_TESTEntities();
        private Items editingItem;
        private string selectedImage;
        private string sourceImagePath;

        public AddEditItemForm(Items item)
        {
            editingItem = item;
            InitializeComponent();

            loadComboboxes();

            if(editingItem != null)
            {
                this.Text = "Редактирование товара";
                editingItem = db.Items.Find(item.ItemId);
                fillItem(editingItem);
            }
            else
            {
                this.Text = "Добавление товара";
            }
        }

        private void loadComboboxes()
        {
            comboBoxCategory.DataSource = db.Items
                .Select(x => x.Category)
                .Where(i => i != null)
                .Distinct()
                .ToList();

            comboBoxProducer.DataSource = db.Items
                .Select(x => x.Producer)
                .Where(i => i != null)
                .Distinct()
                .ToList();
        }

        private void fillItem(Items item)
        {
            comboBoxCategory.SelectedItem = item.Category;
            comboBoxProducer.SelectedItem = item.Producer;

            textBoxArticle.Text = item.ItemId.ToString();
            textBoxTitle.Text = item.ItemName.ToString();
            textBoxDescription.Text = item.Description;
            textBoxStocking.Text = item.Stocking;

            numericUpDownQuantity.Value = (decimal)item.Quantity;
            numericUpDownDiscount.Value = (decimal)item.CurrentDiscount;
            numericUpDownPrice.Value = (decimal)item.Price;

            selectedImage = item.Image;
            string path = Path.Combine(Application.StartupPath, "Images", selectedImage ?? "");

            if (File.Exists(path))
            {
                using (var temp = Image.FromFile(path))
                    pictureBoxImage.Image = new Bitmap(temp);
            }
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            string imageName = SaveImage();
            if (editingItem == null)
            {
                // ДОБАВЛЕНИЕ — новый объект
                var item = new Items
                {
                    ItemId = textBoxArticle.Text.Trim(),   // id ты сделал редактируемым
                    ItemName = textBoxTitle.Text.Trim(),
                    Category = comboBoxCategory.Text,
                    Producer = comboBoxProducer.Text,
                    Description = textBoxDescription.Text.Trim(),
                    Stocking = textBoxStocking.Text.Trim(),
                    Quantity = (double)numericUpDownQuantity.Value,
                    CurrentDiscount = (double)numericUpDownDiscount.Value,
                    Price = (double)numericUpDownPrice.Value,
                    Image = imageName
                };
                db.Items.Add(item);
            }
            else
            {
                // РЕДАКТИРОВАНИЕ — меняем поля найденного объекта
                editingItem.ItemName = textBoxTitle.Text.Trim();
                editingItem.Category = comboBoxCategory.Text;
                editingItem.Producer = comboBoxProducer.Text;
                editingItem.Description = textBoxDescription.Text.Trim();
                editingItem.Stocking = textBoxStocking.Text.Trim();
                editingItem.Quantity = (double)numericUpDownQuantity.Value;
                editingItem.CurrentDiscount = (double)numericUpDownDiscount.Value;
                editingItem.Price = (double)numericUpDownPrice.Value;
                editingItem.Image = imageName;
            }

            db.SaveChanges();

            this.DialogResult = DialogResult.OK;   // сигнал ManagerForm обновить список
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxImage_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Изображения|*.jpg;*.jpeg;*.png";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                sourceImagePath = dialog.FileName; 

                using (var original = Image.FromFile(sourceImagePath))
                    pictureBoxImage.Image = new Bitmap(original, new Size(300, 200));
            }
        }

        private string SaveImage()
        {
            if (string.IsNullOrEmpty(sourceImagePath))
                return selectedImage;

            // СРАЗУ освобождаем PictureBox — что бы там ни лежало
            if (pictureBoxImage.Image != null)
            {
                pictureBoxImage.Image.Dispose();
                pictureBoxImage.Image = null;
            }

            string imagesDir = Path.Combine(Application.StartupPath, "Images");
            Directory.CreateDirectory(imagesDir);

            string newName = Guid.NewGuid().ToString() + Path.GetExtension(sourceImagePath);
            string newPath = Path.Combine(imagesDir, newName);

            using (var original = Image.FromFile(sourceImagePath))
            using (var resized = new Bitmap(original, new Size(300, 200)))
                resized.Save(newPath);

            if (!string.IsNullOrEmpty(selectedImage))
            {
                string oldPath = Path.Combine(imagesDir, selectedImage);
                if (File.Exists(oldPath))
                    File.Delete(oldPath);
            }

            return newName;
        }
    }
}
