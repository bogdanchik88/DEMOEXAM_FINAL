namespace test1
{
    partial class OrderCard
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
            this.labelDeliveryDate = new System.Windows.Forms.Label();
            this.labelArticle = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelDelivery = new System.Windows.Forms.Label();
            this.labelCreatedDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDeliveryDate
            // 
            this.labelDeliveryDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelDeliveryDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDeliveryDate.Location = new System.Drawing.Point(502, 19);
            this.labelDeliveryDate.Name = "labelDeliveryDate";
            this.labelDeliveryDate.Size = new System.Drawing.Size(160, 104);
            this.labelDeliveryDate.TabIndex = 0;
            this.labelDeliveryDate.Text = "Дата доставки:";
            this.labelDeliveryDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelArticle
            // 
            this.labelArticle.AutoSize = true;
            this.labelArticle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArticle.Location = new System.Drawing.Point(22, 19);
            this.labelArticle.Name = "labelArticle";
            this.labelArticle.Size = new System.Drawing.Size(88, 22);
            this.labelArticle.TabIndex = 1;
            this.labelArticle.Text = "Артикул:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(22, 41);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(73, 22);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Статус:";
            // 
            // labelDelivery
            // 
            this.labelDelivery.AutoSize = true;
            this.labelDelivery.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDelivery.Location = new System.Drawing.Point(22, 63);
            this.labelDelivery.Name = "labelDelivery";
            this.labelDelivery.Size = new System.Drawing.Size(135, 22);
            this.labelDelivery.TabIndex = 3;
            this.labelDelivery.Text = "Пункт выдачи:";
            // 
            // labelCreatedDate
            // 
            this.labelCreatedDate.AutoSize = true;
            this.labelCreatedDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCreatedDate.Location = new System.Drawing.Point(22, 85);
            this.labelCreatedDate.Name = "labelCreatedDate";
            this.labelCreatedDate.Size = new System.Drawing.Size(138, 22);
            this.labelCreatedDate.TabIndex = 4;
            this.labelCreatedDate.Text = "Дата создания:";
            // 
            // OrderCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.labelCreatedDate);
            this.Controls.Add(this.labelDelivery);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelArticle);
            this.Controls.Add(this.labelDeliveryDate);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OrderCard";
            this.Size = new System.Drawing.Size(679, 141);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeliveryDate;
        private System.Windows.Forms.Label labelArticle;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelDelivery;
        private System.Windows.Forms.Label labelCreatedDate;
    }
}
