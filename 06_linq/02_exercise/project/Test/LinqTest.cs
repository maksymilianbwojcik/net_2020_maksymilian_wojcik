using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Utils;
using Xunit;

namespace Test
{
    public class LinqTest
    {
        public LinqTest()
        {
            _numbers = new[] {7, 3, 4, 1, 3, 2, 3, 5, 4, 4, 5, 5, 6, 7};
            _words = new[] {"house", "plane", "snow", "dog", "cat", "pizza", "dotnet", "space"};

            _users = new[]
            {
                new User {Name = "John", Age = 12},
                new User {Name = "Tom", Age = 60},
                new User {Name = "Tim", Age = 22},
                new User {Name = "Stephan", Age = 100},
                new User {Name = "Peter"},
                new User {Age = 112},
                new User()
            };

            _posts = new[]
            {
                new Post(_users[0].Id) {Title = "invalid"},
                new Post(_users[0].Id) {Title = "Valid"},
                new Post(_users[1].Id) {Title = "invalid"},
                new Post(_users[2].Id) {Title = "invalid"},
                new Post(_users[3].Id) {Title = "Valid"},
                new Post(_users[3].Id) {Title = ""},
                new Post(_users[3].Id)
            };

            _comments = new[]
            {
                new Comment(_posts[0].Id) {Title = "Well done!", Text = "This it the best!"},
                new Comment(_posts[0].Id) {Title = "Mediocre...", Text = "You should try harder..."},
                new Comment(_posts[5].Id) {Title = "Hmm?", Text = "Missing title?"},
                new Comment(_posts[6].Id) {Title = "Why no title?", Text = "Isn't this invalid?"},
                new Comment(_posts[4].Id) {Title = "This is very long title.", Text = "This is short."}
            };
        }

        private readonly int[] _numbers;
        private readonly string[] _words;
        private readonly User[] _users;
        private readonly Post[] _posts;
        private readonly Comment[] _comments;

        [Fact]
        public void SelectAdultUsers()
        {
            // var result = /*TODO*/;
            var result = from user in _users where user.Age>=18 select user;

            Assert.Equal(new[] {_users[1], _users[2], _users[3], _users[5]}, result);
        }

        [Fact]
        public void SelectAverageUserNameLengthForUsersWhoHaveName()
        {
            // var result = /*TODO*/;
            // var result = (from user in _users where user != null && user.Name != null select user!.Name.Length).Average();
            var result = _users.Where(x => x != null && x.Name != null).Select(user => user.Name != null ? user.Name.Length : 0).Average();
            
            Assert.Equal(4.4, result, 2);
        }

        [Fact]
        public void SelectCommentsWhereTitleIsLongerThanText()
        {
            // var result = /*TODO*/;
            var result = from comm in _comments
                where comm.Title?.Length > comm.Text?.Length select comm;

            Assert.Equal(new[] {_comments[4]}, result);
        }

        [Fact]
        public void SelectOnlyUserNameForAdultUsers()
        {
            // var result = /*TODO*/;
            var result = from user in _users where user.Age >= 18 select user.Name;

            Assert.Equal(new[] {_users[1].Name, _users[2].Name, _users[3].Name, _users[5].Name}, result);
        }

        [Fact]
        public void SelectSumOfEvenNumbersAndSumOfOddNumbers()
        {
            // var result = /*TODO*/;
            var result = new List<(bool even, int sum)>{
                (even: false, sum: (from number in _numbers where number % 2 != 0 select number).Sum()),
                (even: true, sum: (from number in _numbers where number % 2 == 0 select number).Sum())
            };

            var resultArray = result.ToArray();
            Assert.Equal(2, resultArray.Length);
            Assert.Equal(resultArray[0], (even: false, sum: 39));
            Assert.Equal(resultArray[1], (even: true, sum: 20));
        }

        [Fact]
        public void SelectTotalNumberOfCharactersInAllWords()
        {
            // var result = /*TODO*/;
            var result = (from word in _words select word.Length).Sum();

            Assert.Equal(36, result);
        }

        [Fact]
        public void SelectUserCommentsForPostsWithNoTitle()
        {
            // var result = /*TODO*/;
            var result =
//                 from comm in _comments
//                 join post in _posts on comm.PostId equals post.Id
//                 join user in _users on comm.
                from post in _posts
                join comm in _comments on post.Id equals comm.PostId
                join user in _users on post.UserId equals user.Id
                where post.Title.IsNullOrEmpty()
                select (user, comm);

            var resultArray = result.ToArray();
            Assert.Equal(2, resultArray.Length);
            Assert.Equal(resultArray[0], (_users[3], _comments[2]));
            Assert.Equal(resultArray[1], (_users[3], _comments[3]));
        }

        [Fact]
        public void SelectUsersWherePostTitleStartsWithUppercaseLetter()
        {
            // var result = /*TODO*/;
            var result = new List<User>(from user in _users join post in _posts on user.Id equals post.UserId where post?.Title != null && post.Title.Length > 0 && Char.IsUpper(post.Title[0]) select user);
            
            Assert.Equal(new[] {_users[0], _users[3]}, result);
        }

        [Fact]
        public void SelectUsersWithNameLongerThanThreeCharacters()
        {
            // var result = /*TODO*/;
            var result = from user in _users where user.Name != null && user.Name.Length > 3 select user;

            Assert.Equal(new[] {_users[0], _users[3], _users[4]}, result);
        }

        [Fact]
        public void SelectUserWithNameTom()
        {
            // var result = /*TODO*/;
            var result = from user in _users where user != null && user.Name == "Tom" select user;

            Assert.Equal(new[] {_users[1]}, result);
        }

        [Fact]
        public void SelectThreeLongestWordsInDescendingOrder()
        {
            // var result = /*TODO*/;
            var result = from x in (from word in _words orderby word.Length descending select word).Take(3)
                orderby x
                select x;
            
            Assert.Equal(new []{"dotnet", "house", "plane"}, result);
        }
    }
}