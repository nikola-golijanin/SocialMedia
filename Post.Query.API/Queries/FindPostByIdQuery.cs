using CQRS.Core.Queries;

namespace Post.Query.API.Queries;

public class FindPostByIdQuery : BaseQuery
{
    public Guid Id { get; set; }
}