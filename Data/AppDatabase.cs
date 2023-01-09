using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mobile_Proiect;
using Mobile_Proiect.Models;
using SQLite;

namespace Mobile_Proiect.Data
{
    public class AppDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AppDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Tara>().Wait();
            _database.CreateTableAsync<Orase>().Wait();
            _database.CreateTableAsync<ListOrase>().Wait();
            _database.CreateTableAsync<Hotel>().Wait();
            _database.CreateTableAsync<City>().Wait();
            _database.CreateTableAsync<ListCities>().Wait();
            _database.CreateTableAsync<Review>().Wait();
            
        }
        public Task<List<Hotel>>GetHoteluriAsync()
        {
            return _database.Table<Hotel>().ToListAsync();
        }

        public Task<int>SaveHotelAsync(Hotel hotel)
        {
            if(hotel.ID!=0)
            {
                return _database.UpdateAsync(hotel);
            }
            else
            {
                return _database.InsertAsync(hotel);
            }
        }
        public Task<int>DeleteHotelAsync(Hotel hotel)
        {
            return _database.DeleteAsync(hotel);
        }
      
        public Task<int> SaveOrasAsync(Orase oras)
        {
            if (oras.ID != 0)
            {
                return _database.UpdateAsync(oras);
            }
            else
            {
                return _database.InsertAsync(oras);
            }
        }
        public Task<int> DeleteOrasAsync(Orase oras)
        {
            return _database.DeleteAsync(oras);
        }
        public Task<List<Orase>> GetOraseAsync()
        {
            return _database.Table<Orase>().ToListAsync();
        }

        public Task<List<Tara>> GetTariAsync()
        {
            return _database.Table<Tara>().ToListAsync();
        }
        public Task<Tara> GetTaraAsync(int id)
        {
            return _database.Table<Tara>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveTaraAsync(Tara tara)
        {
            if (tara.ID != 0)
            {
                return _database.UpdateAsync(tara);
            }
            else
            {
                return _database.InsertAsync(tara);
            }
        }
        public Task<int> DeleteTaraAsync(Tara tara)
        {
            return _database.DeleteAsync(tara);
        }
        public Task<int> SaveListOraseAsync(ListOrase listo)
        {
            if (listo.ID != 0)
            {
                return _database.UpdateAsync(listo);
            }
            else
            {
                return _database.InsertAsync(listo);
            }
        }
        public Task<int> DeleteListOraseAsync(ListOrase listo)
        {

            return _database.DeleteAsync(listo);
        }

        public Task<ListOrase> GetListOraseAsync(int taraid, int orasid)
        {
            return _database.Table<ListOrase>().
                Where(i => (i.TaraID == taraid && i.OrasID == orasid))
                .FirstOrDefaultAsync();
        }
       
        public Task<List<Orase>> GetListOrasesAsync(int taraid)
        {
            return _database.QueryAsync<Orase>(
            "select P.ID, P.Nume from Orase P"
            + " inner join ListOrase LP"
            + " on P.ID = LP.OrasID where LP.TaraID = ?",
            taraid);
        }
        public Task<int> SaveCityAsync(City city)
        {
            if (city.ID != 0)
            {
                return _database.UpdateAsync(city);
            }
            else
            {
                return _database.InsertAsync(city);
            }
        }
        public Task<int> DeleteCityAsync(City city)
        {
            return _database.DeleteAsync(city);
        }
        public Task<List<City>> GetCityAsync()
        {
            return _database.Table<City>().ToListAsync();
        }
        public Task<int> SaveListCitiesAsync(ListCities listc)
        {
            if (listc.ID != 0)
            {
                return _database.UpdateAsync(listc);
            }
            else
            {
                return _database.InsertAsync(listc);
            }
        }
        public Task<int> DeleteListCitiesAsync(ListCities listc)
        {

            return _database.DeleteAsync(listc);
        }
        public Task<ListCities> GetListCitiesAsync(int hotelid, int cityid)
        {
            return _database.Table<ListCities>().
                Where(i => (i.HotelID == hotelid && i.CityID == cityid))
                .FirstOrDefaultAsync();
        }

        public Task<List<City>> GetListCitiessAsync(int hotelid)
        {
            return _database.QueryAsync<City>(
            "select P.ID, P.Nume from City P"
            + " inner join ListCities LP"
            + " on P.ID = LP.CityID where LP.HotelID = ?",
            hotelid);
        }
        public Task<List<Review>> GetReviewsAsync() 
        { 
            return _database.Table<Review>().ToListAsync(); 
        }
        public Task<Review> GetReviewAsync(int id) 
        { 
            return _database.Table<Review>().Where(i => i.ID == id).FirstOrDefaultAsync(); 
        }
        public Task<int> SaveShopListAsync(Review review)
        {
            if (review.ID != 0)
            {
                return _database.UpdateAsync(review);
            }
            else { return _database.InsertAsync(review); }
        }
        public Task<int> DeleteShopListAsync(Review review) 
        { 
            return _database.DeleteAsync(review); 
        }
    }
}