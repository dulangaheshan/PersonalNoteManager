﻿/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:31:51
 * @modify date 2021-01-09 17:31:51
 * @desc [data transfer modal for Note]
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.DataTransferObjects
{
    public class NoteDto
    {

        public long NoteId { get; set; }
        public DateTime DateCreated { get; set; }
        public long UserID { get; set; }
        public String DocumentPath { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public Boolean IsArchived { get; set; }
    
    }
}
