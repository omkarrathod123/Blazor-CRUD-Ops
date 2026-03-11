using BlazorCRUDOps.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCRUDOps.Client.Pages
{
    public partial class ProductEdit
    {
        [Parameter]
        public int id { get; set; }
        private bool ready;
        private string? error;
        private Product product;
        private bool _initialized;
        protected override async Task OnInitializedAsync()
        {
            if (_initialized) return;
            _initialized = true;
            if (id == 0)
            {
                product = new Product();
            }
            else
            {
                product = await Http.GetFromJsonAsync<Product>("Products/" + id);
            }
            ready = true;
        }
        private async Task HandleValidSubmit()
        {
            HttpResponseMessage responseMessage;
            if (product.ProductId == 0)
            {
                responseMessage = await Http.PostAsJsonAsync("Products", product);
            }
            else
            {
                string requestUri = "Products/" + product.ProductId;
                responseMessage = await Http.PutAsJsonAsync(requestUri, product);
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("productpage");
            }
            else
            {
                error = responseMessage.ReasonPhrase;
            }
        }
        private async Task HandleRest()
        {
            NavigationManager.NavigateTo("productpage");
        }
        private async Task DeleteProduct()
        {
            string requestUri = "Products/" + product.ProductId;
            var response = await Http.DeleteAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("productpage");
            }
            else
            {
                error = response.ReasonPhrase;
            }
        }
    }
}
