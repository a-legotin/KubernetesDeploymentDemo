using System.Collections.Generic;

namespace Posts.API.Repositories
{
    public interface IPostsRepository
    {
        IEnumerable<PostDto> GetAll();
        void Insert(PostDto post);
        void Update(int postId, PostDto post);
    }
}