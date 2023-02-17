using Chime.Shared.Abstractions.Commands;

namespace Chime.Modules.Customers.Core.Commands;

public record CreateCustomer(string Email) : ICommand;  //Changed to Public 