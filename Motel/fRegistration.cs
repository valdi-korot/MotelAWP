using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Motel.Model;

namespace Motel
{
    public partial class fRegistration : Form
    {
        MyModel db = new MyModel();
        public fRegistration()
        {
            InitializeComponent();
        }

        private void fRegistration_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = db.Clients.ToList();
            comboBox1.DataSource = db.Numbers.ToList();
        }
    }
}
