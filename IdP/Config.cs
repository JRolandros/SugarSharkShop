using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(){Name="SugarSharkApi",DisplayName="Sugar Shark Api"}
        };

    public static IEnumerable<Client> Clients =>
        
        new List<Client>
        {
            //Register the backend API
            new Client
            {
                ClientId="SugarSharkshop",
                AllowedGrantTypes=new List<string>{GrantType.ClientCredentials },
                ClientSecrets={ new Secret("sugarsharc".Sha256()) },
                AllowedScopes={ "SugarSharkApi" }, 
                AllowAccessTokensViaBrowser=true,
            },

            //Register the web client 
            new Client
            {
                ClientId="SugarSharkshop-client",
                ClientSecrets={ new Secret("sugarsharc-client".Sha256()) },

                AllowedGrantTypes=new List<string>{GrantType.AuthorizationCode },
                
                AllowedScopes=new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },

                //Redirections
                RedirectUris = { "https://localhost:5002/signin-oidc" }, //after login
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" }, //after logout
            }
        };
}