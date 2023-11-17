using InLibra.Service.DTOs.Users;
using InLibra.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InLibra.WebApi.Controllers;

public class UsersController:BaseController
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }
    
    
}