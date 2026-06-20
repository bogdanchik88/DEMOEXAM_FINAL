namespace test1
{
    partial class ItemCard
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.labelNameAndCategory = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelDiscount = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelProducer = new System.Windows.Forms.Label();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxImage.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(162, 153);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // labelNameAndCategory
            // 
            this.labelNameAndCategory.AutoSize = true;
            this.labelNameAndCategory.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNameAndCategory.Location = new System.Drawing.Point(171, 15);
            this.labelNameAndCategory.Name = "labelNameAndCategory";
            this.labelNameAndCategory.Size = new System.Drawing.Size(174, 19);
            this.labelNameAndCategory.TabIndex = 1;
            this.labelNameAndCategory.Text = "Название/Категория:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.Location = new System.Drawing.Point(171, 91);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(49, 19);
            this.labelPrice.TabIndex = 2;
            this.labelPrice.Text = "Цена:";
            // 
            // labelDiscount
            // 
            this.labelDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.labelDiscount.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDiscount.Location = new System.Drawing.Point(414, 8);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(90, 140);
            this.labelDiscount.TabIndex = 3;
            this.labelDiscount.Text = "Скидка:";
            this.labelDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.Location = new System.Drawing.Point(171, 34);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(237, 19);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Описание:";
            // 
            // labelProducer
            // 
            this.labelProducer.AutoSize = true;
            this.labelProducer.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProducer.Location = new System.Drawing.Point(171, 53);
            this.labelProducer.Name = "labelProducer";
            this.labelProducer.Size = new System.Drawing.Size(123, 19);
            this.labelProducer.TabIndex = 5;
            this.labelProducer.Text = "Производитель:";
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSupplier.Location = new System.Drawing.Point(171, 72);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(94, 19);
            this.labelSupplier.TabIndex = 6;
            this.labelSupplier.Text = "Поставщик:";
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStock.Location = new System.Drawing.Point(171, 110);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(150, 19);
            this.labelStock.TabIndex = 7;
            this.labelStock.Text = "Единица измерения:";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQuantity.Location = new System.Drawing.Point(171, 129);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(169, 19);
            this.labelQuantity.TabIndex = 8;
            this.labelQuantity.Text = "Количество на складе:";
            // 
            // ItemCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelSupplier);
            this.Controls.Add(this.labelProducer);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelDiscount);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelNameAndCategory);
            this.Controls.Add(this.pictureBoxImage);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ItemCard";
            this.Size = new System.Drawing.Size(507, 159);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label labelNameAndCategory;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelDiscount;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelProducer;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelQuantity;
    }
}
