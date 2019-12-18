using System.Collections.Generic;

namespace Posts.API.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly PostDbContextDbContext _dbContext;

        public PostsRepository(PostDbContextDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PostDto> GetAll() => _dbContext.Posts;

        public void Insert(PostDto post)
        {
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
        }

        public void Update(int postId, PostDto post)
        {
            _dbContext.Posts.Update(post);
            _dbContext.SaveChanges();
        }
    }
}