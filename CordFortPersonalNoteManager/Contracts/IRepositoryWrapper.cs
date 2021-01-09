/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 16:51:14
 * @modify date 2021-01-09 16:51:14
 * @desc [wrap finctions of user and note as single unit ]
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User{ get; }
        INoteRepository Note { get; }
        void Save();
    }
}
