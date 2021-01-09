/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:12:31
 * @modify date 2021-01-09 17:12:31
 * @desc [Query Functions for Notes]
 */
using CordFortPersonalNoteManager.Contracts;
using CordFortPersonalNoteManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Repository
{
    public class NoteRepository : RepositoryBase<Note>, INoteRepository
    {
        public NoteRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        /**
            * CreateNote
            * Insert Note in to database
            * @params{Note note}
        */
        public void CreateNote(Note Note)
        {
            Create(Note);
        }


        /**
            * DeleteNote
            * * delete note
            * @params{Note note}
        */
        public void DeleteNote(Note Note)
        {
            Delete(Note);
        }


        /**
            * UpdateNote
            * * Upadate specific note
            * @params{Note note}
        */
        public void UpdateNote(Note Note)
        {
            Update(Note);
        }


        /**
            * Update Note
            * @params{}
        */
        public IEnumerable<Note> GetAllArchivedNotes()
        {
            return FindAll()
                .Where(Note => Note.IsArchived == true);
        }

        /**
            * GetAllNotArchivedNotes
            * * get all archived note
            * @params{}
        */
        public IEnumerable<Note> GetAllNotArchivedNotes()
        {
            return FindAll().Where(Note => Note.IsArchived == false);
        }

        /**
            * GetAllNotes
            ** get all notes and with order by user id
            * @params{}
        */
        public IEnumerable<Note> GetAllNotes()
        {
            return FindAll()
                .OrderBy(ow => ow.UserID)
                .ToList();
        }

        /**
            * GetNote
            ** get single note with note id
            * @params{NoteId}
        */
        public Note GetNote(long NoteId)
        {
            return FindByCondition(Note => Note.NoteId.Equals(NoteId)).FirstOrDefault();
        }


        /**
            * GetSpecificNote
            * * specific single node from user
            * @params{NoteId, UserID}
        */
        public Note GetSpecificNote(long NoteId, long UserID)
        {
            return FindAll()
                .Where(Note => Note.NoteId == NoteId && Note.UserID == UserID).FirstOrDefault();
        }


        /**
            * GetUSerNotes
            * * get all notes of user
            * @params{UserID}
        */
        public IEnumerable<Note> GetUSerNotes(long UserID)
        {
            return FindByCondition(Note => Note.UserID.Equals(UserID));
        }


        /**
            * GetUserID
            * @params{noteID}
        */
        public int GetUserID(long noteID)
        {
            return 5;
            //return FindByCondition(Note => Note.NoteId.Equals(/*noteID*/)).FirstOrDefault();
        }


        /**
            * UserGetAllArchivedNotes
            * * user's all archived notes
            * @params{userId}
        */
        public IEnumerable<Note> UserGetAllArchivedNotes(long userId)
        {
            return FindAll()
                .Where(Note => Note.IsArchived == true && Note.UserID == userId);
        }


        /**
            * GetAllNotArchivedNotes
            * * user's all not archived notes
            * @params{userId}
        */
        public IEnumerable<Note> UserGetAllNotArchivedNotes(long userId)
        {
            return FindAll()
                .Where(Note => Note.IsArchived == false && Note.UserID == userId);
        }
    }
}
