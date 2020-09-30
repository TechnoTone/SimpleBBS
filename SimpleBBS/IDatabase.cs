using System.Collections.Generic;

namespace SimpleBBS
{
    public interface IDatabase
    {
        public IEnumerable<Post> GetPosts();
        public void AddPost(Post post);
    }

}
