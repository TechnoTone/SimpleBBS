using System.Collections.Generic;
using System.Linq;

namespace SimpleBBS
{
    public class BBService : IBBService
    {
        private readonly IDatabase db;

        public BBService(IDatabase db) =>
            this.db = db;

        public IEnumerable<Post> GetAllPosts() =>
            db.GetPosts().OrderBy(p => p.Timestamp);

        public Post Post(string userName, string message)
        {
            var post = new Post(userName, message);
            db.AddPost(post);
            return post;
        }
    }
}
