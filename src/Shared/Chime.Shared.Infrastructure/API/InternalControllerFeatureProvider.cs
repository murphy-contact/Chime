using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Chime.Shared.Infrastructure.API;

internal class InternalControllerFeatureProvider : ControllerFeatureProvider
{
    private const string ControllerTypeNameSuffix = "Controller";

    /// <summary>
    ///     Determines if a given <paramref name="typeInfo" /> is a controller.
    /// </summary>
    /// <param name="typeInfo">The <see cref="TypeInfo" /> candidate.</param>
    /// <returns><see langword="true" /> if the type is a controller; otherwise <see langword="false" />.</returns>
    // protected virtual bool IsController(TypeInfo typeInfo)
    protected override bool IsController(TypeInfo typeInfo)
    {
        if (!typeInfo.IsClass) return false;

        if (typeInfo.IsAbstract) return false;

        // We only consider public top-level classes as controllers. IsPublic returns false for nested
        // classes, regardless of visibility modifiers
        if (!typeInfo.IsPublic) return false;

        if (typeInfo.ContainsGenericParameters) return false;

        if (typeInfo.IsDefined(typeof(NonControllerAttribute))) return false;

        if (!typeInfo.Name.EndsWith(ControllerTypeNameSuffix, StringComparison.OrdinalIgnoreCase) &&
            !typeInfo.IsDefined(typeof(ControllerAttribute)))
            return false;

        return true;
    }
}