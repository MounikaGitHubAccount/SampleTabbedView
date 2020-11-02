using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampleTabbedView.Models;
using SQLite;
using Xamarin.Forms;

namespace SampleTabbedView.Services
{
    public class LocalDatabase : ContentPage
    {
        readonly SQLiteAsyncConnection _database;

        public LocalDatabase(string dbPath)
        {

            //Establishing the conection
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>().Wait();

        }

        // Show the List
        public Task<List<Item>> GetTaskAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }

        // Save registers
        public Task<int> SaveTaskAsync(Item taskr)
        {
            return _database.InsertAsync(taskr);
        }

        // Update 
        public Task<int> UpdateTaskAsync(Item taskr)
        {
            return _database.UpdateAsync(taskr);
        }

        //Delete  
        public Task<int> DeleteTaskAsync(Item task)
        {
            return _database.DeleteAsync(task);
        }
    }
}

