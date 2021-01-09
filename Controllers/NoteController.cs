/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:33:11
 * @modify date 2021-01-09 17:33:11
 * @desc [Api end points for Note]
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CordFortPersonalNoteManager.Contracts;
using CordFortPersonalNoteManager.DataTransferObjects;
using CordFortPersonalNoteManager.Models;
using CordFortPersonalNoteManager.utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CordFortPersonalNoteManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {


        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public NoteController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        /*
         * get all notes
         * Route  GET: api/Note
         * params@{}
         */
        [Route("allnotes")]
        [HttpGet]
        public IActionResult GetAllNotes()
        {
            try
            {
                var notes = _repository.Note.GetAllNotes();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        /*
         * get all archived notes
         * Route  GET: api/Note/allarchivednotes
         * params@{}
         */
        [Route("allarchivednotes")]
        [HttpGet]
        public IActionResult GetAllArchivedNotes()
        {
            try
            {
                var notes = _repository.Note.GetAllArchivedNotes();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /*
         * get all  not archived notes
         * Route  GET: api/Note/allnotarchivednotes
         * params@{}
        */
        [Route("allnotarchivednotes")]
        [HttpGet]
        public IActionResult GetAllNotArchivedNotes()
        {
            try
            {
                var notes = _repository.Note.GetAllNotArchivedNotes();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        /*
         * get all single note buy id
         * Route  GET: api/Note/?noteId={noteId}
         * params@{noteId}
        */
        [Route("noteId=noteId")]
        [HttpGet(Name = "GetNote")]
        public IActionResult GetNote(long noteId)
        {
            try
            {
                var notes = _repository.Note.GetNote(noteId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        /*
         * get all notes
         * Route  GET: api/Note/{userId}
         * params@{noteId}
        */
        [Route("user/{userId}")]
        [HttpGet]
        public IActionResult GetUserNote(long userId)
        {
            try
            {
                var notes = _repository.Note.GetUSerNotes(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        /*
         * get user's archived notes
         * Route  GET: api/user/allarchivednotes/{userId}
         * params@{userId}
        */
        [Route("user/allarchivednotes/{userID}")]
        [HttpGet]
        public IActionResult UserArchivedNotes(long userId)
        {
            try
            {
                var notes = _repository.Note.UserGetAllArchivedNotes(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        /*
            * get user's not archived notes
            * Route  GET: api/user/allarchivednotes/{userId}
            * params@{userId}
        */
        [Route("user/allnotarchivednotes/{userID}")]
        [HttpGet]
        public IActionResult UserNotArchivedNotes(long userId)
        {
            try
            {
                var notes = _repository.Note.UserGetAllNotArchivedNotes(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        /*
            * get user's specific note
            * Route  GET: api/user/allarchivednotes/{userId}
            * params@{userId}
        */
        [Route("user/{userID}/{noteId}")]
        [HttpGet]
        public IActionResult GetSpecificNote(long userId, long noteId)
        {
            try
            {
                var notes = _repository.Note.GetSpecificNote(noteId, userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /*
            * Create Note
            * Route  POST: api/user/allarchivednotes/{userId}
            * params@{userId}
        */
        [HttpPost]
        public IActionResult CreateNote([FromBody]Note note)
        {
            try
            {
                if (note == null)
                {
                    return BadRequest("Note object is null");
                }
                if (!ModelState.IsValid)
                {
                        return BadRequest("Invalid model object");
                }

                note.DateCreated = DateTime.Now;

                if (note.IsArchived == true)
                {
                    FileManager sw = new FileManager();
                    var path  = sw.GenerateTxt(note);
                    note.DocumentPath = path;
                    note.Content = "";
                }

                 var NoteEntity = _mapper.Map<Note>(note);
                 _repository.Note.CreateNote(NoteEntity);
                  _repository.Save();
                  var CreatedNote = _mapper.Map<Note>(NoteEntity);
                  return CreatedAtRoute("GetNote", new { id = CreatedNote.NoteId }, CreatedNote);
                }
                catch (Exception ex)
                    {
                    
                    return StatusCode(500, "Internal server error");
                }
            }

        /*
            * Update Note
            * Route  PUT: api/note/{userId}/{noteID}
            * params@{userId} @{noteID}

        */
        [HttpPut("{userId}/{noteId}")]
        public IActionResult UpdateNote(long noteId, long UserId, [FromBody]Note note)
        {
            try
            {
                if (note == null)
                {
                    return BadRequest("Note object is null");
                }
                if (!ModelState.IsValid)
                {

                    return BadRequest("Invalid model object");
                }

                var noteEntity = _repository.Note.GetSpecificNote(noteId, UserId);
                if (noteEntity == null)
                {
                    return NotFound();
                }
                if (noteEntity.IsArchived)
                {
                    FileManager sw = new FileManager();
                    var path = sw.GenerateTxt(note);
                    note.DocumentPath = path;
                    note.Content = "";
                }
                _mapper.Map(note, noteEntity);

                _repository.Note.UpdateNote(note);
                _repository.Save();
                return Ok("Note Updated Successfully");
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }
        /*
            * Delete Note
            * Route  Delete: api/note/{userId}/{noteID}
            * params@{userId} @{noteID}

        */
        [HttpDelete("{userId}/{noteId}")]
        public IActionResult Delete(int noteId, int userId)
        {
            try
            {
                var noteEntity = _repository.Note.GetSpecificNote(noteId, userId);
                if (noteEntity == null)
                {
                    return NotFound();
                }

                if (noteEntity.IsArchived)
                {
                    FileManager sw = new FileManager();
                    sw.DeleteFiles(noteEntity.DocumentPath);
                }

                _repository.Note.DeleteNote(noteEntity);
                _repository.Save();
                return Ok("Note Deleted Sucessfully");
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Internal server error");
            }

        }



        /*
          * Archived
          * * Archived not archived note 
          * Route  Delete: api/note/{userId}/{noteID}
          * params@{userId} @{noteID}

      */
        [Route("user/archived/{userId}/{noteId}")]
        [HttpGet]
        public IActionResult Archived(int noteId, int userId)
        {
            try
            {
                var noteEntity = _repository.Note.GetSpecificNote(noteId, userId);
                if (noteEntity == null)
                {
                    return NotFound();
                }

                if (!noteEntity.IsArchived)
                {
                    FileManager sw = new FileManager();
                    var path = sw.GenerateTxt(noteEntity);
                    noteEntity.DocumentPath = path;
                    noteEntity.Content = "";
                    noteEntity.IsArchived = true;


                    _repository.Note.UpdateNote(noteEntity);
                    _repository.Save();
                    return Ok("Note Archived Success");
                }
                else
                {
                    return Ok("Note Alredy archived");
                }
              //  _mapper.Map(note, noteEntity);

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }

        }
    }
}
