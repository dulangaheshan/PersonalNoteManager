/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-08 19:18:45
 * @modify date 2021-01-08 19:18:45
 * @desc [User Entity]
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }
        public string UserName { get; set; }

        
    }
}
