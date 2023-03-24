using CQRS.Core.Commands;

namespace Post.Command.API.Commands;

public class DeletePostCommand : BaseCommand
{
    public string Username { get; set; }
}