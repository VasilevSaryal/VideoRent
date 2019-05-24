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
    public partial class IDForm : Form
    {
        bool act = false;
        public IDForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            ClientsForm frm = new ClientsForm();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //VideoContext contex = new VideoContext();
            //int SaryalK = Convert.ToInt16(textBox1.Text);
            //var client = contex.Clients.Where(c => c.ClientID == SaryalK);
            //Close();
            //if (act == false)
            //{
            //    InputClient frm = new InputClient();
            //    foreach (Client c in client)
            //    {
            //        frm.SetClient(c.ClientID, c.Name, c.Surname, c.Patronymic, c.Age, c.Phone, c.InBlacklist);
            //    }
            //    frm.Show();
            //}
            //else
            //{
            //    var cl = contex.Clients.Where(c => c.ClientID == SaryalK);
            //    foreach (Client c in cl)
            //    {
            //        contex.Clients.Remove(c);
            //    }
            //    contex.SaveChanges();
            //    ClientsForm FRM = new ClientsForm();
            //    FRM.Show();
            //}

        }
        public void SetAction()
        {
            this.act = true;
        }
    }
}
