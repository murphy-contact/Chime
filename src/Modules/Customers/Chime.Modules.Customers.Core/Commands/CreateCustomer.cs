using Chime.Shared.Abstractions.Commands;

namespace Chime.Modules.Customers.Core.Commands;

internal record CreateCustomer(string Email) : ICommand;