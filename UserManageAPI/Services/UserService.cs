using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageAPI.Models;

namespace UserManageAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ConcurrentDictionary<Guid, User> _store = new();

        public UserService()
        {
            // seed mock data
            var u1 = new User { Id = Guid.NewGuid(), Name = "Alice", Email = "alice@example.com", Age = 30 };
            var u2 = new User { Id = Guid.NewGuid(), Name = "Bob", Email = "bob@example.com", Age = 25 };
            _store[u1.Id] = u1;
            _store[u2.Id] = u2;
        }

        public Task<User> CreateAsync(User user)
        {
            user.Id = Guid.NewGuid();
            _store[user.Id] = user;
            return Task.FromResult(user);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return Task.FromResult(_store.TryRemove(id, out _));
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult(_store.Values.AsEnumerable());
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var user);
            return Task.FromResult(user);
        }

        public Task<bool> UpdateAsync(Guid id, User user)
        {
            if (!_store.ContainsKey(id)) return Task.FromResult(false);
            user.Id = id;
            _store[id] = user;
            return Task.FromResult(true);
        }
    }
}
