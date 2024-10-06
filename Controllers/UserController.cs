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
        var townExists = await _context.Set<Town>().AnyAsync(m => m.TownId == user.TownId);
        if (!townExists)
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







    [HttpGet("{id}")]
public async Task<IActionResult> GetUserById(int id)
{
    var command = _context.Database.GetDbConnection().CreateCommand();
    command.CommandText = "SELECT * FROM get_user_by_id(@p_user_id)";
    command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_user_id", id));

    await _context.Database.OpenConnectionAsync();
    var reader = await command.ExecuteReaderAsync();

    if (!reader.HasRows)
    {
        return NotFound("Usuario no encontrado.");
    }

    User user = null;
    if (await reader.ReadAsync())
    {
        user = new User
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Phone = reader.GetString(2),
            Address = reader.GetString(3),
            TownId = reader.GetInt32(4)
        };
    }

    await _context.Database.CloseConnectionAsync();

    return Ok(user);
}











[HttpGet]
public async Task<IActionResult> GetAllUsers()
{
    var command = _context.Database.GetDbConnection().CreateCommand();
    command.CommandText = "SELECT * FROM get_all_users()";

    await _context.Database.OpenConnectionAsync();
    var reader = await command.ExecuteReaderAsync();

    var users = new List<User>();
    while (await reader.ReadAsync())
    {
        var user = new User
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Phone = reader.GetString(2),
            Address = reader.GetString(3),
            TownId = reader.GetInt32(4)
        };
        users.Add(user);
    }

    await _context.Database.CloseConnectionAsync();

    return Ok(users);
}









[HttpPut("{id}")]
public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    var command = _context.Database.GetDbConnection().CreateCommand();
    command.CommandText = "CALL update_user(@p_user_id, @p_name, @p_phone, @p_address, @p_town_id)";
    command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_user_id", id));
    command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_name", user.Name));
    command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_phone", user.Phone));
    command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_address", user.Address));
    command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_town_id", user.TownId));

    await _context.Database.OpenConnectionAsync();
    await command.ExecuteNonQueryAsync();
    await _context.Database.CloseConnectionAsync();

    return Ok("Usuario actualizado correctamente.");
}



















[HttpDelete("{id}")]
public async Task<IActionResult> DeleteUser(int id)
{
    var command = _context.Database.GetDbConnection().CreateCommand();
    command.CommandText = "CALL delete_user(@p_user_id)";
    command.Parameters.Add(new Npgsql.NpgsqlParameter("@p_user_id", id));

    await _context.Database.OpenConnectionAsync();
    await command.ExecuteNonQueryAsync();
    await _context.Database.CloseConnectionAsync();

    return Ok("Usuario eliminado correctamente.");
}


    }
}
