using AdaStore.UI.Shared;
using Microsoft.AspNetCore.Components;

namespace AdaStore.UI.Pages.Buyer
{
    public partial class Products
    {
        [CascadingParameter] public MainLayout Layout { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Layout.SetTitle("Transacciones");
            }
        }
    }
}
