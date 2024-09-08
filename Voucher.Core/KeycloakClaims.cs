using System.Security.Claims;
using Voucher.Core.Models;

namespace Voucher.Core;

public static class KeycloakClaims
{
  public static string Id(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
  public static string Email(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
  public static string Name(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.GivenName) ?? string.Empty;
  public static string Surname(this ClaimsPrincipal principal) => principal.FindFirstValue(ClaimTypes.Surname) ?? string.Empty;

  public static User ToUser(this ClaimsPrincipal principal) => new()
  {
    Id = principal.Id(),
    Email = principal.Email(),
    Name = principal.Name(),
    Surname = principal.Surname()
  };
}
