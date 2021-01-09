/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 16:52:26
 * @modify date 2021-01-09 16:52:26
 * @desc [functional abstraction for user]
 */
using CordFortPersonalNoteManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        void CreateNote(User User);
    }
}
