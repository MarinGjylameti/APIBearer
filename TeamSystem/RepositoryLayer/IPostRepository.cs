using TeamSystem.Models;

namespace TeamSystem.RepositoryLayer
{
    public interface IPostRepository
    {
        public Task<List<Posts>> GetPosts();
        public Task<Posts> GetPostById(long id);
        public Task<Posts> SavePost(Posts post);
        public Task<List<Posts>> GetPostByKategoriId(long kategoriId);
        public Task<Posts> UpdatePost(long PostimId, Posts post);
        public Task<OperationResponse> DeletePostById(long PostimId);
        public Task<List<Posts>> SearchPostBy(string text);
        public Task<List<Posts>> ListByDate(DateTime date);
    } 
}
