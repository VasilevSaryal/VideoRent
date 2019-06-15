using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Videorent
{
    public partial class OrderTimeForm : Form
    {
        public OrderTimeForm()
        {
            InitializeComponent();
        }
        DateTime a, b;

        private void button1_Click(object sender, EventArgs e)
        {
            VideoContext contex = new VideoContext();
            b = dateTimePicker1.Value.Date; a = dateTimePicker2.Value.Date;
            Close();
        }
        public DateTime GetStartAt()
        {
            return a;
        }
        public DateTime GetExpiredAt()
        {
            return b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime sss = new DateTime(2000, 12, 31, 22, 56, 59);
            b = sss;
            Close();
        }

        private void OrderTimeForm_Load(object sender, EventArgs e)
        {
            //dateTimePicker1.Value = null;
            //dateTimePicker2.Value = null;
        }
    }
}
