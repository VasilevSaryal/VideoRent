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
    public partial class SearchForm : Form
    {
        Client client;
        Film film;
        Disc inDisc;
        bool search, disc;
        public SearchForm(bool search, bool disc)
        {
            InitializeComponent();
            if (search)
                dataGridView1.MultiSelect = false;
            else
                dataGridView1.MultiSelect = true;
            this.search = search;
            this.disc = disc;
            
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            VideoContext contex = new VideoContext();
            if (disc)
            {
                dataGridView1.DataSource = contex.Discs.ToList<Disc>();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Название";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].HeaderText = "Доступность";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].Visible = false;
            }
            else
            {
                if (search)
                {
                    dataGridView1.DataSource = contex.Clients.ToList<Client>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Имя";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].HeaderText = "Фамилия";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].HeaderText = "Возраст";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].HeaderText = "Телефон";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].HeaderText = "В черном списке";
                }
                else
                {
                    dataGridView1.DataSource = contex.Films.Include("Type").ToList<Film>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Название";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].HeaderText = "Тип";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].HeaderText = "Год";
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].Visible = false;
                }
            }
            string[] s = new string[dataGridView1.Columns.Count];
            comboBox1.Items.Clear();
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].Visible == true)
                {
                    s[i] = dataGridView1.Columns[i].HeaderText;
                    comboBox1.Items.Add(s[i]);
                }
            }
        }
        private void RefreshDataBase()
        {
            VideoContext contex = new VideoContext();
            if (disc)
            {
                dataGridView1.DataSource = contex.Discs.ToList<Disc>();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Название";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].HeaderText = "Доступность";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].Visible = false;
            }
            else
            {
                if (search)
                {
                    dataGridView1.DataSource = contex.Clients.ToList<Client>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Имя";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].HeaderText = "Фамилия";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].HeaderText = "Возраст";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].HeaderText = "Телефон";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].HeaderText = "В черном списке";
                }
                else
                {
                    dataGridView1.DataSource = contex.Films.Include("Type").ToList<Film>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Название";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].HeaderText = "Тип";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].HeaderText = "Год";
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].Visible = false;
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            VideoContext contex = new VideoContext();
            if (textBox1.Text.Length > 0)
            {
                int index = comboBox1.SelectedIndex + 1;
                if (disc)
                {
                    switch (index)
                    {
                        case 1:
                            var a = contex.Discs.Where(c => c.Name.ToLower().StartsWith(textBox1.Text.ToLower()));
                            dataGridView1.DataSource = a.ToList();
                            break;
                        case 2:
                            a = contex.Discs.Where(c => c.IsAvailable.ToString().ToLower().StartsWith(textBox1.Text.ToLower()));
                            dataGridView1.DataSource = a.ToList();
                            break;
                    }
                }
                else
                {
                    if (search)
                    {
                        switch (index)
                        {
                            case 1:
                                var a = contex.Clients.Where(c => c.Name.ToLower().StartsWith(textBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 2:
                                a = contex.Clients.Where(c => c.Surname.ToLower().StartsWith(textBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 3:
                                a = contex.Clients.Where(c => c.Patronymic.ToLower().StartsWith(textBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 4:
                                a = contex.Clients.Where(c => c.Age.ToString().ToLower().StartsWith(textBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 5:
                                a = contex.Clients.Where(c => c.Phone.ToString().ToLower().StartsWith(textBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                        }

                    }
                    else
                    {
                        switch (index)
                        {
                            case 1:
                                var a = contex.Films.Where(f => f.Name.ToLower().StartsWith(textBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 2:
                                a = contex.Films.Where(f => f.Type.Type.ToLower().StartsWith(textBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 3:
                                a = contex.Films.Where(f => f.Year.ToString().ToLower().StartsWith(textBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                        }
                    }
                }
            }
            else RefreshDataBase();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                for (int j = 0; j < dataGridView1.RowCount; j++)
                    if (dataGridView1[i, j].Selected == true)
                        dataGridView1.Rows[j].Selected = true;
            VideoContext contex = new VideoContext();
            int index = dataGridView1.SelectedRows[0].Index, id = 0;
            Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            if (disc)
            {
                inDisc = contex.Discs.Where(c => c.DiscID == id).FirstOrDefault();
            }
            else
            {
                if (search)
                    client = contex.Clients.Where(c => c.ClientID == id).FirstOrDefault();
                else
                    film = contex.Films.Where(f => f.FilmID == id).FirstOrDefault();
            }
            Close();
        }

        public Client GetClient()
        {
            return client;
        }
        public Film GetFulm()
        {
            return film;
        }
        public Disc GetDisc()
        {
            return inDisc;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex].Selected = true;
        }
    }
}
