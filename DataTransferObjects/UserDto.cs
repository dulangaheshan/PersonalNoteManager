/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:32:55
 * @modify date 2021-01-09 17:32:55
 * @desc [dto for user]
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.DataTransferObjects
{
    public class UserDto
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
    }
}
