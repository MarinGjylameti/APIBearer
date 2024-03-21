
using TeamSystem.Data;
using TeamSystem.Models;

namespace TeamSystem.RepositoryLayer
{
    public class PostRepository : IPostRepository
    {
        private readonly ApiDbContext _db;
        public PostRepository(ApiDbContext db)
        {
            _db = db;
        }
        public Task<OperationResponse> DeletePostById(long postId)
        {
            try
            {
                _db.Posts.Remove(_db.Posts.FirstOrDefault(x => x.id == postId));
                _db.KategoriPostim.RemoveRange(_db.KategoriPostim.Where(x=>x.PostimId == postId));
                _db.SaveChanges();
                return Task.FromResult(new OperationResponse() { IsSuccess = false, Message = "POST DELETED" });
            }
            catch (Exception e)
            {
                return Task.FromResult(new OperationResponse() {IsSuccess = false,Message = e.Message });
            }
        }

        public Task<Posts> GetPostById(long id)
        {
            var model = _db.Posts.FirstOrDefault(x => x.id == id);
            return Task.FromResult(model);
        }

        public Task<List<Posts>> GetPosts()
        {
            var model = _db.Posts.ToList();
            return Task.FromResult(model);
        }

        public Task<List<Posts>> GetPostByKategoriId(long kategoriId)
        {
            var PostimIds = _db.KategoriPostim.Where(y => y.KategoriId == kategoriId).ToList();
            List<Posts> postList = new List<Posts>();
            foreach (var item in PostimIds)
            {
                postList.Add(_db.Posts.FirstOrDefault(x => x.id == item.KategoriId));
            }
            return Task.FromResult(postList);
        }

        public Task<Posts> SavePost(Posts model)
        {
            try
            {
                _db.Posts.Add(model);
                _db.SaveChanges();
                return Task.FromResult(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<Posts> UpdatePost(long PostimId, Posts model)
        {
            try
            {
                var postim = _db.Posts.FirstOrDefault(x=>x.id == PostimId);
                postim.Title = model.Title;
                postim.Content = model.Content;
                postim.Status = model.Status;
                postim.Date_Krijimi = model.Date_Krijimi;
                postim.Date_Publikimi = model.Date_Publikimi;
                _db.SaveChanges();
                return Task.FromResult(postim);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task <List<Posts>> SearchPostBy(string text)
        {
            try
            {
                var model = _db.Posts.Where(x => x.Title.Contains(text) || x.Content.Contains(text)).ToList();
                return Task.FromResult(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<List<Posts>> ListByDate(DateTime date)
        {
            try
            {
                var model = _db.Posts.Where(x => x.Date_Publikimi.Date == date.Date)
                                      .OrderByDescending(x => x.Date_Publikimi)
                                      .ToList();
                return Task.FromResult(model);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
