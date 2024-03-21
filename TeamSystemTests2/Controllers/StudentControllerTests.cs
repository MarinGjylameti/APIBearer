using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TeamSystem.Models.DTOs;
using TeamSystem.Models;
using TeamSystem.ServiceLayer;
using Xunit;
using Assert = Xunit.Assert;

namespace TeamSystem.Controllers.Tests
{
    [TestClass()]
    public class PostControllerTests
    {
        [Fact]
        [TestMethod()]
        public async Task ConnectKategoriToPost_ReturnsOk_WithValidData()
        {
            // Arrange
            var mockKategoriService = new Mock<IKategoriService>();
            var testKategoriPostimDto = new KategoriPostDTO { PostimId = 1, KategoriId = 1 }; 
            var mappedKategoriPost = new KategoriPostim { PostimId = 1, KategoriId = 1 };

            mockKategoriService.Setup(x => x.SaveKategoriPostim(It.IsAny<KategoriPostDTO>()))
                             .ReturnsAsync(mappedKategoriPost);

            var controller = new KategoriController(mockKategoriService.Object);

            // Act
            var result = await controller.ConnectCategoryToPost(testKategoriPostimDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        [TestMethod()]
        public async Task DeletePost_ReturnsOk_WhenPostExists()
        {
            // Arrange
            var mockPostService = new Mock<IPostService>();
            var PostimId = 1;
            mockPostService.Setup(service => service.DeletePostById(PostimId))
                              .ReturnsAsync(new OperationResponse { IsSuccess = true, Message = "POST DELETED" });

            var controller = new PostController(mockPostService.Object);

            // Act
            var result = await controller.DeletePost(PostimId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("POST DELETED", okResult.Value);
        }

        [Fact]
        [TestMethod()]
        public async Task DeletePost_ReturnsNotFound_WhenPostDoesNotExist()
        {
           
            var mockPostService = new Mock<IPostService>();
            var nonExistentPostimId = 999;
            mockPostService.Setup(service => service.DeletePostById(nonExistentPostimId))
                              .ReturnsAsync(new OperationResponse { IsSuccess = false, Message = "POST NOT FOUND" });

            var controller = new PostController(mockPostService.Object);

            
            var result = await controller.DeletePost(nonExistentPostimId);

            
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("POST NOT FOUND", notFoundResult.Value);
        }

    }
}