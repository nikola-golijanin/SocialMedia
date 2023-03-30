using Confluent.Kafka;
using Post.Query.API.Queries;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.Dispatchers;
using Post.Query.Infrastructure.Handlers;
using Post.Query.Infrastructure.Repositories;
using EventHandler = Post.Query.Infrastructure.Handlers.EventHandler;

namespace Post.Query.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IQueryHandler, QueryHandler>();
        services.AddScoped<IEventHandler, EventHandler>();
    }        
    
    public static void ConfigureKafkaConsumer(this IServiceCollection services,IConfiguration configuration) =>
        services.Configure<ConsumerConfig>(configuration.GetSection(nameof(ConsumerConfig)));
    
    public static IQueryHandler GetQueryHandler(this IServiceCollection services) =>
        services.BuildServiceProvider().GetRequiredService<IQueryHandler>();
    
    public static void RegisterHandlers(this QueryDispatcher dispatcher, IQueryHandler queryHandler)
    {
        dispatcher.RegisterHandler<FindAllPostsQuery>(queryHandler.HandleAsync);
        dispatcher.RegisterHandler<FindPostByIdQuery>(queryHandler.HandleAsync);
        dispatcher.RegisterHandler<FindPostsByAuthorQuery>(queryHandler.HandleAsync);
        dispatcher.RegisterHandler<FindPostsWithCommentsQuery>(queryHandler.HandleAsync);
        dispatcher.RegisterHandler<FindPostsWithLikesQuery>(queryHandler.HandleAsync);
    }
}