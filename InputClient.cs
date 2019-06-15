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
    public partial class InputClient : Form
    {
        Client client, inClient;
        public InputClient(Client client)
        {
            this.client = client;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                VideoContext contex = new VideoContext();
                inClient = new Client
                {
                    Name = textBox1.Text,
                    Surname = textBox2.Text,
                    Patronymic = textBox3.Text,
                    Age = Convert.ToInt16(textBox4.Text),
                    Phone = Convert.ToInt64(textBox5.Text),
                    InBlacklist = checkBox1.Checked
                };
                if (client != null)
                {
                    Client cl = contex.Clients.Where(c => c.ClientID == client.ClientID).FirstOrDefault();
                    cl.Name = inClient.Name;
                    cl.Surname = inClient.Surname;
                    cl.Patronymic = inClient.Patronymic;
                    cl.Age = inClient.Age;
                    cl.Phone = inClient.Phone;
                    cl.InBlacklist = inClient.InBlacklist;

                }
                else
                    contex.Clients.Add(inClient);
                contex.SaveChanges();
                Close();
            }
            else MessageBox.Show("Заполните все поля");
        }

        private void InputClient_Load(object sender, EventArgs e)
        {
            if (client != null)
            {
                textBox1.Text = client.Name;
                textBox2.Text = client.Surname;
                textBox3.Text =client.Patronymic;
                textBox4.Text = Convert.ToString(client.Age);
                textBox5.Text = Convert.ToString(client.Phone);
                checkBox1.Checked = client.InBlacklist;
            }
        }
        public Client GetClient()
        {
            return inClient;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

    }
}
