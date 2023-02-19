using Chime.Shared.Abstractions.Commands;

namespace Chime.Modules.Customers.Core.Commands.GetCustomer;

internal record CreateCustomer(string Email) : ICommand; //Changed to Public 