using authors.models;
using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace authors
{
    public class AuthorRepository {

        public static string apiUrl = "https://jsonmock.hackerrank.com/api/article_users/search";
        public Response GetData(int page, int threshold)
        {
            

            var url = $"{apiUrl}?page={page}";

            var restClient = new RestClient(url);
            var restRequest = new RestRequest("", Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");

            try
            {
                var response = restClient.ExecuteAsync<Dictionary<string, string>>(restRequest).Result;
                
                if(response.IsSuccessful)
                {
                    var data = BuildResponse(response.Data);
                    return data;
                }
                else 
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private Response BuildResponse(Dictionary<string, string> responseData)
        {
            string page = String.Empty;
            string per_page = String.Empty;
            string total = String.Empty;
            string total_pages = String.Empty;
            var dataString = String.Empty;
            var data = new List<Author>();

            responseData.TryGetValue("page", out page);
            responseData.TryGetValue("per_page", out per_page);
            responseData.TryGetValue("total", out total);
            responseData.TryGetValue("total_pages", out total_pages);


            responseData.TryGetValue("data", out dataString);

            data = JsonConvert.DeserializeObject<List<Author>>(dataString);

            return new Response
            {
                page = page,
                total = Convert.ToInt32(total),
                total_pages = Convert.ToInt32(total_pages),
                per_page = Convert.ToInt32(per_page),
                data = data
            };
        }
    }
}