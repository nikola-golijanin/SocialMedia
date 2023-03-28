using Post.Common.DTOs;

namespace Post.Command.API.DTOs;

public class NewPostResponse : BaseResponse
{
    public Guid Id { get; set; }
}