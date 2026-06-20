namespace test1
{
    partial class AddEditOrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPickUpPoint = new System.Windows.Forms.ComboBox();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.textBoxArticle = new System.Windows.Forms.TextBox();
            this.buttonSaveOrder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerOrderDate
            // 
            this.dateTimePickerOrderDate.Location = new System.Drawing.Point(481, 64);
            this.dateTimePickerOrderDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            this.dateTimePickerOrderDate.Size = new System.Drawing.Size(249, 28);
            this.dateTimePickerOrderDate.TabIndex = 0;
            // 
            // dateTimePickerDeliveryDate
            // 
            this.dateTimePickerDeliveryDate.Location = new System.Drawing.Point(481, 151);
            this.dateTimePickerDeliveryDate.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerDeliveryDate.Name = "dateTimePickerDeliveryDate";
            this.dateTimePickerDeliveryDate.Size = new System.Drawing.Size(249, 28);
            this.dateTimePickerDeliveryDate.TabIndex = 1;
            // 
            // comboBoxPickUpPoint
            // 
            this.comboBoxPickUpPoint.FormattingEnabled = true;
            this.comboBoxPickUpPoint.Location = new System.Drawing.Point(62, 64);
            this.comboBoxPickUpPoint.Name = "comboBoxPickUpPoint";
            this.comboBoxPickUpPoint.Size = new System.Drawing.Size(187, 28);
            this.comboBoxPickUpPoint.TabIndex = 2;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(62, 151);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(187, 28);
            this.comboBoxStatus.TabIndex = 3;
            // 
            // textBoxArticle
            // 
            this.textBoxArticle.Location = new System.Drawing.Point(62, 235);
            this.textBoxArticle.Name = "textBoxArticle";
            this.textBoxArticle.Size = new System.Drawing.Size(199, 28);
            this.textBoxArticle.TabIndex = 4;
            // 
            // buttonSaveOrder
            // 
            this.buttonSaveOrder.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonSaveOrder.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveOrder.Location = new System.Drawing.Point(758, 311);
            this.buttonSaveOrder.Name = "buttonSaveOrder";
            this.buttonSaveOrder.Size = new System.Drawing.Size(112, 45);
            this.buttonSaveOrder.TabIndex = 23;
            this.buttonSaveOrder.Text = "Сохранить";
            this.buttonSaveOrder.UseVisualStyleBackColor = false;
            this.buttonSaveOrder.Click += new System.EventHandler(this.buttonSaveOrder_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(758, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 45);
            this.button1.TabIndex = 24;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddEditOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 368);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSaveOrder);
            this.Controls.Add(this.textBoxArticle);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.comboBoxPickUpPoint);
            this.Controls.Add(this.dateTimePickerDeliveryDate);
            this.Controls.Add(this.dateTimePickerOrderDate);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddEditOrderForm";
            this.Text = "AddEditOrderForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeliveryDate;
        private System.Windows.Forms.ComboBox comboBoxPickUpPoint;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox textBoxArticle;
        private System.Windows.Forms.Button buttonSaveOrder;
        private System.Windows.Forms.Button button1;
    }
}