/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 16:49:43
 * @modify date 2021-01-09 16:49:43
 * @desc [functional abstractions for Note]
 */
using CordFortPersonalNoteManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Contracts
{
    public interface INoteRepository : IRepositoryBase<Note>
    {
        IEnumerable<Note> GetAllNotes();
        IEnumerable<Note> GetAllArchivedNotes();
        IEnumerable<Note> GetAllNotArchivedNotes();
        IEnumerable<Note> UserGetAllArchivedNotes(long userId);
        IEnumerable<Note> UserGetAllNotArchivedNotes(long userId);
        Note GetNote(long NoteId);
        int GetUserID(long UserID);
        IEnumerable<Note> GetUSerNotes(long UserID);
        Note GetSpecificNote(long NoteId, long UserID);
        void DeleteNote(Note Note);
        void CreateNote(Note Note);
        void UpdateNote(Note Note);
    }
}
