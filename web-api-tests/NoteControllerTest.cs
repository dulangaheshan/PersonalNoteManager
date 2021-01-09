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
