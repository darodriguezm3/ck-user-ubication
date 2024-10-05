using Microsoft.AspNetCore.Mvc;
using UserRegistrationApi.Data;
using Microsoft.EntityFrameworkCore;
using UserRegistrationApi.Models;


namespace UserRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] User user)
    {
        if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Phone) || string.IsNullOrEmpty(user.Address))
        {
            return BadRequest("Todos los campos son obligatorios.");
        }

        if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

        // Validar si el municipio existe
        var municipalityExists = await _context.Set<Town>().AnyAsync(m => m.TownId == user.TownId);
        if (!municipalityExists)
        {
            return BadRequest("Municipio no encontrado.");
        }

        // Aquí es donde llamamos al stored procedure
        var command = _context.Database.GetDbConnection().CreateCommand();
        command.CommandText = "CALL register_user(@p_name, @p_phone, @p_address, @p_town_id)";
        
        // Agregar parámetros
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_name", user.Name));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_phone", user.Phone));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_address", user.Address));
        command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_town_id", user.TownId));

        // Abrir conexión y ejecutar
        await _context.Database.OpenConnectionAsync();
        await command.ExecuteNonQueryAsync();
        await _context.Database.CloseConnectionAsync();

        return Ok("Usuario registrado correctamente.");
    }

    }
}
