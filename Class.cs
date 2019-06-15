using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Videorent
{
        public class Genre
        {
            [Key]
            public int GenreID { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        public class FilmType
        {
            [Key]
            public int TypeID { get; set; }
            public string Type { get; set; }
            public override string ToString()
            {
                return Type;
            }
        }
        public class FilmGenres
        {
            [Key]
            public int FilmGenresID { get; set; }
            public int FilmID { get; set; }
            [ForeignKey("FilmID")]
            public Film Film { get; set; }
            public int GenreID { get; set; }
            [ForeignKey("GenreID")]
            public Genre Genre { get; set; }
        }
        public class Film
        {
            [Key]
            public int FilmID { get; set; }
            public string Name { get; set; }
            public int[] GenreId  { get; set; }
            [ForeignKey("GenreId")]
            public virtual Genre[] Genre { get; set; }
            public int TypeID { get; set; }
            [ForeignKey("TypeID")]
            public virtual FilmType Type { get; set; }
            public int Year { get; set; }
            public string Image { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
        public class Disc
        {
            [Key]
            public int DiscID { get; set; }
            public string Name { get; set; }
            public bool IsAvailable { get; set; }
            public Film Films { get; set; }
            public override string ToString()
            {
                return Name;
            }
            /*public int OrderID { get; set; }
            [ForeignKey("OrderID")]
            public Order Order { get; set; }*/
            
            
        }
        public class DiscFilms 
        {
            [Key]
            public int DiscFilmId { get; set; }
            public int DiscID { get; set; }
            [ForeignKey("DiscID")]
            public Disc Disc { get; set; }
            public int FilmID { get; set; }
            [ForeignKey("FilmID")]
            public Film Film { get; set; }
        }
        public class Client
        {
            [Key]
            public int ClientID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Patronymic { get; set; }
            public int Age { get; set; }
            public long Phone { get; set; }
            public bool InBlacklist { get; set; }
            public override string ToString()
            {
                return Surname + " " + Name + " " + Patronymic;
            }
            //public Order Orders { get; set; }
        }
        public class Order
        {
            [Key]
            public int OrderID { get; set; }
            public string DepositeType { get; set; }
            public DateTime StartAt { get; set; }
            public DateTime ExpiredAt { get; set; }
            public int ClientID { get; set; }
            [ForeignKey("ClientID")]
            public Client Client { get; set; }
            public bool IsClosed { get; set; }
            public int MoneyAmount { get; set; }
            public int DiscID { get; set; }
            [ForeignKey("DiscID")]
            public Disc Disc { get; set; }
        }
}
