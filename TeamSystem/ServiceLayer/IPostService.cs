using TeamSystem.Models;
using TeamSystem.Models.DTOs;

namespace TeamSystem.ServiceLayer
{
    public interface IPostService
    {
        public Task<List<Posts>> GetPosts();
        public Task<Posts> SavePost(PostsDTO post);
        public Task<List<Posts>> GetPostsBKategoriId(long kategoriId);
        public Task<Posts> UpdatePost(long PostimId, PostsDTO model);
        public Task<OperationResponse> DeletePostById(long PostimId);
        public Task<List<Posts>> SearchPostBy(string text);
        public Task<List<Posts>> ListByDate(string text);
    } 
}
