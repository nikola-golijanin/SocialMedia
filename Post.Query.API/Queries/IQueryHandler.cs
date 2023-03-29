﻿using Post.Query.Domain.Entities;

namespace Post.Query.API.Queries;

public interface IQueryHandler
{
    Task<List<PostEntity>> HandleAsync(FindAllPostsQuery query);
    Task<List<PostEntity>> HandleAsync(FindPostByIdQuery query);
    Task<List<PostEntity>> HandleAsync(FindPostsByAuthorQuery query);
    Task<List<PostEntity>> HandleAsync(FindPostsWithCommentsQuery query);
    Task<List<PostEntity>> HandleAsync(FindPostsWithLikesQuery query);
}