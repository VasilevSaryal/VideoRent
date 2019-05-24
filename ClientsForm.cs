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
    public partial class ClientsForm : Form
    {
        VideoContext contex;
  
        public ClientsForm()
        {
            this.contex = new VideoContext();        
            InitializeComponent();
            dataGridView1.DataSource = this.contex.Clients.ToList<Client>();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Возраст";
            dataGridView1.Columns[5].HeaderText = "Телефон";
            dataGridView1.Columns[6].HeaderText = "В черном списке";
        }

  

        private void Clients_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            InputClient form = new InputClient(null);
            form.ShowDialog();
            // InputClient form = new InputClient();
            //form.ShowDialog();
            //Close();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index, id = 0;
            Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            Client client = contex.Clients.Where(c => c.ClientID == id).FirstOrDefault();
            contex.Clients.Remove(client);
            contex.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            contex.SaveChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.contex.Clients.ToList<Client>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

  
        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index, id = 0;
            Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            Client client = contex.Clients.Where(c => c.ClientID == id).FirstOrDefault();
            InputClient form = new InputClient(client);
            form.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Показать все")
            {
                dataGridView1.DataSource = this.contex.Clients.ToList<Client>();
                Close();
                ClientsForm f = new ClientsForm();
                f.Show();
                button1.Text = "Добавить";
                button4.Text = "Поиск";
            }
            else
            {
               // InputClient frm = new InputClient();
                //frm.SetAction();
               // frm.ShowDialog();
                Close();
            }
        }



     


    }
}
