using Microsoft.AspNetCore.Authorization;

namespace Eventflix.Api.Authorization;

public static class AuthorizationExtensions
{
    public static AuthorizationPolicyBuilder RequireRealmRoles(
        this AuthorizationPolicyBuilder builder,
        params string[] roles
    )
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(roles);

        return builder
            .AddRequirements(new RealmAccessRequirement(roles));
    }
}
