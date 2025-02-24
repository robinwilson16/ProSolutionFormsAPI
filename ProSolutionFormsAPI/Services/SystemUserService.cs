using ProSolutionFormsAPI.Data;
using ProSolutionFormsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using System.Net.Mail;
using System.Net;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProSolutionFormsAPI.Services
{
    public class SystemUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public SystemUserService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<SystemUserModel?> Get(string accessToken)
        {
            SystemUserModel SystemUser = new SystemUserModel();

            SystemUser = await GetUserDetails(accessToken);

            return SystemUser;
        }

        public async Task<SystemUserModel> GetUserDetails(string? accessToken)
        {
            GraphAPIUserModel? GraphAPIUser = new GraphAPIUserModel();
            GraphAPIUserGroupsModel? GraphAPIUserGroups = new GraphAPIUserGroupsModel();

            var graphAPI = _configuration.GetSection("GraphAPI");
            var user_endpoint = graphAPI["user_endpoint"];
            var group_endpoint = graphAPI["group_endpoint"];
            var photo_endpoint = graphAPI["photo_endpoint"];
            var thumbnail_endpoint = graphAPI["thumbnail_endpoint"];

            string? userEndPoint;
            userEndPoint = $"{user_endpoint}";
            string? groupEndPoint;
            groupEndPoint = $"{group_endpoint}";
            string? photoEndPoint;
            photoEndPoint = $"{photo_endpoint}";
            string? thumbnailEndPoint;
            thumbnailEndPoint = $"{thumbnail_endpoint}";

            bool? isError = false;

            SystemUserModel? SystemUser = new SystemUserModel();
            SystemUserGroupModel UserGroup = new SystemUserGroupModel();
            IList<SystemUserGroupModel> UserGroups = new List<SystemUserGroupModel>();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                    //HttpResponseMessage formResponse = await httpClient.PostAsJsonAsync(userEndPoint, GraphAPIUser);
                    //var responseContent = await formResponse.Content.ReadAsStringAsync();

                    //Get User
                    try
                    {
                        GraphAPIUser = await httpClient.GetFromJsonAsync<GraphAPIUserModel>(userEndPoint);
                    }
                    catch (HttpRequestException ex)
                    {
                        isError = true;
                        throw new Exception($"Error retrieving user: {ex.Message}");
                    }

                    if (isError != true)
                    {
                        Console.WriteLine($"User {GraphAPIUser.Name} Retrieved");

                        SystemUser = new SystemUserModel()
                        {
                            UserID = GraphAPIUser.Sub,
                            Email = GraphAPIUser.Email,
                            Forename = GraphAPIUser.GivenName,
                            Surname = GraphAPIUser.FamilyName,
                            Name = GraphAPIUser.Name,
                            AccessToken = accessToken
                        };


                    }
                    else
                    {
                        throw new Exception($"Error retrieving user");
                    }


                    //Get User Groups
                    if (isError != true)
                    {
                        try
                        {
                            GraphAPIUserGroups = await httpClient.GetFromJsonAsync<GraphAPIUserGroupsModel>(groupEndPoint);
                        }
                        catch (HttpRequestException ex)
                        {
                            isError = true;
                            throw new Exception($"Error retrieving user groups: {ex.Message}");
                        }

                        if (isError != true)
                        {
                            Console.WriteLine($"{GraphAPIUserGroups?.Value?.Count} Groups Retrieved");

                            if (GraphAPIUserGroups != null)
                            {
                                foreach (var group in GraphAPIUserGroups.Value)
                                {
                                    UserGroup = new SystemUserGroupModel()
                                    {
                                        GroupID = group.ID,
                                        GroupName = group.DisplayName
                                    };
                                    UserGroups.Add(UserGroup);
                                }

                                SystemUser.Groups = UserGroups;
                            }
                        }
                        else
                        {
                            throw new Exception($"Error retrieving user");
                        }
                    }

                    //Get User Photo
                    if (isError != true)
                    {
                        try
                        {
                            var photoResponse = await httpClient.GetAsync(photoEndPoint);
                            var photoStream = await photoResponse.Content.ReadAsByteArrayAsync();
                            SystemUser.Photo = photoStream;
                        }
                        catch (HttpRequestException ex)
                        {
                            isError = true;
                            throw new Exception($"Error retrieving user photo: {ex.Message}");
                        }
                    }

                    //Get User Photo Thumbnail
                    if (isError != true)
                    {
                        try
                        {
                            var thumbnailResponse = await httpClient.GetAsync(thumbnailEndPoint);
                            var thumbnailStream = await thumbnailResponse.Content.ReadAsByteArrayAsync();
                            SystemUser.PhotoThumbnail = thumbnailStream;
                        }
                        catch (HttpRequestException ex)
                        {
                            isError = true;
                            throw new Exception($"Error retrieving user photo: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving user: {ex.Message}");
            }

            return SystemUser;
        }
    }
}
