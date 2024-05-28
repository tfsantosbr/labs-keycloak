using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace Eventflix.Api.Authorization;

public class RealmAccessRequirement(params string[] roles) : IAuthorizationRequirement
{
    public IReadOnlyCollection<string> Roles { get; } = roles;
}
