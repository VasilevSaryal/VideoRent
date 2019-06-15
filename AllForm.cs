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
        List<FilmGenres> inFilmsGenres = new List<FilmGenres>();
        int form;
        bool search=false;
        
        public AllForm()
        {
           // this.contex = new VideoContext();
            InitializeComponent();
            Autoresation nnn = new Autoresation();
            nnn.ShowDialog();
        }
        private void RefreshDataBase()
        {
            if ((form == 4 || form == 3) && search == false)
            {
                dataGridView1.Rows.Clear();
                int count = dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)
                    dataGridView1.Columns.RemoveAt(0);
            }
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
                     dataGridView1.DataSource = this.contex.Orders.Include("Client").Include("Disc").ToList<Order>();
                    dataGridView1.Columns[0].HeaderText = "Номер заказа";
                    dataGridView1.Columns[1].HeaderText = "Тип депозита";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].HeaderText = "Дата взятия";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].HeaderText = "Крайний срок";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].HeaderText = "Клиент";
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].HeaderText = "Закрыт";
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[7].HeaderText = "Денежный залог";
                    dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].HeaderText = "Диск";
                    dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
                case 3:
                      dataGridView1.DataSource = null;
                    DataGridViewTextBoxColumn dcolID = new DataGridViewTextBoxColumn();
                    dcolID.HeaderText = "ДискID";
                    dcolID.Name = "DiscID";
                    DataGridViewTextBoxColumn dcol0 = new DataGridViewTextBoxColumn();
                    dcol0.HeaderText = "Название диска";
                    dcol0.Name = "Name";
                    DataGridViewTextBoxColumn dcol1 = new DataGridViewTextBoxColumn();
                    dcol1.HeaderText = "Доступно";
                    dcol1.Name = "IsAvailable";
                    DataGridViewTextBoxColumn dcol2 = new DataGridViewTextBoxColumn();
                    dcol2.HeaderText = "Фильмы";
                    dcol2.Name = "Films";
                    this.dataGridView1.Columns.Add(dcolID);
                    this.dataGridView1.Columns.Add(dcol0);
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns.Add(dcol1);
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns.Add(dcol2);
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].Visible = false;
                    List<DiscFilms> discfilms = new List<DiscFilms>();
                    var films = this.contex.DiscFilms.Include("Disc").Include("Film");
                    foreach (DiscFilms d in films)
                        discfilms.Add(d);
                    var discs = this.contex.Discs;
                    foreach (Disc ds in discs)
                    {
                        DataGridViewCell DcelID = new DataGridViewTextBoxCell();
                        DataGridViewCell dcel1 = new DataGridViewTextBoxCell();
                        DataGridViewCell dcel2 = new DataGridViewTextBoxCell();
                        DataGridViewCell dcel3 = new DataGridViewTextBoxCell();
                        DataGridViewRow drow = new DataGridViewRow();
                        DcelID.Value = ds.DiscID;
                        dcel1.Value = ds.Name;
                        if (ds.IsAvailable)
                            dcel2.Value = "Да";
                        else
                            dcel2.Value = "Нет";
                        for (int i = 0; i < discfilms.Count; i++)
                        {
                            if (discfilms[i].DiscID == ds.DiscID)
                                dcel3.Value += discfilms[i].Film.Name + " ";
                        }
                        drow.Cells.AddRange(DcelID, dcel1, dcel2, dcel3);
                        this.dataGridView1.Rows.Add(drow);
        
                    }
                    break;
                case 4:
                    dataGridView1.DataSource = null;
                    DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
                    colID.HeaderText = "ФильмID";
                    colID.Name = "FilmID";
                    DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                    col0.HeaderText = "Постер";
                    col0.Name = "Image";
                    col0.Width = 111;
                    DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                    col1.HeaderText = "Название";
                    col1.Name = "FilmName";
                    col1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                    col2.HeaderText = "Тип";
                    col2.Name = "Type";
                    col2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                    col3.HeaderText = "Год";
                    col3.Name = "Year";
                    col3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    col3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                    col4.HeaderText = "Жанр";
                    col4.Name = "Genre";
                    col4.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    col4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    col4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dataGridView1.Columns.Add(colID);
                    this.dataGridView1.Columns.Add(col0);
                    this.dataGridView1.Columns.Add(col1);
                    this.dataGridView1.Columns.Add(col2);
                    this.dataGridView1.Columns.Add(col3);
                    this.dataGridView1.Columns.Add(col4);
                    inFilmsGenres = new List<FilmGenres>();
                    this.dataGridView1.Columns[0].Visible = false;
                    var genres = this.contex.FimsGenres.Include("Film").Include("Genre");
                    foreach (FilmGenres fg in genres)
                    {
                        inFilmsGenres.Add(fg);
                    }
                    var film = this.contex.Films.Include("Type");
                    foreach (Film c in film)
                    {
                        DataGridViewCell celID = new DataGridViewTextBoxCell();
                        DataGridViewImageCell ImageCell0 = new DataGridViewImageCell();
                        DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                        DataGridViewRow row = new DataGridViewRow();

                        Bitmap MyImage;
                        MyImage = new Bitmap(c.Image);
                        ImageCell0.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        ImageCell0.Value = MyImage;

                        celID.Value = c.FilmID;
                        cel1.Value = c.Name;
                        cel2.Value = c.Type;
                        cel3.Value = c.Year;
                        
                        for (int i=0; i<inFilmsGenres.Count; i++)
                        {
                            if (inFilmsGenres[i].FilmID == c.FilmID)
                                cel4.Value += inFilmsGenres[i].Genre + Environment.NewLine;
                        }
                        row.Cells.AddRange(celID, ImageCell0, cel1, cel2, cel3, cel4);
                        row.Height = 127;
                        this.dataGridView1.Rows.Add(row);
                    }
                    break;
            }
        }
        private void Database(object sender, EventArgs e)
        {
            if ((form == 4 || form == 3) && search == false)
            {
                dataGridView1.Rows.Clear();
                int count = dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)
                    dataGridView1.Columns.RemoveAt(0);
            }
            this.contex = new VideoContext();
            toolStripComboBox1.Visible = false;
            toolStripTextBox1.Visible = false;
            search = false;
            string db = (sender as ToolStripMenuItem).Text;
            switch (db)
            {
                case "Клиентов":
                    dataGridView1.DataSource = this.contex.Clients.ToList<Client>();
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
                    form = 1;
                    break;
                case "Заказов":
                    dataGridView1.DataSource = this.contex.Orders.Include("Client").Include("Disc").ToList<Order>();
                    dataGridView1.Columns[0].HeaderText = "Номер заказа";
                    dataGridView1.Columns[1].HeaderText = "Тип депозита";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].HeaderText = "Дата взятия";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].HeaderText = "Крайний срок";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].HeaderText = "Клиент";
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].HeaderText = "Закрыт";
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[7].HeaderText = "Денежный залог";
                    dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].HeaderText = "Диск";
                    dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //dataGridView1.DataSource = this.contex.DiscFilms.Include("Disc").Include("Film").ToList<DiscFilms>();
                    form = 2;
                    break;
                case "Дисков":
                    //dataGridView1.DataSource = this.contex.Discs.ToList<Disc>();
                    dataGridView1.DataSource = null;
                    DataGridViewTextBoxColumn dcolID = new DataGridViewTextBoxColumn();
                    dcolID.HeaderText = "ДискID";
                    dcolID.Name = "DiscID";
                    DataGridViewTextBoxColumn dcol0 = new DataGridViewTextBoxColumn();
                    dcol0.HeaderText = "Название диска";
                    dcol0.Name = "Name";
                    DataGridViewTextBoxColumn dcol1 = new DataGridViewTextBoxColumn();
                    dcol1.HeaderText = "Доступно";
                    dcol1.Name = "IsAvailable";
                    DataGridViewTextBoxColumn dcol2 = new DataGridViewTextBoxColumn();
                    dcol2.HeaderText = "Фильмы";
                    dcol2.Name = "Films";
                    this.dataGridView1.Columns.Add(dcolID);
                    this.dataGridView1.Columns.Add(dcol0);
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns.Add(dcol1);
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns.Add(dcol2);
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].Visible = false;
                    List<DiscFilms> discfilms = new List<DiscFilms>();
                    var films = this.contex.DiscFilms.Include("Disc").Include("Film");
                    foreach (DiscFilms d in films)
                        discfilms.Add(d);
                    var discs = this.contex.Discs;
                    foreach (Disc ds in discs)
                    {
                        DataGridViewCell DcelID = new DataGridViewTextBoxCell();
                        DataGridViewCell dcel1 = new DataGridViewTextBoxCell();
                        DataGridViewCell dcel2 = new DataGridViewTextBoxCell();
                        DataGridViewCell dcel3 = new DataGridViewTextBoxCell();
                        DataGridViewRow drow = new DataGridViewRow();
                        DcelID.Value = ds.DiscID;
                        dcel1.Value = ds.Name;
                        if (ds.IsAvailable)
                            dcel2.Value = "Да";
                        else
                            dcel2.Value = "Нет";
                        for (int i = 0; i < discfilms.Count; i++)
                        {
                            if (discfilms[i].DiscID == ds.DiscID)
                                dcel3.Value += discfilms[i].Film.Name + " ";
                        }
                        drow.Cells.AddRange(DcelID, dcel1, dcel2, dcel3);
                        this.dataGridView1.Rows.Add(drow);
        
                    }
                    form = 3;
                    break;
                case "Фильмов":
                    //dataGridView1.DataSource = this.contex.Films.ToList<Film>();
                    dataGridView1.DataSource = null;
                    DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
                    colID.HeaderText = "ФильмID";
                    colID.Name = "FilmID";
                    DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
                    col0.HeaderText = "Постер";
                    col0.Name = "Image";
                    col0.Width = 111;
                    DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
                    col1.HeaderText = "Название";
                    col1.Name = "FilmName";
                    col1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
                    col2.HeaderText = "Тип";
                    col2.Name = "Type";
                    col2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    col2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
                    col3.HeaderText = "Год";
                    col3.Name = "Year";
                    col3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    col3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
                    col4.HeaderText = "Жанр";
                    col4.Name = "Genre";
                    col4.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    col4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                    col4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dataGridView1.Columns.Add(colID);
                    this.dataGridView1.Columns.Add(col0);
                    this.dataGridView1.Columns.Add(col1);
                    this.dataGridView1.Columns.Add(col2);
                    this.dataGridView1.Columns.Add(col3);
                    this.dataGridView1.Columns.Add(col4);
                    inFilmsGenres = new List<FilmGenres>();
                    this.dataGridView1.Columns[0].Visible = false;
                    var genres = this.contex.FimsGenres.Include("Film").Include("Genre");
                    foreach (FilmGenres fg in genres)
                    {
                        inFilmsGenres.Add(fg);
                    }
                    var film = this.contex.Films.Include("Type");
                    foreach (Film c in film)
                    {
                        DataGridViewCell celID = new DataGridViewTextBoxCell();
                        DataGridViewImageCell ImageCell0 = new DataGridViewImageCell();
                        DataGridViewCell cel1 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel2 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel3 = new DataGridViewTextBoxCell();
                        DataGridViewCell cel4 = new DataGridViewTextBoxCell();
                        DataGridViewRow row = new DataGridViewRow();

                        Bitmap MyImage;
                        MyImage = new Bitmap(c.Image);
                        ImageCell0.ImageLayout = DataGridViewImageCellLayout.Stretch;
                        ImageCell0.Value = MyImage;

                        celID.Value = c.FilmID;
                        cel1.Value = c.Name;
                        cel2.Value = c.Type;
                        cel3.Value = c.Year;
                        
                        for (int i=0; i<inFilmsGenres.Count; i++)
                        {
                            if (inFilmsGenres[i].FilmID == c.FilmID)
                                cel4.Value += inFilmsGenres[i].Genre + Environment.NewLine;
                        }
                        row.Cells.AddRange(celID, ImageCell0, cel1, cel2, cel3, cel4);
                        row.Height = 127;
                        this.dataGridView1.Rows.Add(row);
                    }
                    form = 4;
                    break;
            }         
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
                            InputOrder ino = new InputOrder(null);
                            ino.ShowDialog();
                            break;
                        case 3:
                            InputDisc ind = new InputDisc(null);
                            ind.ShowDialog();
                            break;
                        case 4:
                            InputFilm film = new InputFilm(null);
                            film.ShowDialog();
                            break;
                    }
                    break;
                case "Редактировать":
                  
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                            if (dataGridView1[i, j].Selected == true)
                                dataGridView1.Rows[j].Selected = true;                           
                    switch (form)
                    {
                        case 1:
                            int index = dataGridView1.SelectedRows[0].Index, id = 0;
                            Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                            Client client = contex.Clients.Where(c => c.ClientID == id).FirstOrDefault();
                            InputClient rcl = new InputClient(client);
                            rcl.ShowDialog();
                            break;
                        case 2:
                            int index2 = dataGridView1.SelectedRows[0].Index, id2 = 0;
                            Int32.TryParse(dataGridView1[0, index2].Value.ToString(), out id2);
                            Order order = contex.Orders.Where(c => c.OrderID == id2).FirstOrDefault();
                            InputOrder ord = new InputOrder(order);
                            ord.ShowDialog();
                            break;
                        case 3:
                            
                            int index3 = dataGridView1.SelectedRows[0].Index, id3 = 0;
                            Int32.TryParse(dataGridView1[0, index3].Value.ToString(), out id3);
                            Disc disc = contex.Discs.Where(c => c.DiscID == id3).FirstOrDefault();
                            InputDisc df = new InputDisc(disc);
                            df.ShowDialog();
                            
                            
                            break;
                        case 4:

                            int index4 = dataGridView1.SelectedRows[0].Index, id4 = 0;
                          
                           
                            Int32.TryParse(dataGridView1[0, index4].Value.ToString(), out id4);

                            Film flm = contex.Films.Where(f => f.FilmID == id4).FirstOrDefault();
                            InputFilm ff = new InputFilm(flm);
                            ff.ShowDialog();
                          
                            break;
                    }
                    break;
                case "Удалить":
                    
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                            if (dataGridView1[i, j].Selected == true)
                                dataGridView1.Rows[j].Selected = true;
                    switch (form)
                    {
                        case 1:
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                //dataGridView1.Rows[ed.RowIndex].Selected = true;
                                if (dataGridView1.Rows[i].Selected == true)
                                {
                                     
                                    //int index = dataGridView1.SelectedRows[0].Index, id = 0;
                                    int id;
                                    Int32.TryParse(dataGridView1[0, i].Value.ToString(), out id);
                                    Client client = contex.Clients.Where(c => c.ClientID == id).FirstOrDefault();
                                    contex.Clients.Remove(client);
                                    contex.SaveChanges();
                                }
                            }
                            break;
                        case 2:
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                if (dataGridView1.Rows[i].Selected == true)
                                {
                                    //int index = dataGridView1.SelectedRows[0].Index, id = 0;
                                    int id2;
                                    Int32.TryParse(dataGridView1[0, i].Value.ToString(), out id2);
                                    Order order = contex.Orders.Where(c => c.OrderID == id2).FirstOrDefault();
                                    contex.Orders.Remove(order);
                                    contex.SaveChanges();
                                }
                            }
                            break;
                        case 3:
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                if (dataGridView1.Rows[i].Selected == true)
                                {
                                    //int index = dataGridView1.SelectedRows[0].Index, id = 0;
                                    int id3;
                                    
                                    Int32.TryParse(dataGridView1[0, i].Value.ToString(), out id3);
                                    Disc disc = contex.Discs.Where(c => c.DiscID == id3).FirstOrDefault();
                                    contex.Discs.Remove(disc);
                                    contex.SaveChanges();
                                    
                                }
                            }
                            break;
                        case 4:
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                if (dataGridView1.Rows[i].Selected == true)
                                {
                                    //int index = dataGridView1.SelectedRows[0].Index, id = 0;
                                    int id4;

                                    Int32.TryParse(dataGridView1[0, i].Value.ToString(), out id4);
                                    Film film = contex.Films.Where(c => c.FilmID == id4).FirstOrDefault();
                                    contex.Films.Remove(film);
                                    contex.SaveChanges();
                                    
                                  
                                }
                            }
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
                if (dataGridView1.DataSource == null)
                {
                    if (form == 4 || form == 3)
                    {
                        dataGridView1.Rows.Clear();
                        int count = dataGridView1.Columns.Count;
                        for (int i = 0; i < count; i++)
                            dataGridView1.Columns.RemoveAt(0);

                    }
                }
                RefreshDataBaseSearch();
                toolStripComboBox1.Visible = true;
                toolStripTextBox1.Visible = true;
                search = true;
                string[] s = new string[dataGridView1.Columns.Count];
                toolStripComboBox1.Items.Clear();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    if (dataGridView1.Columns[i].Visible == true)
                    {
                        s[i] = dataGridView1.Columns[i].HeaderText;
                        toolStripComboBox1.Items.Add(s[i]);
                    }
                }
            }
            else
            {
                /*if (dataGridView1.DataSource == null)
                {
                    if (form == 4 || form == 3)
                    {
                        dataGridView1.Rows.Clear();
                        int count = dataGridView1.Columns.Count;
                        for (int i = 0; i < count; i++)
                            dataGridView1.Columns.RemoveAt(0);

                    }
                }*/
                toolStripComboBox1.Visible = false;
                toolStripTextBox1.Visible = false;
                search = false;
                if (form == 4 || form == 3)
                    dataGridView1.DataSource = null;
                RefreshDataBase();
            }
        }

 

        private void всеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Length > 0)
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
                    case 2:
                        switch (index)
                        {
                            case 1:
                                var a = contex.Orders.Where(c => c.OrderID.ToString().ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 2:
                                a = contex.Orders.Where(c => c.DepositeType.ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 3:
                                a = contex.Orders.Where(c => c.StartAt.ToString().StartsWith(toolStripTextBox1.Text));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 4:
                                a = contex.Orders.Where(c => c.ExpiredAt.ToString().ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 5:
                                a = contex.Orders.Where(c => (c.Client.Surname + " " + c.Client.Name + " " + c.Client.Patronymic).ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 6:
                                a = contex.Orders.Where(c => c.IsClosed.ToString().ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 7:
                                a = contex.Orders.Where(c => c.MoneyAmount.ToString().ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 8:
                                a = contex.Orders.Where(c => c.Disc.Name.ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                        }
                        break;
                    case 3:
                        switch (index)
                        {
                            case 1:
                                var a = contex.Discs.Where(c => c.Name.ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 2:
                                a = contex.Discs.Where(c => c.IsAvailable.ToString().ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                        }
                        break;
                    case 4:
                        switch (index)
                        {
                            case 1:
                                var a = contex.Films.Where(f => f.Name.ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 2:
                                a = contex.Films.Where(f => f.Type.Type.ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                            case 3:
                                a = contex.Films.Where(f => f.Year.ToString().ToLower().StartsWith(toolStripTextBox1.Text.ToLower()));
                                dataGridView1.DataSource = a.ToList();
                                break;
                        }
                        break;
                }
            }
            else RefreshDataBaseSearch();
        } 
        private void AllForm_Load(object sender, EventArgs e)
        {
           
            this.contex = new VideoContext();
            if (this.contex.Genres.Where(c => c.GenreID == 1).FirstOrDefault() == null)
            {
                Genre genre1 = new Genre
                {
                    Name = "Боевик"
                };
                Genre genre2 = new Genre
                {
                    Name = "Вестерн"
                };
                Genre genre3 = new Genre
                {
                    Name = "Ганстерский"
                };
                Genre genre4 = new Genre
                {
                    Name = "Детектив"
                };
                Genre genre5 = new Genre
                {
                    Name = "Драма"
                };
                Genre genre6 = new Genre
                {
                    Name = "Исторический"
                };
                Genre genre7 = new Genre
                {
                    Name = "Комедия"
                };
                Genre genre8 = new Genre
                {
                    Name = "Катастрофа"
                };
                Genre genre9 = new Genre
                {
                    Name = "Мелодрама"
                };
                Genre genre10 = new Genre
                {
                    Name = "Музыкальный"
                };
                Genre genre11 = new Genre
                {
                    Name = "Нуар"
                };
                Genre genre12 = new Genre
                {
                    Name = "Политический"
                };
                Genre genre13 = new Genre
                {
                    Name = "Приключение"
                };
                Genre genre14 = new Genre
                {
                    Name = "Сказка"
                };
                Genre genre15 = new Genre
                {
                    Name = "Трагедия"
                };
                Genre genre16 = new Genre
                {
                    Name = "Трагикомедия"
                };
                Genre genre17 = new Genre
                {
                    Name = "Триллер"
                };
                Genre genre18 = new Genre
                {
                    Name = "Ужасы"
                };
                Genre genre19 = new Genre
                {
                    Name = "Фантастика"
                };
                contex.Genres.Add(genre1);
                contex.Genres.Add(genre2);
                contex.Genres.Add(genre3);
                contex.Genres.Add(genre4);
                contex.Genres.Add(genre5);
                contex.Genres.Add(genre6);
                contex.Genres.Add(genre7);
                contex.Genres.Add(genre8);
                contex.Genres.Add(genre9);
                contex.Genres.Add(genre10);
                contex.Genres.Add(genre11);
                contex.Genres.Add(genre12);
                contex.Genres.Add(genre13);
                contex.Genres.Add(genre14);
                contex.Genres.Add(genre15);
                contex.Genres.Add(genre16);
                contex.Genres.Add(genre17);
                contex.Genres.Add(genre18);
                contex.Genres.Add(genre19);
                contex.SaveChanges();
            }

            if (contex.FilmTypes.Where(c => c.TypeID == 1).FirstOrDefault() == null)
            {
                FilmType Type1 = new FilmType
                {
                    Type = "Кино"
                };
                FilmType Type2 = new FilmType
                {
                    Type = "Мультфильм"
                };
                FilmType Type3 = new FilmType
                {
                    Type = "Аниме"
                };
                contex.FilmTypes.Add(Type1);
                contex.FilmTypes.Add(Type2);
                contex.FilmTypes.Add(Type3);
                contex.SaveChanges();
            }
        }
        public void RefreshDataBaseSearch()
        {
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
                    dataGridView1.DataSource = this.contex.Orders.Include("Client").Include("Disc").ToList<Order>();
                    dataGridView1.Columns[0].HeaderText = "Номер заказа";
                    dataGridView1.Columns[1].HeaderText = "Тип депозита";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].HeaderText = "Дата взятия";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].HeaderText = "Крайний срок";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].HeaderText = "Клиент";
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[6].HeaderText = "Закрыт";
                    dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[7].HeaderText = "Денежный залог";
                    dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[9].HeaderText = "Диск";
                    dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    break;
                case 3:
                    dataGridView1.DataSource = this.contex.Discs.ToList<Disc>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Название";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].HeaderText = "Доступность";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].Visible = false;
                break;
                case 4:
                    dataGridView1.DataSource = this.contex.Films.Include("Type").ToList<Film>();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderText = "Название";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].HeaderText = "Тип";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[4].HeaderText = "Год";
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[5].Visible = false;
                    break;
            }
        }
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void отчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                for (int j = 0; j < dataGridView1.RowCount; j++)
                    if (dataGridView1[i, j].Selected == true)
                        dataGridView1.Rows[j].Selected = true;
                    
                
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime sss = new DateTime(2000, 12, 31, 22, 56, 59);
            if ((form == 4 || form == 3) && search == false)
            {
                dataGridView1.Rows.Clear();
                int count = dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)
                    dataGridView1.Columns.RemoveAt(0);
            }
            OrderTimeForm f = new OrderTimeForm();
            f.ShowDialog();
            DateTime a, b;
            a = f.GetStartAt(); b = f.GetExpiredAt();
            if (b != sss)
            {
                var c = this.contex.Orders.Include("Client").Where(q => (q.StartAt == a && q.StartAt == b));
                dataGridView1.DataSource = c.ToList<Order>();
                dataGridView1.Columns[0].HeaderText = "Номер заказа";
                dataGridView1.Columns[1].HeaderText = "Тип депозита";
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].HeaderText = "Дата взятия";
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].HeaderText = "Крайний срок";
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].HeaderText = "Клиент";
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].HeaderText = "Закрыт";
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].HeaderText = "Денежный залог";
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].HeaderText = "Диск";
                dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                form = 2;
            }
             
        }

        private void истекшиеЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((form == 4 || form == 3) && search == false)
            {
                dataGridView1.Rows.Clear();
                int count = dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)
                    dataGridView1.Columns.RemoveAt(0);
            }
            DateTime a = DateTime.Now.Date;
            var c = this.contex.Orders.Include("Client").Where(q => (q.ExpiredAt < a && q.IsClosed == false));
            dataGridView1.DataSource = c.ToList<Order>();
            dataGridView1.Columns[0].HeaderText = "Номер заказа";
            dataGridView1.Columns[1].HeaderText = "Тип депозита";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].HeaderText = "Дата взятия";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].HeaderText = "Крайний срок";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Клиент";
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].HeaderText = "Закрыт";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].HeaderText = "Денежный залог";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].HeaderText = "Диск";
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            form = 2;
        }

        private void черныйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((form == 4 || form == 3) && search == false)
            {
                dataGridView1.Rows.Clear();
                int count = dataGridView1.Columns.Count;
                for (int i = 0; i < count; i++)
                    dataGridView1.Columns.RemoveAt(0);
            }
                var a = this.contex.Clients.Where(c=>c.InBlacklist == true);
                dataGridView1.DataSource = a.ToList<Client>();
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
            
            form = 1;

        }
    }         
}
        
     
    
           

        