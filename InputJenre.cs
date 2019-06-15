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
    public partial class InputJenre : Form
    {
        List<Genre> genre = new List<Genre>();
        List<int> GenreID = new List<int>();
        String Type;
        bool Edit;
        public InputJenre(List<int> GenreID, String Type)
        {
            InitializeComponent();
            if (GenreID != null)
            {
                this.Type = Type;
                this.GenreID = GenreID;
                Edit = true;
            }
            VideoContext contex = new VideoContext();
            var types = contex.FilmTypes;
            foreach (FilmType c in types)
            {
                comboBox1.Items.Add(c.Type);
            }
           
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            Button button = (sender as Button);
            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.BlueViolet;
                
            }
            else button.BackColor = Color.White;
        }

        private void InputJenre_Load(object sender, EventArgs e)
        {
            if (Edit)
            {
                comboBox1.Text = Type;
                foreach (int g in GenreID)
                {
                    switch (g)
                    {
                        case 1:
                            button3.BackColor = Color.BlueViolet;
                            break;
                        case 2:
                            button4.BackColor = Color.BlueViolet;
                            break;
                        case 3:
                            button5.BackColor = Color.BlueViolet;
                            break;
                        case 4:
                            button6.BackColor = Color.BlueViolet;
                            break;
                        case 5:
                            button7.BackColor = Color.BlueViolet;
                            break;
                        case 6:
                            button8.BackColor = Color.BlueViolet;
                            break;
                        case 7:
                            button9.BackColor = Color.BlueViolet;
                            break;
                        case 8:
                            button21.BackColor = Color.BlueViolet;
                            break;
                        case 9:
                            button10.BackColor = Color.BlueViolet;
                            break;
                        case 10:
                            button11.BackColor = Color.BlueViolet;
                            break;
                        case 11:
                            button12.BackColor = Color.BlueViolet;
                            break;
                        case 12:
                            button13.BackColor = Color.BlueViolet;
                            break;
                        case 13:
                            button14.BackColor = Color.BlueViolet;
                            break;
                        case 14:
                            button15.BackColor = Color.BlueViolet;
                            break;
                        case 15:
                            button16.BackColor = Color.BlueViolet;
                            break;
                        case 16:
                            button17.BackColor = Color.BlueViolet;
                            break;
                        case 17:
                            button18.BackColor = Color.BlueViolet;
                            break;
                        case 18:
                            button20.BackColor = Color.BlueViolet;
                            break;
                        case 19:
                            button19.BackColor = Color.BlueViolet;
                            break;
                    }    
                }
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
  
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                VideoContext contex = new VideoContext();
                if (button3.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 1).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button4.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 2).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button5.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 3).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button6.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 4).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button7.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 5).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button8.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 6).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button9.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 7).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button21.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 8).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button10.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 9).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button11.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 10).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button12.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 11).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button13.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 12).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button14.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 13).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button15.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 14).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button16.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 15).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button17.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 16).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button18.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 17).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button20.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 18).FirstOrDefault();
                    this.genre.Add(genre);
                }
                if (button19.BackColor == Color.BlueViolet)
                {
                    Genre genre = contex.Genres.Where(c => c.GenreID == 19).FirstOrDefault();
                    this.genre.Add(genre);
                }
                Type = comboBox1.Text;
                Close();
            }
            else MessageBox.Show("Выберите тип и хотя бы один жанр");
        }
        public FilmType GetType()
        {
            VideoContext contex = new VideoContext();
            FilmType Type = contex.FilmTypes.Where(c => c.Type == comboBox1.Text).FirstOrDefault();
            return Type;
        }
        public List<Genre> GetGenres()
        {
            return genre;
        }
    }
}
