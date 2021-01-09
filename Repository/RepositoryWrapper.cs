/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:10:33
 * @modify date 2021-01-09 17:10:33
 * @desc [Repository wrapper]
 */
using CordFortPersonalNoteManager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IUserRepository _user;
        private INoteRepository _note;
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }
        public INoteRepository Note
        {
            get
            {
                if (_note == null)
                {
                    _note = new NoteRepository(_repoContext);
                }
                return _note;
            }
        }


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
