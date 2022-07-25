namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

[Controller]
public abstract class BaseController : ControllerBase
{
    // returns the current authenticated account (null if not logged in)
    public Cliente Cliente => (Cliente)HttpContext.Items["Cliente"];
}