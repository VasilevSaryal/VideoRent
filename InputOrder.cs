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
        Order order;
        Disc Disc = new Disc();
        bool IsClosed, Edit=false;
        int MoneyAmount;
        string DeposteType;
        VideoContext contex;
        public InputOrder(Order order)
        {
            this.contex = new VideoContext();
            InitializeComponent();
            this.order = order;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm(true, false);
            form.ShowDialog();
            if (form.GetClient() != null)
            {
                Client = form.GetClient();
                textBox1.Text = Client.Surname + " " + Client.Name + " " + Client.Patronymic;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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
            if (order != null)
            {
                Client = order.Client;
                Disc = order.Disc;
                comboBox2.Text = order.DepositeType;
                label6.Visible = false;
                button5.Visible = false;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                dateTimePicker1.Value = order.StartAt;
                dateTimePicker2.Value = order.ExpiredAt;
                textBox1.Text = order.Client.Surname + " " + order.Client.Name + " " + order.Client.Patronymic;
                textBox2.Text = order.MoneyAmount.ToString();
                checkBox1.Checked = order.IsClosed;
                textBox3.Text = order.Disc.Name;
            }
  
            /*if (Edit)
            {
                comboBox2.Text = ;
                comboBox1.Text = "";

            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""&&comboBox2.Text!="")
            {
                VideoContext contex = new VideoContext();
                if (dateTimePicker1.Visible == false)
                {
                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    DateTime today = DateTime.Now;
                    DateTime answer = today.AddDays(7);
                    dateTimePicker2.Value = answer;
                }
                Order inOrder = new Order
                {
                    DepositeType = comboBox2.Text,
                    MoneyAmount = Convert.ToInt32(textBox2.Text),
                    StartAt = Convert.ToDateTime(dateTimePicker1.Text),
                    ExpiredAt = Convert.ToDateTime(dateTimePicker2.Text),
                    IsClosed = checkBox1.Checked,
                    ClientID = Client.ClientID,
                    DiscID = Disc.DiscID
                };
                if (order != null)
                {
                    Order or = contex.Orders.Where(o => o.OrderID == order.OrderID).FirstOrDefault();
                    or.DepositeType = comboBox2.Text;
                    or.MoneyAmount = Convert.ToInt32(textBox2.Text);
                    or.StartAt = Convert.ToDateTime(dateTimePicker1.Text);
                    or.ExpiredAt = Convert.ToDateTime(dateTimePicker2.Text);
                    or.IsClosed = checkBox1.Checked;
                    or.ClientID = Client.ClientID;
                    or.DiscID = Disc.DiscID;
                }
                else
                    contex.Orders.Add(inOrder);
                contex.SaveChanges();
                Close();
            }
            else MessageBox.Show("Заполните все поля");
      
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

        private void button4_Click(object sender, EventArgs e)
        {
            InputClient form = new InputClient(null);
            form.ShowDialog();
            if (form.GetClient() != null)
            {
                Client = form.GetClient();
                textBox1.Text = Client.Surname + " " + Client.Name + " " + Client.Patronymic;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm(true, true);
            form.ShowDialog();
            if (form.GetDisc() != null)
            {
                Disc = form.GetDisc();
                textBox3.Text = Disc.Name;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            InputDisc form = new InputDisc(null);
            form.ShowDialog();
            if (form.GetDisc() != null)
            {
                Disc = form.GetDisc();
                textBox3.Text = Disc.Name;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
