using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Mobile_Proiect.Models;
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
        }
        public Task<List<Tara>>GetTariAsync()
        {
            return _database.Table<Tara>().ToListAsync();
        }
        public Task<Tara> GetTaraAsync(int id)
        {
            return _database.Table<Tara>().
                Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveTaraAsync(Tara tara)
        {
            if(tara.ID!=0)
            {
                return _database.UpdateAsync(tara);
            }
            else
            {
                return _database.InsertAsync(tara);
            }
        }
        public Task<int>DeleteTaraAsync(Tara tara)
        {
            return _database.DeleteAsync(tara);
        }
        public Task<int>SaveOrasAsync(Orase oras)
        {
            if(oras.ID!=0)
            {
                return _database.UpdateAsync(oras);
            }
            else
            {
                return _database.InsertAsync(oras);
            }
        }
        public Task<int>DeleteOrasAsync(Orase oras)
        {
            return _database.DeleteAsync(oras);
        }
        public Task<List<Orase>>GetOraseAsync()
        {
            return _database.Table<Orase>().ToListAsync();
        }
        public Task<int>SaveListOraseAsync(ListOrase listo)
        {
            if(listo.ID!=null)
            {
                return _database.UpdateAsync(listo);
            }
            else
            {
                return _database.InsertAsync(listo);
            }
        }
        public Task<List<Orase>>GetListOraseAsync(int taraid)
        {
            return _database.QueryAsync<Orase>(
              "select P.ID, P.Nume from Orase P"
              + " inner join ListOrase LP"
              + " on P.ID = LP.OrasID where LP.TaraID = ?",
              taraid);
        }
    }
}
