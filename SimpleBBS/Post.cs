using System;

namespace SimpleBBS
{
    public class Post
    {
        public DateTime Timestamp { get; }
        public string UserName { get; }
        public string Message { get; }

        public Post(string userName, string message)
        {
            Timestamp = DateTime.Now;
            UserName = userName;
            Message = message;
        }
    }
}
