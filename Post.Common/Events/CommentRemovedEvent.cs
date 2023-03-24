using CQRS.Core.Events;

namespace Post.Common.Events;

public class CommentRemovedEvent : BaseEvent
{
    public Guid CommentId { get; set; } 
    public CommentRemovedEvent(string type) : base(nameof(CommentRemovedEvent))
    {
    }
}