using CheckApiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using static CheckApiWeb.Models.ModelRoot;
using System.Net.Http.Headers;
using System.Net.Http;

namespace CheckApiWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, HttpClient _httpClient)
        {
            _logger = logger;
            httpClient = _httpClient;
        }

        public async Task<IActionResult> Index(string Store , string orderNo)
        {
            if (Store == null)
            {
                Store = "0";
            }

            if (orderNo == null)
            {
                orderNo = "0";
            }
            if (Store.Length >=4 && orderNo.Length>=13)
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"https://apipartner.winmart.vn/api/v1/transaction/order?PartnerCode=WCM&PosNo={Store}&OrderNo={orderNo}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "UE9TOjk4NzY1NDMyMTA=");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    if( responseBody!="" && responseBody!= null)
                    {
                        var jsonResult = JsonConvert.DeserializeObject<RootObject>(responseBody);
                        var data = jsonResult.Data;
                        return View(new List<Data> { data });
                    }
                }
                return View();
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(string store, string orderno)
        {
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://apipartner.winmart.vn/api/v1/transaction/order?PartnerCode=WCM&PosNo=6733&OrderNo=1689129786585");
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", "UE9TOjk4NzY1NDMyMTA=");
                HttpResponseMessage response = await httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var jsonResult = JsonConvert.DeserializeObject<RootObject>(responseBody);
                    var data = jsonResult.Data;
                    return View(new List<Data> { data });
                }
                return View();
            }

        }
    }
}