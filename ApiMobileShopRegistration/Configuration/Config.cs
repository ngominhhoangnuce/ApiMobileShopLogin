 using IdentityServer4.Models;

namespace LoginRegistationApp.Configuration
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> GetApiResources() =>
            new List<ApiResource>
            {
            new ApiResource("api", "My API")
            };
        public static IEnumerable<ApiScope> GetApiScopes() =>
    new List<ApiScope>
    {
        new ApiScope("api", "My API")
    };

        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "myclient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("mysecret".Sha256())
                    },
                    AllowedScopes = { "api", "openid", "profile", "email" }
                },
            };
        }
    }
}
