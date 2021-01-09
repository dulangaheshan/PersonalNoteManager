/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-08 19:18:02
 * @modify date 2021-01-08 19:18:02
 * @desc [Note Entity]
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Models
{
    [Table("note")]
    public class Note
    {
        public long NoteId { get; set; }
        public DateTime DateCreated { get; set; }
        [ForeignKey(nameof(User))]
        public long UserID { get; set; }
        public String DocumentPath { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public Boolean IsArchived { get; set; }
        public User User { get; set; }
    }
}

