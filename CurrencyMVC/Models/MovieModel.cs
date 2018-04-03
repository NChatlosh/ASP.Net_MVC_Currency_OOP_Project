using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyMVC.Models
{
    public class MovieModel
    {
        private int primaryKey;
        public int PrimaryKey {
            get { return primaryKey; }
            set { primaryKey = value; }
        }
        public string Title { get; set; }
        public int YearReleased { get; set; }
        public string Genre { get; set; }

        public MovieModel(string Title, int key) : this(Title, key, 0, "N/A")
        { }
        public MovieModel(string Title, int key, int year) : this(Title, key, year, "N/A")
        { }
        public MovieModel(string title, int key, int year, string genre)
        {
            Title = title;
            primaryKey = key;
            YearReleased = year;
            Genre = genre;
        }

    }
}
