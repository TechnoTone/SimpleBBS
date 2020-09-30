using System.Collections.Generic;

namespace SimpleBBS
{
    public interface IBBService
    {
        IEnumerable<Post> GetAllPosts();
        Post Post(string userName, string message);
    }
}
