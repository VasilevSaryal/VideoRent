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
    public partial class AllForm : Form
    {
        VideoContext contex;
        int form;
        bool search=false;
        public AllForm()
        {
            this.contex = new VideoContext();
            InitializeComponent();
        }
        public void RefreshDataBase()
        {
            Console.Out.Write("Obnova");
            this.contex = new VideoContext();
            switch (form)
            {
                case 1:
                    dataGridView1.DataSource = this.contex.Clients.ToList<Client>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Имя";
                    dataGridView1.Columns[2].HeaderText = "Фамилия";
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[4].HeaderText = "Возраст";
                    dataGridView1.Columns[5].HeaderText = "Телефон";
                    dataGridView1.Columns[6].HeaderText = "В черном списке";
                    break;
                case 2:
                    dataGridView1.DataSource = this.contex.Orders.ToList<Order>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Тип депозита";
                    dataGridView1.Columns[2].HeaderText = "Дата взятия";
                    dataGridView1.Columns[3].HeaderText = "Крайний срок";
                    dataGridView1.Columns[4].HeaderText = "Клиент";
                    dataGridView1.Columns[5].HeaderText = "Закрыт";
                    dataGridView1.Columns[6].HeaderText = "Денежный залог";
                    break;
                case 3:
                    dataGridView1.DataSource = this.contex.Discs.Include("Film").ToList<Disc>();
                    break;
                case 4:
                    dataGridView1.DataSource = this.contex.Films.ToList<Film>();
                    break;
            }
        }
        private void Database(object sender, EventArgs e)
        {
            string db = (sender as ToolStripMenuItem).Text;
            //dataGridView1.DataSource.Equals(null);
            switch (db)
            {
                case "Клиентов":       
                    dataGridView1.DataSource = this.contex.Clients.ToList<Client>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Имя";
                    dataGridView1.Columns[2].HeaderText = "Фамилия";
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[4].HeaderText = "Возраст";
                    dataGridView1.Columns[5].HeaderText = "Телефон";
                    dataGridView1.Columns[6].HeaderText = "В черном списке";
                    form = 1;
                    //comboBox1.Update();
                    //comboBox1.ResetText();
                    //comboBox1.DataSource = dataGridView1.Columns;
              
                    //comboBox1.DisplayMember = "HeaderText";
                    break;
                case "Заказов":
                    dataGridView1.DataSource = this.contex.Orders.Include("Client").ToList<Order>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Тип депозита";
                    dataGridView1.Columns[2].HeaderText = "Дата взятия";
                    dataGridView1.Columns[3].HeaderText = "Крайний срок";
                    dataGridView1.Columns[4].HeaderText = "Клиент";
                    dataGridView1.Columns[5].HeaderText = "Закрыт";
                    dataGridView1.Columns[6].HeaderText = "Денежный залог";
                    form = 2;
                    break;
                case "Дисков":
                    dataGridView1.DataSource = this.contex.Discs.ToList<Disc>();
                    form = 3;
                    break;
                case "Фильмов":
                    dataGridView1.DataSource = this.contex.Films.ToList<Film>();
                    form = 4;
                    break;
            }
            

        }

        private void AllForm_Load(object sender, EventArgs e)
        {

        }

        private void Operation(object sender, EventArgs e)
        {
            string op = (sender as ToolStripMenuItem).Text;
            switch (op)
            {
                case "Добавить":
                    switch (form)
                    {
                        case 1:
                            InputClient incl = new InputClient(null);
                            incl.ShowDialog();
                            break;
                        case 2:
                            InputOrder ino = new InputOrder();
                            ino.ShowDialog();
                            break;
                    }
                    break;
                case "Редактировать":
                    switch (form)
                    {
                        case 1:
                            int index = dataGridView1.SelectedRows[0].Index, id = 0;
                            Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                            Client client = contex.Clients.Where(c => c.ClientID == id).FirstOrDefault();
                            InputClient rcl = new InputClient(client);
                            rcl.ShowDialog();
                            break;
                    }
                    break;
                case "Удалить":
                    switch (form)
                    {
                        case 1:
                            int index = dataGridView1.SelectedRows[0].Index, id = 0;
                            Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                            Client client = contex.Clients.Where(c => c.ClientID == id).FirstOrDefault();
                            contex.Clients.Remove(client);
                            contex.SaveChanges();
                            break;
                    }
                    break;
       
            }
            RefreshDataBase();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (search == false)
            {
                toolStripComboBox1.Visible = true;
                toolStripTextBox1.Visible = true;
                search = true;
                string[] s = new string[dataGridView1.Columns.Count];
                toolStripComboBox1.Items.Clear();
                for (int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    s[i] = dataGridView1.Columns[i].HeaderText;
                    toolStripComboBox1.Items.Add(s[i]);
                }
            }
            else
            {
                toolStripComboBox1.Visible = false;
                toolStripTextBox1.Visible = false;
                search = false;
                RefreshDataBase();
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void SelectAllRow(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void всеToolStripMenuItem_Click(object sender, EventArgs e)
        {


            dataGridView1.SelectAll();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Length > 2)
            {
                int index = toolStripComboBox1.SelectedIndex + 1;
                switch (form)
                {
                    case 1:
                        switch (index)
                        {
                            case 1:
                                var a = this.contex.Clients.Where(c => c.Name.ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 2:
                                a = this.contex.Clients.Where(c => c.Surname.ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 3:
                                a = this.contex.Clients.Where(c => c.Patronymic.ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 4:
                                a = this.contex.Clients.Where(c => c.Age.ToString().ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 5:
                                a = this.contex.Clients.Where(c => c.Phone.ToString().ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                        }
                        break;
                }
            }
            else RefreshDataBase();
        }
    }         
}
        
     
    
           

        