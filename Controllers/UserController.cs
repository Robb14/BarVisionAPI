// [ApiController]
// [Route("api/users")]
// public class UserController : ControllerBase
// {
//     private readonly ApplicationDbContext _context;
//     private readonly UserManager<User> _userManager;

//     public UserController(ApplicationDbContext context, UserManager<User> userManager)
//     {
//         _context = context;
//         _userManager = userManager;
//     }

//     [HttpPost("register")]
//     public async Task<IActionResult> Register(RegisterModel model)
//     {
//         [HttpPost("register")]
//         public IActionResult Register(RegisterModel model)
//         {
//             // Verificar si el modelo de registro es válido
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             // Verificar si ya existe un usuario con el mismo nombre de usuario o correo electrónico
//             if (_userRepository.ExistsUser(model.Username, model.Email))
//             {
//                 return Conflict("El nombre de usuario o correo electrónico ya están en uso.");
//             }

//             // Crear una instancia del modelo de usuario
//             var user = new User
//             {
//                 Username = model.Username,
//                 Password = model.Password,
//                 Email = model.Email,
//                 Role = User.NormalUserRole
//             };

//             // Guardar el nuevo usuario en la base de datos
//             _userRepository.AddUser(user);

//             // Devolver una respuesta exitosa
//             return Ok("Usuario registrado exitosamente.");
//         }

//     }

//     [HttpPost("login")]
//     public async Task<IActionResult> Login(LoginModel model)
//     {
//         // Lógica para iniciar sesión
//         // ...
//     }

//     [HttpGet("search")]
//     public IActionResult Search(string query)
//     {
//         // Lógica para buscar partidos, localización o bar
//         // ...
//     }

//     [HttpPost("bars/{barId}/reserve")]
//     [Authorize(Roles = User.UserRole)]
//     public IActionResult Reserve(int barId, Reservation model)
//     {
//         // Lógica para realizar una reserva en un bar específico
//         // ...
//     }

//     // Otros métodos para gestionar la información del usuario, como obtener datos del usuario, actualizar perfil, etc.
//     // ...
// }
