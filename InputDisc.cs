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
    public partial class InputDisc : Form
    {
        Disc Disc, inDisc;
        public InputDisc(Disc disc)
        {
            InitializeComponent();
            Disc = disc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InputFilm filmform = new InputFilm(null);
            filmform.ShowDialog();
            if (filmform.GetFilm()!=null) listBox1.Items.Add(filmform.GetFilm().Name);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm(false, false);
            form.ShowDialog();
            if (form.GetFulm() != null) listBox1.Items.Add(form.GetFulm().Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && listBox1.Items.Count != 0)
            {
                VideoContext contex = new VideoContext();
                if (Disc == null)
                {
                    inDisc = new Disc
                    {
                        Name = textBox1.Text,
                        IsAvailable = checkBox1.Checked
                    };

                    contex.Discs.Add(inDisc);
                    contex.SaveChanges();
                    int discID = contex.Discs.Where(d => d.Name == inDisc.Name).FirstOrDefault().DiscID;
                    var removefims = contex.DiscFilms.Where(d => d.DiscID == discID);
                    contex.DiscFilms.RemoveRange(removefims);
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        String fd;
                        fd = listBox1.Items[i].ToString();
                        DiscFilms inDiscFilms = new DiscFilms
                        {
                            DiscID = discID,
                            FilmID = contex.Films.Where(f => f.Name == fd).FirstOrDefault().FilmID
                        };
                        contex.DiscFilms.Add(inDiscFilms);
                        contex.SaveChanges();
                    }
                }
                else
                {
                    Disc d = contex.Discs.Where(f => f.DiscID == Disc.DiscID).FirstOrDefault();
                    d.Name = textBox1.Text;
                    d.IsAvailable = checkBox1.Checked;
                    contex.SaveChanges();
                    int discID = contex.Discs.Where(dw => dw.Name == d.Name).FirstOrDefault().DiscID;
                    var removefims = contex.DiscFilms.Where(dw => dw.DiscID == discID);
                    contex.DiscFilms.RemoveRange(removefims);
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        String fd;
                        fd = listBox1.Items[i].ToString();
                        DiscFilms inDiscFilms = new DiscFilms
                        {
                            DiscID = discID,
                            FilmID = contex.Films.Where(f => f.Name == fd).FirstOrDefault().FilmID
                        };
                        contex.DiscFilms.Add(inDiscFilms);
                        contex.SaveChanges();
                    }

                }

                Close();
            }
             else MessageBox.Show("Заполните все поля");
        }

        private void InputDisc_Load(object sender, EventArgs e)
        {
            if (Disc != null)
            {
                textBox1.Text = Disc.Name;
                checkBox1.Checked = Disc.IsAvailable;
                VideoContext contex = new VideoContext();
                var films = contex.DiscFilms.Include("Film").Where(d => d.DiscID == Disc.DiscID);
                foreach (DiscFilms f in films)
                {
                    listBox1.Items.Add(f.Film.Name);
                }
            }
        }
        public Disc GetDisc()
        {
            return inDisc;
        }
    }
}
