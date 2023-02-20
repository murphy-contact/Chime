using Chime.Shared.Abstractions.Commands;

namespace Chime.Modules.Customers.Core.Commands.CreateCustomer;

internal record CreateCustomer(string Email) : ICommand; //Changed to Public 