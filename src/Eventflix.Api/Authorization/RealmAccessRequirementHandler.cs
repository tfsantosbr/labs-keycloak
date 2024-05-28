using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Eventflix.Api.Authorization;

public class RealmAccessRequirementHandler : AuthorizationHandler<RealmAccessRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, RealmAccessRequirement requirement)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(requirement);

        var userName = context.User.Identity?.Name;

        if (!context.User.Identity?.IsAuthenticated == true)
        {
            return Task.CompletedTask;
        }

        if (context.User.FindFirst((claim) => claim.Type == "email_verified")?.Value != "true")
        {
            return Task.CompletedTask;
        }

        var realmAccessClaim = context.User.FindFirst((claim) => claim.Type == "realm_access");

        if (realmAccessClaim is null)
        {
            return Task.CompletedTask;
        }

        var realmAccessAsDict = JsonSerializer.Deserialize<Dictionary<string, string[]>>(realmAccessClaim.Value);
        var realmRoles = realmAccessAsDict?["roles"];

        if (realmRoles is null)
        {
            return Task.CompletedTask;
        }

        var hasRoles = realmRoles.Intersect(requirement.Roles).Any();

        if (hasRoles)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}