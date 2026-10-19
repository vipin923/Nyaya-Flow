using Blazored.LocalStorage;
using Google.Protobuf.WellKnownTypes;
using Nyaya_Flow.Models;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace Nyaya_Flow.Services
{
    public class NyayaFlowServices
    {
        private readonly ILocalStorageService _localStorage;
        public NyayaFlowServices(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;

        }

        public async Task<string> GetToken(string CounselEmail)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    var adminData = new { CounselEmail = CounselEmail };
               
                    // 2. Serialize to JSON
                    string json = JsonSerializer.Serialize(adminData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    //var response = await httpClient.PostAsync($"https://ssx17pgh-7260.inc1.devtunnels.ms/api/NyayaFlow/get-paseto-token/", content);
                   var response = await httpClient.PostAsync($"https://985vx5r2-7260.inc1.devtunnels.ms/api/NyayaFlow/get-paseto-token/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(error);
                        return null;

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception($" Error: {ex.Message}");

            }
        }

        public async Task<int> SaveNotice(Takedownnotice takedownnotice)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    var noticetake = new { CaseId = takedownnotice.CaseId,CaseName = takedownnotice.CaseName, ReceivedAtUtc = takedownnotice.ReceivedAtUtc, DeadlineUtc = takedownnotice.DeadlineUtc, IsResolved = takedownnotice.IsResolved, ViolationType =takedownnotice.ViolationType };
                    var gettoken = await _localStorage.GetItemAsync<string>("paseto_token");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", gettoken);
                    //var response = await httpClient.GetAsync($"https://lrlxj14z-7179.inc1.devtunnels.ms/api/NexisPay/
                    // 2. Serialize to JSON
                    string json = JsonSerializer.Serialize(noticetake);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    // var response = await httpClient.PostAsync($"https://ssx17pgh-7260.inc1.devtunnels.ms/api/NyayaFlow/save-takedown/", content);
                    var response = await httpClient.PostAsync($"https://985vx5r2-7260.inc1.devtunnels.ms/api/NyayaFlow/save-takedown/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<int>();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(error);
                        return 0;

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception($" Error: {ex.Message}");

            }
        }
        public async Task<int> StoreVault(EvidenceStore evidence)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    var evidencestore = new { ClientName = evidence.ClientName, EvidenceFile =evidence.EvidenceFile, IsAdmissible = evidence.IsAdmissible, SyntheticProbability = evidence.SyntheticProbability, UploadTimestamp = DateTime.Now };
                    var gettoken = await _localStorage.GetItemAsync<string>("paseto_token");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", gettoken);
                    //var response = await httpClient.GetAsync($"https://lrlxj14z-7179.inc1.devtunnels.ms/api/NexisPay/
                    // 2. Serialize to JSON
                    string json = JsonSerializer.Serialize(evidencestore);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                   // var response = await httpClient.PostAsync($"https://ssx17pgh-7260.inc1.devtunnels.ms/api/NyayaFlow/store-vault/", content);
                     var response = await httpClient.PostAsync($"https://985vx5r2-7260.inc1.devtunnels.ms/api/NyayaFlow/store-vault/", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadFromJsonAsync<int>();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(error);
                        return 0;

                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception($" Error: {ex.Message}");

            }
        }
        public async Task<List<EvidenceStore>> EvidenceLog()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var gettoken = await _localStorage.GetItemAsync<string>("paseto_token");
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", gettoken);
                  //  var response = await httpClient.GetAsync($"https://ssx17pgh-7260.inc1.devtunnels.ms/api/NyayaFlow/evidence-log/");
                     var response = await httpClient.GetAsync($"https://985vx5r2-7260.inc1.devtunnels.ms/api/NyayaFlow/evidence-log/");

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<List<EvidenceStore>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<EvidenceStore>();
                    }
                    else
                    {
                        var rawErrorText = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"API failed with {response.StatusCode}. Raw response: {rawErrorText}");

                        // 2. Return null safely so your Home.razor knows to kick them to the Login page
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($" Error: {ex.Message}");
            }
        }


    }
}


   

