using FreelanceHuntApi.Enums;
using FreelanceHuntApi.Model;
using FreelanceHuntApi.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FreelanceHuntAPI
{
    public class FreelancehuntApi
    {
        WebService webService;

        public FreelancehuntApi(string token, string apiSecret)
        {
            webService = new WebService(token, apiSecret);
        }

        public async Task<Profile> GetAccountInfoAsync(string login = "me")
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/profiles/{login}", "GET", HttpMethod.Get);
            return Profile.FromJson(response);  
        }

        public async Task<List<Correspondence>> GetNewCorrespondenceAsync()
        {
            var response = await webService.HttpClientCall("https://api.freelancehunt.com/threads?filter=new", "GET", HttpMethod.Get);

            return Correspondence.ListCorrespondenceFromJson(response); 
        }

        public async Task<List<Correspondence>> GetAllCorrespondenceAsync()
        {
            var response = await webService.HttpClientCall("https://api.freelancehunt.com/threads", "GET", HttpMethod.Get);

           return Correspondence.ListCorrespondenceFromJson(response);   
        }

        public async Task<List<Message>> GetMessageListAsync(string correspondenceId)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/threads/{correspondenceId}", "GET", HttpMethod.Get);

            return Message.MessageListFromJson(response);
        } 

        public async Task<List<Project>> GetProjectsAsync()
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/projects", "GET", HttpMethod.Get);

            return Project.ProjectsFromJson(response);
        }

        public async Task<List<Project>> GetProjectsAsync(int page,int countProjects=20)
        {
          var response = await webService.HttpClientCall($"https://api.freelancehunt.com/projects?page={page}&per_page={countProjects}", "GET", HttpMethod.Get);

          return Project.ProjectsFromJson(response); 
        }

        public async Task<List<Project>> GetProjectsAsync(params Skills[] skills)
        {
            var url = "https://api.freelancehunt.com/projects?skills=";

            foreach (var skill in skills)
            {
                url += $"{(int)skill},";
            }
            var response = await webService.HttpClientCall(url, "GET", HttpMethod.Get);

            return Project.ProjectsFromJson(response);
        }

        public async Task<List<Project>> GetProjectsAsync(int page, int countProjects =20, params Skills[] skills)
        {
            var url = $"https://api.freelancehunt.com/projects?page={page}&per_page={countProjects}&skills=";

            foreach (var skill in skills)
            {
                url += $"{(int)skill},";
            }
            var response = await webService.HttpClientCall(url, "GET", HttpMethod.Get);

            return Project.ProjectsFromJson(response);
        }

        public async Task<List<Project>> GetProjectsAsync(params string[] tags)
        {
            var url = "https://api.freelancehunt.com/projects?tags=";

            foreach (var tag in tags)
            {
                url += $"{tag},";
            }
            var response = await webService.HttpClientCall(url, "GET", HttpMethod.Get);

            return Project.ProjectsFromJson(response);
        }

        public async Task<List<Project>> GetProjectsAsync(int page, int countProjects = 20, params string[] tags)
        {
            var url = $"https://api.freelancehunt.com/projects?page={page}&per_page={countProjects}&tags=";

            foreach (var tag in tags)
            {
                url += $"{tag},";
            }
            var response = await webService.HttpClientCall(url, "GET", HttpMethod.Get);

            return Project.ProjectsFromJson(response);
        }

        public async Task<ProjectDetail> GetProjectDetailsAsync(int projectId)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/projects/{projectId}", "GET", HttpMethod.Get);

            return ProjectDetail.ProjectDetailsFromJson(response);
        }

        public async Task<List<Bid>> GetBidsOnProjectAsync(int projectId)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/projects/{projectId}/bids", "GET", HttpMethod.Get);
            return Bid.BidsFromJson(response);
        }

        public async Task<Portfolio> GetPortfolioAsync(string login)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/profiles/{login}?include=portfolio", "GET", HttpMethod.Get);
            return Portfolio.FromJson(response);
    
        }

        public async Task<List<Feed>> GetFeedsAsync()
        {
            var response = await webService.HttpClientCall("https://api.freelancehunt.com/my/feed", "GET", HttpMethod.Get);

            return Feed.FeedsFromJson(response);
        }

        public async Task<List<Review>> GetReviewsAboutUserAsync(string login)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/profiles/{login}?include=reviews", "GET", HttpMethod.Get);

            return Review.ReviewsFromJson(response);
        }

    }
}
