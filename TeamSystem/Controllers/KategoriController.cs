using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeamSystem.Data;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.RepositoryLayer;
using TeamSystem.ServiceLayer;

namespace TeamSystem.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")]
    public class KategoriController : Controller
    {
        public readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategories()
        {
            var res = await _kategoriService.GetAllKategories();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategories(KategoriDTO model)
        {

            if (ModelState.IsValid)
            {
                var kategori = _kategoriService.SaveKategori(model);
                return Ok(kategori);
            }
            else
            {
                return BadRequest("ERROR WHILE SAVING KATEGORI");
            }
        }
        [HttpPost("/ConnectCategoryToPost")]
        public async Task<IActionResult> ConnectCategoryToPost(KategoriPostDTO model)
        {
            if (ModelState.IsValid)
            {
                var kategoriPost = _kategoriService.SaveKategoriPostim(model);
                if (kategoriPost != null && kategoriPost.Result.PostimId != -1)
                {
                    return Ok(kategoriPost);
                }
                else
                {
                    return BadRequest("ERROR WHILE CONNECTING POST TO KATEGORI");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
              
            
            
        }
        [HttpPut]
        [Route("{code}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] long code, KategoriDTO model)
        {
            var kategori = _kategoriService.UpdateKategori(code, model);
            if (kategori == null)
            {
                return NotFound("KATEGORI NOT FOUND");
            }
            else
            {
                return Ok("KATEGORI UPDATED SUCCESSFULLY");
            }
        }
    }
}
