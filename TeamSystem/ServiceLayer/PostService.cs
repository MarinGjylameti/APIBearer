
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using TeamSystem.Models;
using TeamSystem.Models.DTOs;
using TeamSystem.RepositoryLayer;

namespace TeamSystem.ServiceLayer
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        public readonly IPostRepository _postRepository;
        public PostService(IMapper mapper,IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }
        public Task<OperationResponse> DeletePostById(long PostimId)
        {
            if (_postRepository.GetPostById(PostimId) == null)
            {
                return null;
            }
            else
            {
                return _postRepository.DeletePostById(PostimId);
            }
        }

        public Task<List<Posts>> GetPosts()
        {
            return _postRepository.GetPosts();
        }

        public Task<List<Posts>> GetPostsBKategoriId(long kategoriID)
        {
            return _postRepository.GetPostByKategoriId(kategoriID);
        }

        public Task<Posts> SavePost(PostsDTO postsDTO)
        {
            var post = _mapper.Map<Posts>(postsDTO);
            return _postRepository.SavePost(post);
        }

        public Task<Posts> UpdatePost(long PostimId, PostsDTO postDTO)
        {
            var post = _mapper.Map<Posts>(postDTO);
            if(_postRepository.GetPostById(PostimId) == null)
            {
                return null;
            }
            else
            {
                return _postRepository.UpdatePost(PostimId, post);
            }
        }

        public Task<List<Posts>> SearchPostBy(string text)
        {
           return  _postRepository.SearchPostBy(text);
        }

        public Task<List<Posts>> ListByDate(string text)
        {
            try
            {
                var data = DateTime.Parse(text);
                return _postRepository.ListByDate(data);
            }
            catch (Exception )
            {
                return null;
            }
            
        }
    }
}
