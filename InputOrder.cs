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
    public partial class InputOrder : Form
    {
        int OrderID;
        DateTime StartAt;
        DateTime ExpiredAt;
        Client Client = new Client();
        bool IsClosed, Edit=false;
        int MoneyAmount;
        string DeposteType;
        VideoContext contex;
        public InputOrder()
        {
            this.contex = new VideoContext();
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientsForm Form = new ClientsForm();
            Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            OrderForm FRM = new OrderForm();
            FRM.Show();
        }
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }
        private void InputOrder_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add(new Item("Документы", 1));
            comboBox2.Items.Add(new Item("Денежный эквивалент", 2));
            var cl = contex.Clients;
            foreach (Client c in cl)
            {
                comboBox1.Items.Add(new Item(c.ClientID + ". " + c.Surname + " " + c.Name + " " + c.Patronymic, c.ClientID));
            }
            /*if (Edit)
            {
                comboBox2.Text = ;
                comboBox1.Text = "";

            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VideoContext contex = new VideoContext();
            OrderForm FRM = new OrderForm();
            int CiD = Convert.ToInt32(comboBox1.Text[0]);
            var cl = contex.Clients.Where(c => c.ClientID == CiD);
            Client client = new Client();
            foreach (Client c in cl)
            {
                client = c;
            }
            Order order = new Order
            {
                OrderID = 0,
                DepositeType = comboBox2.Text,
                MoneyAmount = Convert.ToInt32(textBox2.Text),
                StartAt = Convert.ToDateTime(dateTimePicker1.Text),
                ExpiredAt = Convert.ToDateTime(dateTimePicker2.Text),
                IsClosed = false,
                Client = client/*{ 
                    Age =client.Age,
                    ClientID = client.ClientID,
                    InBlacklist = client.InBlacklist,
                    Phone = client.Phone,
                    Name = client.Name,
                    Patronymic = client.Patronymic,
                    Surname = client.Surname
                }*/
            };
            contex.Orders.Add(order);
            contex.SaveChanges();
            Close();
            FRM.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            button5.Visible = false;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(7);
            dateTimePicker2.Value = answer;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown += new PreviewKeyDownEventHandler(comboBox1_PreviewKeyDown);
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            cbo.PreviewKeyDown -= comboBox1_PreviewKeyDown;
            if (cbo.DroppedDown) cbo.Focus();
        }
        public void SetOrder(int OrderID, DateTime StartAt, DateTime ExpiredAt, Client Client, bool IsClosed, int MoneyAmount, string DepositeType)
        {
            this.OrderID = OrderID;
            this.StartAt = StartAt;
            this.ExpiredAt = ExpiredAt;
            this.Client = Client;
            this.IsClosed = IsClosed;
            this.MoneyAmount = MoneyAmount;
            Edit = true;
        }
    }
}
