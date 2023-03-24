using CQRS.Core.Events;

namespace Post.Common.Events;

public class PostRemovedEvent : BaseEvent
{
    public PostRemovedEvent(string type) : base(nameof(PostRemovedEvent))
    {
    }
}