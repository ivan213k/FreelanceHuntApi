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

        /// <summary>
        /// token и apiSecret нужно сгенерировать по адресу 
        /// <see cref="https://freelancehunt.com/my/api"/>
        /// </summary>
        /// <param name="token">Ваш идентификатор или логин</param>
        /// <param name="apiSecret">Ваш секретный ключ</param>
        public FreelancehuntApi(string token, string apiSecret)
        {
            webService = new WebService(token, apiSecret);
        }

        /// <summary>
        /// Информация о пользователе с логином
        /// </summary>
        /// <param name="login">логин</param>
        /// <returns>Информация о пользователе</returns>
        public async Task<Profile> GetAccountInfoAsync(string login = "me")
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/profiles/{login}", "GET", HttpMethod.Get);
            return Profile.FromJson(response);  
        }

        /// <summary>
        /// Возвращает список новых переписок
        /// </summary>
        /// <returns>Список новых переписок</returns>
        public async Task<List<Correspondence>> GetNewCorrespondenceAsync()
        {
            var response = await webService.HttpClientCall("https://api.freelancehunt.com/threads?filter=new", "GET", HttpMethod.Get);

            return Correspondence.ListCorrespondenceFromJson(response); 
        }

        /// <summary>
        /// Возвращает список переписок постранично
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="countCorrespondence">количество переписок на странице (до 50) </param>
        /// <returns>Cписок переписок</returns>
        public async Task<List<Correspondence>> GetCorrespondenceAsync(int page, int countCorrespondence=10)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/threads?page={page}&per_page={countCorrespondence}", "GET", HttpMethod.Get);

           return Correspondence.ListCorrespondenceFromJson(response);   
        }

        /// <summary>
        /// Возвращает список сообщений в переписке
        /// </summary>
        /// <param name="correspondenceId">Идентификатор переписки</param>
        /// <returns>Список сообщений в переписке</returns>
        public async Task<List<Message>> GetMessageListAsync(string correspondenceId)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/threads/{correspondenceId}", "GET", HttpMethod.Get);

            return Message.MessageListFromJson(response);
        }

        /// <summary>
        ///Возвращает cписок открытых проектов (первых 20)
        /// </summary>
        /// <returns>Список открытых проектов</returns>
        public async Task<List<Project>> GetProjectsAsync()
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/projects", "GET", HttpMethod.Get);

            return Project.ProjectsFromJson(response);
        }

        /// <summary>
        /// Возвращает cписок открытых проектов (постранично)
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="countProjects">количество проектов на странице (до 50)</param>
        /// <returns>Список открытых проектов</returns>
        public async Task<List<Project>> GetProjectsAsync(int page,int countProjects=20)
        {
          var response = await webService.HttpClientCall($"https://api.freelancehunt.com/projects?page={page}&per_page={countProjects}", "GET", HttpMethod.Get);

          return Project.ProjectsFromJson(response); 
        }

        /// <summary>
        /// Возвращает cписок открытых проектов (по категориям)
        /// </summary>
        /// <param name="skills">категория</param>
        /// <returns>Список открытых проектов </returns>
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

        /// <summary>
        /// Возвращает cписок открытых проектов (по страницам, по категориям)
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="countProjects">количество проектов на странице (до 50)</param>
        /// <param name="skills">категория</param>
        /// <returns>Список открытых проектов</returns>
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

        /// <summary>
        /// Возвращает cписок открытых проектов(по тегам)
        /// </summary>
        /// <param name="tags">тег</param>
        /// <returns>Список открытых проектов</returns>
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

        /// <summary>
        /// Возвращает cписок открытых проектов (по страницам, по тегам)
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="countProjects">количество проектов на странице (до 50)</param>
        /// <param name="tags">тег</param>
        /// <returns>Список открытых проектов</returns>
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

        /// <summary>
        /// Возвращает детали проекта
        /// </summary>
        /// <param name="projectId">идентификатор проекта</param>
        /// <returns>Детали проекта</returns>
        public async Task<ProjectDetail> GetProjectDetailsAsync(int projectId)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/projects/{projectId}", "GET", HttpMethod.Get);

            return ProjectDetail.ProjectDetailsFromJson(response);
        }

        /// <summary>
        /// Возвращает список ставок на проект
        /// </summary>
        /// <param name="projectId">идентификатор проекта</param>
        /// <returns>Список ставок на проект</returns>
        public async Task<List<Bid>> GetBidsOnProjectAsync(int projectId)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/projects/{projectId}/bids", "GET", HttpMethod.Get);
            return Bid.BidsFromJson(response);
        }

        /// <summary>
        /// Возвращает портфолио фрилансера
        /// </summary>
        /// <param name="login">логин пользователя</param>
        /// <returns>Портфолио фрилансера</returns>
        public async Task<Portfolio> GetPortfolioAsync(string login)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/profiles/{login}?include=portfolio", "GET", HttpMethod.Get);
            return Portfolio.FromJson(response);
    
        }

        /// <summary>
        /// Возвращает сообщение в ленте новостей
        /// </summary>
        /// <returns>Сообщение в ленте новостей</returns>
        public async Task<List<Feed>> GetFeedsAsync()
        {
            var response = await webService.HttpClientCall("https://api.freelancehunt.com/my/feed", "GET", HttpMethod.Get);

            return Feed.FeedsFromJson(response);
        }

        /// <summary>
        /// Возвращает отзывы о пользователе
        /// </summary>
        /// <param name="login">логин пользователя</param>
        /// <returns>Отзывы о пользователе</returns>
        public async Task<List<Review>> GetReviewsAboutUserAsync(string login)
        {
            var response = await webService.HttpClientCall($"https://api.freelancehunt.com/profiles/{login}?include=reviews", "GET", HttpMethod.Get);

            return Review.ReviewsFromJson(response);
        }

    }
}
