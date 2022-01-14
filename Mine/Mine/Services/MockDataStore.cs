using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Bug Net", Description="Catch bug to pay for your loan from a raccoon.", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Fishing Pole", Description="Catch fish to pay for your loan from a raccoon.", Value=1 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Diving Suit", Description="Dive to pay for your loan from a raccoon.", Value=3 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Coffee", Description="Keeps you awake while working.", Value=6 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Bells", Description="Pays your loan.", Value=9 },
            };
        }

        public async Task<bool> AddItemAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}