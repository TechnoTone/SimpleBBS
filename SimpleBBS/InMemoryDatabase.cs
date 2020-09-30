using System.Collections.Generic;

namespace SimpleBBS
{
    public class InMemoryDatabase : IDatabase
    {
        private readonly List<Post> posts = new List<Post>();

        public IEnumerable<Post> GetPosts() => posts;

        public void AddPost(Post post) => posts.Add(post);
    }
}
