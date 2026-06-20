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
    public partial class Form1 : Form
    {
        private DEMOEKZ_TESTEntities db = new DEMOEKZ_TESTEntities();
        bool isAdmin = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            var user = db.Users.FirstOrDefault(n => n.Login == login && 
                n.Password == password);

            Form NextForm;

            if (user == null)
            {
                MessageBox.Show("неверные данные");
                return;
            }

            switch (user.Role?.Trim())
            {
                case "Авторизированный клиент":
                    NextForm = new UserForm(user);
                    break;
                case "Менеджер":
                    NextForm = new ManagerForm(user, isAdmin);
                    break;
                case "Администратор":
                    isAdmin = true;
                    NextForm = new ManagerForm(user, isAdmin);
                    break;
                default:
                    MessageBox.Show("Неизвестная роль: " + user.Role);
                    return;
            }

            this.Hide();
            NextForm.ShowDialog();

            textBoxLogin.Clear();
            textBoxPassword.Clear();
            this.Show();
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            this.Hide();
            new UserForm(null).ShowDialog();


            textBoxLogin.Clear();
            textBoxPassword.Clear();
            this.Show();
        }
    }
}
