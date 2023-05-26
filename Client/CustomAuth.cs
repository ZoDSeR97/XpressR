using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.JSInterop;
using XpressR.Shared;
using System.Text.Json;

namespace XpressR.Client
{
    public class CustomAuth : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        public CustomAuth(IJSRuntime jsRuntime) 
        { 
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = null;
            try
            {
                token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "User");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                token = null;
            }
            Console.WriteLine($"{nameof(token)}: {token}");
            var identity = new ClaimsIdentity();
            if (token != null && int.Parse(token) > 0)
            {
                identity = new ClaimsIdentity(token.ToString());
            }
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }

        public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
