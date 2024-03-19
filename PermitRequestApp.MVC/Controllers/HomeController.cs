using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using PermitRequestApp.Application.Features.ADUsers.GetAllUsers;
using PermitRequestApp.MVC.DTOs;
using PermitRequestApp.MVC.Models;
using System.Diagnostics;

namespace PermitRequestApp.MVC.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient client = new();
        HttpResponseMessage message =  await client.GetAsync("https://localhost:7206/api/AddUsers/GetAll");

        if (message.IsSuccessStatusCode)
        {
			Result<List<GetAllUserQueryResponse>>? response = await message.Content.ReadFromJsonAsync<Result<List<GetAllUserQueryResponse>>>();

            if(response is not null)
            {
                return View(response.Value);
            }
        }

        return View(new List<GetAllUserQueryResponse>());
    }

    [HttpPost]
    public async Task<IActionResult> Save(PermitRequestDto request)
    {
        HttpClient client = new();
        HttpResponseMessage message =  await client.PostAsJsonAsync("https://localhost:7206/api/LeaveRequests/Create", request);

        if(message.IsSuccessStatusCode)
        {
            Result<string>? response = await message.Content.ReadFromJsonAsync<Result<string>>(); 
            if(response is not null)
            {
                TempData["message"] = response.Value;
            }
        }

        return RedirectToAction("Index");
    }
   
}
