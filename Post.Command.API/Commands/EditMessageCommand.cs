using CQRS.Core.Commands;

namespace Post.Command.API.Commands;

public class EditMessageCommand : BaseCommand
{
    public string Message { get; set; }
}