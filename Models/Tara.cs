using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Mobile_Proiect.Models
{
    public class Tara
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Continent { get; set; }
    }
}
