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

namespace ProSolutionFormsAPI.Services
{
    public class SystemUserTokenService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public GraphAPITokenModel? GraphAPITokenModel { get; set; }

        public List<SystemEmailModel>? SystemEmails { get; }

        private SystemEmailModel? _systemEmail;
        private List<SystemEmailModel>? _systemEmails;

        public SystemUserTokenService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<SystemUserTokenModel?> Get(string codeToken)
        {
            GraphAPITokenModel graphAPITokenModel = await GetToken(codeToken);
            SystemUserTokenModel systemUserToken = new SystemUserTokenModel()
            {
                BearerToken = graphAPITokenModel.AccessToken
            };

            return systemUserToken;
        }

        public async Task<GraphAPITokenModel> GetToken(string codeToken)
        {
            var graphAPI = _configuration.GetSection("GraphAPI");
            var login_endpoint = graphAPI["login_endpoint"];
            var tenant = graphAPI["tenant"];
            var client_id = graphAPI["client_id"];
            var client_secret = graphAPI["client_secret"];
            var redirect_uri = graphAPI["redirect_uri"];
            var grant_type = "authorization_code";
            var scope = $"api://{client_id}/access_as_user";
            var code = codeToken;

            string? tokenEndPoint;
            tokenEndPoint = $"{login_endpoint}/{tenant}/oauth2/v2.0/token";

            GraphAPITokenAuthorisationModel? GraphAPITokenAuthorisation = new GraphAPITokenAuthorisationModel()
            {
                ClientID = client_id,
                ClientSecret = client_secret,
                RedirectURI = redirect_uri,
                GrantType = grant_type,
                Scope = scope,
                Code = code
            };

            GraphAPITokenModel? graphAPIToken = new GraphAPITokenModel();

            IList<KeyValuePair<string, string>> formParams = new List<KeyValuePair<string, string>>();

            if (GraphAPITokenAuthorisation != null)
            {
                foreach (var prop in GraphAPITokenAuthorisation.GetType().GetProperties())
                {

                    formParams.Add(new KeyValuePair<string, string>(prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name, prop.GetValue(GraphAPITokenAuthorisation)?.ToString() ?? ""));
                }
            }

            var formParamsEncoded = new FormUrlEncodedContent(formParams.ToArray());

            try
            {
                using (var httpClient = new HttpClient())
                {
                    //Is not JSON but x-www-form-urlencoded so needs PostAsync
                    HttpResponseMessage formResponse = await httpClient.PostAsync(tokenEndPoint, formParamsEncoded);
                    var responseContent = await formResponse.Content.ReadAsStringAsync();
                    Console.WriteLine("GraphAPIAuthorisation: " + JsonSerializer.Serialize(GraphAPITokenAuthorisation));
                    if (formResponse.IsSuccessStatusCode)
                    {
                        graphAPIToken = JsonSerializer.Deserialize<GraphAPITokenModel>(responseContent);
                    }
                    else
                    {
                        throw new Exception($"Error getting token: {responseContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting token: {ex.Message}");
            }

            return graphAPIToken ?? new();
        }
    }
}
