using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using authors.models;

namespace authors
{
    class Program
    {
        public static string apiUrl = "https://jsonmock.hackerrank.com/api/article_users/search";
        static async Task Main(string[] args)
        {
            var repository = new AuthorRepository();
            var response = repository.GetData(1,3);

            var userName = GetUsernameWithHighestCommentCount(response.data);

            Console.WriteLine("Author with the highest comment count is {0}", userName);

            var authorNamesWithHighSubmittion = GetUsernames(response.data, 50);

            foreach (var authorName in authorNamesWithHighSubmittion)
            {
                Console.WriteLine("{0} is an active author", authorName);
            }

        }

        static List<string> GetUsernames(List<Author> authors, int threshold) {
            return authors.Where(a => a.submission_count >= threshold).Select(a => a.username).ToList();
        }

        static string GetUsernameWithHighestCommentCount(List<Author> authors)
        {
            var orderedAuthors = authors.OrderByDescending(a => a.comment_count).ToArray();
            return orderedAuthors[0].username;
        }

        static List<Author> GetUsernamesSortedByRecordDate(List<Author> authors)
        {
            var orderedAuthors = authors.OrderBy(a => a.created_at).ToList();
            return orderedAuthors;
        }
    }
}
