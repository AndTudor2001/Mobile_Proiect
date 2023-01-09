using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Proiect.Models
{
    public class Review
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string NumePersoana { get; set; }
        public string NumeHotel { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
