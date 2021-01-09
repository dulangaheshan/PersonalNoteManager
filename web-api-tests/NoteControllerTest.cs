/**
 * @author [D.5haN]
 * @email [dulangah2@gmail.com]
 * @create date 2021-01-10 02:11:50
 * @modify date 2021-01-10 02:11:50
 * @desc [unit test for Note Controller]
 */
using AutoMapper;
using CordFortPersonalNoteManager.Contracts;
using CordFortPersonalNoteManager.Controllers;
using CordFortPersonalNoteManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace web_api_tests
{
    public class NoteControllerTest
    {
        NoteController _controller;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public NoteControllerTest()
        {
            _controller = new NoteController(_repository, _mapper);
        }

        /**
            * CreateNote
            ** Unit test for create note correct parameters 
            * params@{Note}
        */
        [Fact]
        public void CreateNote()
        {

            var note = new Note()
            {
                UserID = 1,
                Content = "content from unit test",
                Title = "title from unit test"
            };
           
            
            // Act
            var badResponse = _controller.CreateNote(note);
            // Assert
            Assert.IsType<OkObjectResult>(badResponse);

        }
        /**
            * CreateNote
            ** Unit test for create note with out user ID 
            * params@{Note}
        */
        [Fact]
        public void CreateNoteWithoutUserID()
        {

            var note = new Note()
            {
                Content = "content from unit test",
                Title = "title from unit test"
            };


            // Act
            var badResponse = _controller.CreateNote(note);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);

        }

        /**
            * CreateNote
            ** Unit test for update note without user Id
            * params@{userId, nodeId, Note}
        */
        [Fact]
        public void UpdateNoteWithoutUserID()
        {

            var note = new Note()
            {
                Content = "content from unit test",
                Title = "title from unit test"
            };


            // Act
            var badResponse = _controller.UpdateNote(1, 4, note);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);

        }

    }
}
