using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace SimpleBBS.Testing
{
    public class BBServiceTests
    {
        [Test]
        public void WhenDatabaseIsEmptyGetAllPostsIsEmpty()
        {
            var bbs = new BBService(new TestingDatabase());
            bbs.GetAllPosts().Should().BeEmpty();
        }

        [Test]
        public void PostingSavesToTheDatabase()
        {
            var testDB = new TestingDatabase();

            var bbs = new BBService(testDB);
            bbs.Post("a_user", "a_message");

            testDB.Posts.Should().HaveCount(1);
            testDB.Posts[0].UserName.Should().Be("a_user");
            testDB.Posts[0].Message.Should().Be("a_message");
        }

        [Test]
        public void CanGetAllPosts()
        {
            var testDB = new TestingDatabase();
            testDB.Posts.Add(new Post("user1", "message1"));
            testDB.Posts.Add(new Post("user2", "message2"));
            testDB.Posts.Add(new Post("user3", "message3"));
            testDB.Posts.Add(new Post("user4", "message4"));
            testDB.Posts.Add(new Post("user5", "message5"));

            var bbs = new BBService(testDB);
            var result = bbs.GetAllPosts();

            result.Should().HaveCount(5);
            result.Select(p => p.UserName).Should()
                .BeEquivalentTo(new List<string>
                {
                    "user1",
                    "user2",
                    "user3",
                    "user4",
                    "user5"
                });
        }


        [Test]
        public void GetAllPostsReturnsPostsInAscendingChronologicalOrder()
        {
            var testDB = new TestingDatabase();
            var posts = new List<Post>
            {
                new Post("user1", "message1"),
                new Post("user2", "message2"),
                new Post("user3", "message3"),
                new Post("user4", "message4"),
                new Post("user5", "message5")
            };
            posts.Reverse();

            //Just checking that the posts are in fact in descending chronological order
            posts.Select(p => p.Timestamp).Should().BeInDescendingOrder();

            testDB.Posts.AddRange(posts);

            var bbs = new BBService(testDB);
            var result = bbs.GetAllPosts();

            result.Should().HaveCount(5);
            result.Select(p => p.Timestamp).Should().BeInAscendingOrder();
        }
    }
}
