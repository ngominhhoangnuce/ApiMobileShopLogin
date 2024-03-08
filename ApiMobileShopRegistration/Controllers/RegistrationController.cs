using LoginRegistationApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace LoginRegistationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Dangnhap")]
        public IActionResult Dangnhap(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Dangnhap").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE UserName = '" + registration.UserName+"' AND Email = '" + registration.Email + "' AND Password = '" + registration.Password + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return Ok(true);
            }
            else
            {
                return NotFound("InValid USER");

            }
        }
    }
}