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
    public partial class AdminForm : Form
    {
        private DEMOEKZ_TESTEntities db = new DEMOEKZ_TESTEntities();
        private Users currentUser;
        public AdminForm(Users user)
        {
            InitializeComponent();
            currentUser = user;
        }
    }
}
