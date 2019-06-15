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
    public partial class InputFilm : Form
    {
        OpenFileDialog openFileDialog1;
        Film inFilm, Film;
        FilmGenres inGenres;
        List<Genre> Genres;
        string TypeF;
        List<Int32> GenresID;
        FilmType Type;
        public InputFilm(Film film)
        {
            InitializeComponent();
            if (film != null)
            {
                this.Film = film;
                VideoContext contex = new VideoContext();
                var genres = contex.FimsGenres.Where(g => g.FilmID == Film.FilmID);
                openFileDialog1 = new OpenFileDialog();
                openFileDialog1.FileName = Film.Image;
                FilmType inType = contex.FilmTypes.Where(t => t.TypeID == Film.TypeID).FirstOrDefault();
                Type = inType;
                this.TypeF = film.Type.ToString();
                GenresID = new List<int>();
                foreach (FilmGenres g in genres)
                {
                    //Genre genre = contex.Genres.Where(c => c.GenreID == g.GenreID).FirstOrDefault();
                    GenresID.Add(g.GenreID);
                }
            }
           
          
        }
        private Bitmap MyImage;
        private void ShowMyImage(string fileToDisplay, int xSize, int ySize)
        {

            if (MyImage != null)
            {
                MyImage.Dispose();
            }

 
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap(fileToDisplay);
            pictureBox1.ClientSize = new Size(xSize, ySize);
            pictureBox1.Image = (Image)MyImage;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ShowMyImage(openFileDialog1.FileName, pictureBox1.Size.Width, pictureBox1.Size.Height);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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

        private void InputFilm_Load(object sender, EventArgs e)
        {
            if (Film != null)
            {
                VideoContext contex = new VideoContext();
                ShowMyImage(Film.Image, pictureBox1.Size.Width, pictureBox1.Size.Height);
                textBox1.Text = Film.Name;
                textBox2.Text = Film.Year.ToString();
                textBox4.Text = Film.Type.ToString();
                foreach (int c in GenresID)
                {

                    textBox3.Text += contex.Genres.Where(g=>g.GenreID==c).FirstOrDefault() + " ";
                }
            }
        }
        public Film GetFilm()
        {
            return inFilm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != ""&&pictureBox1.Image!=null)
            {
                VideoContext contex = new VideoContext();
                if (Film == null)
                {
                    inFilm = new Film
                    {
                        Image = openFileDialog1.FileName,
                        Name = textBox1.Text,
                        Year = Convert.ToInt32(textBox2.Text),
                        TypeID = Type.TypeID
                    };
                    contex.Films.Add(inFilm);
                    contex.SaveChanges();
                    for (int i = 0; i < Genres.Count; i++)
                    {
                        inGenres = new FilmGenres
                        {
                            FilmID = inFilm.FilmID,
                            GenreID = Genres[i].GenreID
                        };
                        contex.FimsGenres.Add(inGenres);
                        contex.SaveChanges();
                    }
                }
                else
                {
                    contex = new VideoContext();
                    GenresID = new List<int>();
                    Film film = contex.Films.Where(f => f.FilmID == Film.FilmID).FirstOrDefault();
                    film.Image = openFileDialog1.FileName;
                    film.Name = textBox1.Text;
                    film.Year = Convert.ToInt32(textBox2.Text);
                    film.TypeID = Type.TypeID;
                    String s = textBox3.Text;
                    String[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String genre in words)
                    {
                        GenresID.Add(contex.Genres.Where(g => g.Name == genre).FirstOrDefault().GenreID);
                    }
                    for (int i = 0; i < GenresID.Count; i++)
                    {
                        var flg = contex.FimsGenres.Where(g => g.FilmID == Film.FilmID);
                        foreach (FilmGenres g in flg)
                        {
                            contex.FimsGenres.Remove(g);
                        }
                        contex.SaveChanges();
                        for (int j = 0; j < GenresID.Count; j++)
                        {
                            inGenres = new FilmGenres
                            {
                                FilmID = Film.FilmID,
                                GenreID = GenresID[j]
                            };
                            contex.FimsGenres.Add(inGenres);
                            contex.SaveChanges();
                        }
                    }
                    contex.SaveChanges();
                }
                Close();
            }
            else MessageBox.Show("Заполните все поля и загрузите фото");
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            GenresID = new List<int>();
            if (textBox3.Text != null)
            {
                VideoContext contex = new VideoContext();
                String s = textBox3.Text;
                String[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(String genre in words)
                {
                    GenresID.Add(contex.Genres.Where(g => g.Name == genre).FirstOrDefault().GenreID);
                }
                InputJenre form = new InputJenre(GenresID, textBox4.Text);
                form.ShowDialog();
                if (form.GetGenres() != null && form.GetType() != null)
                {
                    Genres = form.GetGenres();
                    Type = form.GetType();
                }

                textBox3.Text = "";
            }
            else
            {
                InputJenre form = new InputJenre(null, null);
                form.ShowDialog();
                if (form.GetGenres() != null && form.GetType() != null)
                {
                    Genres = form.GetGenres();
                    Type = form.GetType();
                }
            }
            if (Type != null && Genres != null)
            {
                foreach (Genre c in Genres)
                {
                    textBox3.Text += c.Name + " ";
                }
                textBox4.Text = Type.Type;
            }
            
            
        }

            
    }
}
