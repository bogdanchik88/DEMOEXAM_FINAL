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
    public partial class UserForm : Form
    {
        private DEMOEKZ_TESTEntities db = new DEMOEKZ_TESTEntities();
        private Users currentUser;

        public UserForm(Users user)
        {
            InitializeComponent();
            currentUser = user;
            if(currentUser != null )
            {
                labelGreeting.Text = "Здравствуйте, " + user.Name + "!";
            }
            else
            {
                labelGreeting.Text = "Вы вошли как гость!";
            }

        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            var items = db.Items.ToList();

            foreach (var item in items)
            {
                var card = new ItemCard();
                card.setData(item);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
