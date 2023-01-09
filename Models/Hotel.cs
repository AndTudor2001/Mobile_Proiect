using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Proiect.Models
{
    public class Hotel
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        [ForeignKey(typeof(Orase))]
        public int OrasID { get; set; }


    }
}
