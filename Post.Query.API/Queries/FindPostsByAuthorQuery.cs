using CQRS.Core.Queries;

namespace Post.Query.API.Queries;

public class FindPostsByAuthorQuery : BaseQuery
{
    public string Author { get; set; }
}