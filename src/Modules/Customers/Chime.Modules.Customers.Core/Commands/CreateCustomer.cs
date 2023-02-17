using System.Runtime.CompilerServices;
using Chime.Shared.Abstractions.Commands;


[assembly: InternalsVisibleTo("Chime.Bootstrapper")]

namespace Chime.Modules.Customers.Core.Commands;

internal record CreateCustomer(string Email) : ICommand;  //Changed to Public 