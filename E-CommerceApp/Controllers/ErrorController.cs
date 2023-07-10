using E_CommerceApp.Errors;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers;

[Route("errors/{code}")]
public class ErrorController : BaseApiController
{

  [HttpGet]
  public IActionResult Error(int code)
  {
    return new ObjectResult(new ApiResponse(code));
  } 
  
}