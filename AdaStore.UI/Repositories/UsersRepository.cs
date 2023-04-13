using AdaStore.Shared.Data;
using AdaStore.Shared.Models;
using AdaStore.UI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdaStore.UI.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbFactory;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UsersRepository(
            IDbContextFactory<ApplicationDbContext> dbFactory,
            Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider authenticationStateProvider,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.dbFactory = dbFactory;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<RegisterResponse> CreateUser(User userRequest)
        {
            try
            {
                using var context = dbFactory.CreateDbContext();

                var existenUser = await context.Users
                    .FirstOrDefaultAsync(u=>u.UserName.ToUpper() == userRequest.Email.ToUpper());

                if (existenUser != null)
                    return new RegisterResponse { IsSuccess = false, Error = "Ya existe un usuario registrado con el mismo correo electrónico" };

                var user = new User()
                {
                    Name = userRequest.Name,
                    Address = userRequest.Address,
                    Phone = userRequest.Phone,
                    Email = userRequest.Email,
                    UserName = userRequest.Email,
                    Document = userRequest.Document,
                    Profile = userRequest.Profile,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };

                var result = await userManager.CreateAsync(user, userRequest.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, user.Profile.ToString());

                    return new RegisterResponse()
                    {
                        IsSuccess = true
                    };
                }
                else
                {
                    return new RegisterResponse { IsSuccess = false, Error = "Ocurrió un error inesperado" };
                }
            }
            catch (Exception)
            {
                return new RegisterResponse { IsSuccess = false, Error = "Ocurrió un error inesperado" };
            }
        }
    }
}
