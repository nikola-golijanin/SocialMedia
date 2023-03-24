using CQRS.Core.Events;

namespace Post.Common.Events;

public class PostLikedEvent : BaseEvent
{
    public PostLikedEvent(string type) : base(nameof(PostLikedEvent))
    {
    }
}