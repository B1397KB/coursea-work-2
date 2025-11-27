using System.Text.Json;
using Microsoft.JSInterop;

namespace EventApp.Client.Services
{
    // Simple session state service that persists a small user object to localStorage
    public class SessionState
    {
        private const string StorageKey = "eventapp_user";
        private readonly IJSRuntime _js;

        public SessionState(IJSRuntime js)
        {
            _js = js;
        }

        public string? CurrentUser { get; private set; }

        public async Task LoginAsync(string username)
        {
            CurrentUser = username;
            await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, JsonSerializer.Serialize(username));
        }

        public async Task LogoutAsync()
        {
            CurrentUser = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", StorageKey);
        }

        public async Task InitializeAsync()
        {
            var value = await _js.InvokeAsync<string?>("localStorage.getItem", StorageKey);
            if (!string.IsNullOrEmpty(value))
            {
                try { CurrentUser = JsonSerializer.Deserialize<string>(value); }
                catch { CurrentUser = value; }
            }
        }
    }
}
