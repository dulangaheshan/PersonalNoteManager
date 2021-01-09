/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 16:53:19
 * @modify date 2021-01-09 16:53:19
 * @desc [user functions implementation]
 */
using CordFortPersonalNoteManager.Contracts;
using CordFortPersonalNoteManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
        {
        }
        /*
        *select all users
        */
        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                 .OrderBy(ow => ow.UserID)
                 .ToList();
        }
    }
}
