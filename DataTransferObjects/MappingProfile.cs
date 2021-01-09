/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-09 17:31:18
 * @modify date 2021-01-09 17:31:18
 * @desc [model to data transfer object mapper]
 */
using AutoMapper;
using CordFortPersonalNoteManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CordFortPersonalNoteManager.DataTransferObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Note, NoteDto>();
            CreateMap<Note, NoteForUpdateDto>();
        }
    }
}
