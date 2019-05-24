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
    public partial class DiscForm : Form
    {
        VideoContext contex;
        public DiscForm()
        {
            this.contex = new VideoContext();
            InitializeComponent();
        }

        private void DiscForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.contex.Discs.ToList<Disc>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}
