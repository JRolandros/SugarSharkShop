using Duende.IdentityServer.Models;

namespace IdP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(){Name="SugarSharkApi",DisplayName="Sugar Shark Api"}
        };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId="SugarSharkshop",
                AllowedGrantTypes=new List<string>{GrantType.ClientCredentials },
                ClientSecrets={ new Secret("sugarsharc".Sha256()) },
                AllowedScopes={ "SugarSharkApi" },
                AllowAccessTokensViaBrowser=true,
            }
        };
}