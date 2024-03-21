using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamSystem.Data;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.ServiceLayer;

namespace TeamSystem.Controllers
{
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        public readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(await _postService.GetPosts());
        }


        [HttpGet]
        [Route("CategoryID/{ID}")]
        public async Task<IActionResult> GetPostByCategory(long ID)
        {
            var postKategoei = await _postService.GetPostsBKategoriId(ID);
            if (postKategoei == null)
            {
                return NotFound("POST NOT FOUND");
            }
            else
            {
                return Ok(postKategoei);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddPost(PostsDTO model)
        {
            var post = _postService.SavePost(model);
            if (post == null)
            {
                return BadRequest("ERROR WHILE SAVING POST");
            }
            else
            {
                return Ok(post);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute] long id, PostsDTO model)
        {
            var post = _postService.UpdatePost(id, model);
            if (post == null)
            {
                return NotFound("POST NOT FOUND");
            }
            else
            {
                return Ok("POST UPDATED SUCCESSFULLY");
            }
        }


        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeletePost(long ID)
        {
            var response = await _postService.DeletePostById(ID);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            else
            {
                return NotFound(response.Message);
            }
        }

        [HttpGet("/SearchPostByText")]
        public async Task<IActionResult> SearchPostBy(string text)
        {
            var response = await _postService.SearchPostBy(text);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("POST NOT FOUND");
            }
        }
        [HttpGet("/ListByDateDSC")]
        public async Task<IActionResult> ListByDateDSC(string data)
        {
            var response = await _postService.ListByDate(data);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("POST NOT FOUND");
            }
        }
    }
}