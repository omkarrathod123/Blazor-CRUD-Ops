using BlazorCRUDOps.Shared;
using System.Net.Http.Json;

namespace BlazorCRUDOps.Client.Pages
{
    public partial class ProductPage
    {
        List<Product> productList = new List<Product>();
        private bool _initialized;
        protected override async Task OnInitializedAsync()
        {
            if (_initialized) return;
            _initialized = true;
            productList = await Http.GetFromJsonAsync<List<Product>>("Products");
        }
        private async Task HandleEdit(int id)
        {
            string requestUri = "product-edit/" + id.ToString();
            navigationManager.NavigateTo(requestUri);
        }
    }
}
