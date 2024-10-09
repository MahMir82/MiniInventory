using Microsoft.AspNetCore.Mvc;

namespace MiniInventory.API.Controllers;
//[Route("api/[controller]")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]

public class BaseController : ControllerBase
{
}