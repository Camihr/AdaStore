using AdaStore.Shared.Enums;
using AdaStore.Shared.Models;
using AdaStore.UI.Interfaces;
using AdaStore.UI.Shared;
using AdaStore.UI.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace AdaStore.UI.Pages
{
    public partial class Register
    {
        [Inject] IUsersRepository UsersRepository { get; set; }
        [Inject] NavigationManager Navigation { get; set; }
        [CascadingParameter] public AuthLayout Layout { get; set; }

        private User user = new User();

        private async Task RegisterUser()
        {
            Layout.ToogleLoader(true);

            user.Profile = Profiles.Buyer;

            var response = await UsersRepository.RegisterUser(user);

            if (response.IsSuccess)
            {
                Layout.ShowAlert(new AlertInfo() { IsError = false, Message = $"Te registraste de manera exitosa" });
                Navigation.NavigateTo("/login");
            }
            else
            {
                Layout.ShowAlert(new AlertInfo() { IsError = true, Message = response.Error });
            }

            Layout.ToogleLoader(false);
        }
    }
}
