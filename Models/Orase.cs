using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Proiect.Models
{
    public class Orase
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        [OneToMany]
        public List<ListOrase> Orases { get; set; }
    }
}
