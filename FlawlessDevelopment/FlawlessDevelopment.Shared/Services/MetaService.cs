using FlawlessDevelopment.Shared.Models;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FlawlessDevelopment.Shared.Services
{
    public class MetaService
    {
        private readonly IJSRuntime _js;

        public MetaService(IJSRuntime js) => _js = js;

        public async Task SetMetaTags(MetaTags tags)
        {
            await _js.InvokeVoidAsync("metaService.setMetaTags", tags);
        }
    }
}
