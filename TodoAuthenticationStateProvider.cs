using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace TestBlazorAPP
{
    public class TodoAuthenticationStateProvider : AuthenticationStateProvider
    {
        // Dieser User wird verwendet wenn niemand angemeldet ist
        private ClaimsPrincipal _anonym = new ClaimsPrincipal(new ClaimsIdentity());
        private ClaimsPrincipal _user = null;

        // Methode prüft den aktuellen Anmeldezustand
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (this._user == null) // wenn kein User angemeldet ist
            {
                return Task.FromResult(new AuthenticationState(this._anonym));
            }
            else // ansonsten
            {
                return Task.FromResult(new AuthenticationState(this._user));
            }                
        }
    }
}
