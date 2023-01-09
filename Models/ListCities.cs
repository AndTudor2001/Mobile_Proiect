using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_Proiect.Models
{
    public class ListCities
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Hotel))]
        public int HotelID { get; set; }
        public int CityID { get; set; }
        
    }
}
