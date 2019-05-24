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
    public partial class FimForm : Form
    {
        VideoContext contex;
        public FimForm()
        {
            this.contex = new VideoContext();
            InitializeComponent();
        }

        private void FimForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.contex.Films.ToList<Film>();
        }
    }
}
