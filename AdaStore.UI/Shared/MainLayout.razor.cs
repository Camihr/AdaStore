using AdaStore.Shared.Models;
using AdaStore.UI.UI;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using AdaStore.Shared.Enums;

namespace AdaStore.UI.Shared
{
    public partial class MainLayout
    {
        [Inject] protected NavigationManager Navigation { get; set; }
        [CascadingParameter] protected Task<AuthenticationState> AuthStat { get; set; }
        public User CurrentUser { get; set; }
        public bool IsMenuClosed { get; set; }

        private string _title;
        private bool _showLoading;
        private bool _showAlert;
        private AlertInfo _alertInfo;

        protected async override Task OnInitializedAsync()
        {
            var user = (await AuthStat).User;

            if (user != null && user.Identity != null && user.Identity.IsAuthenticated)
            {
                CurrentUser = new User();

                if (Enum.TryParse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value, out Profiles role))
                {
                    if (role != Profiles.Admin && role != Profiles.Buyer)
                    {
                        Navigation.NavigateTo("/login");
                        return;
                    }

                    CurrentUser.Profile = role;
                }

                CurrentUser.Id = Convert.ToInt32(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                CurrentUser.Email = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                CurrentUser.Name = user.Claims.FirstOrDefault(c => c.Type == "DisplayName").Value;

                var uri = Navigation.Uri;
                var absoluteUri = Navigation.ToAbsoluteUri(uri);

                if (absoluteUri.AbsolutePath == "/")
                {
                    var route = CurrentUser.Profile == Profiles.Admin ? "/transactions" : "/products";
                    Navigation.NavigateTo(route);
                }
            }
            else
            {
                Navigation.NavigateTo("/register");
            }
        }

        public void SetTitle(string title)
        {
            _title = title;
            StateHasChanged();
        }

        public void ToogleLoader(bool showLoading)
        {
            _showLoading = showLoading;
            StateHasChanged();
        }

        public void ToogleMenu(bool isMinuClosed)
        {
            IsMenuClosed = isMinuClosed;
            StateHasChanged();
        }

        public void ShowAlert(string message, bool isError)
        {
            _alertInfo = new AlertInfo()
            {
                Message = message,
                IsError = isError
            };

            _showAlert = true;
            StateHasChanged();
        }
    }
}
