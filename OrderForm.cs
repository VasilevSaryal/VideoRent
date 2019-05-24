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
    public partial class OrderForm : Form
    {
        VideoContext contex;
        public OrderForm()
        {
            this.contex = new VideoContext();
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "ID Заказа";
            col0.Name = "OrderID";
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Тип депозита";
            col1.Name = "DepositeType";
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Дата взятия";
            col2.Name = "StartAt";
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Крайний срок";
            col3.Name = "ExpiredAt";
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Клиент";
            col4.Name = "Client";
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Закрыт";
            col5.Name = "IsClosed";
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Денежный залог";
            col6.Name = "MoneyAmount";
            this.dataGridView1.Columns.Add(col0);
            this.dataGridView1.Columns.Add(col1);
            this.dataGridView1.Columns.Add(col6);
            this.dataGridView1.Columns.Add(col2);
            this.dataGridView1.Columns.Add(col3);
            this.dataGridView1.Columns.Add(col4);
            this.dataGridView1.Columns.Add(col5);
            var cl = contex.Orders.Include("Client");
            foreach (Order c in cl)
            {
                DataGridViewCell cel0 = new DataGridViewTextBoxCell();
                DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                DataGridViewCell cel6 = new DataGridViewTextBoxCell();
                DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                DataGridViewCell cel5 = new DataGridViewTextBoxCell();
                DataGridViewRow row = new DataGridViewRow();
                cel0.Value = c.OrderID;
                cel1.Value = c.DepositeType;
                cel2.Value = c.MoneyAmount;
                cel3.Value = c.StartAt.ToString("D");
                cel4.Value = c.ExpiredAt.ToString("D");
                cel5.Value = c.Client.Patronymic+ " "+c.Client.Name+" "+c.Client.Patronymic;
                cel6.Value = c.IsClosed;
                row.Cells.AddRange(cel0, cel1, cel2, cel3, cel4, cel5, cel6);
                this.dataGridView1.Rows.Add(row);
                
            }
           // dataGridView1.DataSource = this.contex.Orders.ToList<Order>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputOrder fr = new InputOrder();
            fr.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index, id = 0;
            Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            Order order = contex.Orders.Where(c => c.OrderID == id).FirstOrDefault();
            contex.Orders.Remove(order);
            contex.SaveChanges();
        }
    }
}
