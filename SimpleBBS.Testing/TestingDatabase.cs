using System.Collections.Generic;

namespace SimpleBBS.Testing
{
    internal class TestingDatabase : IDatabase
    {
        public List<Post> Posts { get; } = new List<Post>();

        public IEnumerable<Post> GetPosts() => Posts;
        public void AddPost(Post post) => Posts.Add(post);
    }
}
