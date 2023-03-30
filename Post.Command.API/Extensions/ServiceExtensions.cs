using Confluent.Kafka;
using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructure;
using CQRS.Core.Producers;
using Post.Command.API.Commands;
using Post.Command.Domain.Aggregates;
using Post.Command.Infrastructure.Config;
using Post.Command.Infrastructure.Dispatchers;
using Post.Command.Infrastructure.Handlers;
using Post.Command.Infrastructure.Producers;
using Post.Command.Infrastructure.Repositories;
using Post.Command.Infrastructure.Store;

namespace Post.Command.API.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    { 
        services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        services.AddScoped<IEventProducer, EventProducer>();
        services.AddScoped<IEventStore, EventStore>();
        services.AddScoped<IEventSourcingHandler<PostAggregate>, EventSourcingHandler>();
        services.AddScoped<ICommandHandler, CommandHandler>();
    }
    
    public static void ConfigureMongoDb(this IServiceCollection services,IConfiguration configuration) =>
        services.Configure<MongoDbConfig>(configuration.GetSection(nameof(MongoDbConfig)));
    
    public static void ConfigureKafkaProducer(this IServiceCollection services,IConfiguration configuration) =>
        services.Configure<ProducerConfig>(configuration.GetSection(nameof(ProducerConfig)));
    
    public static ICommandHandler GetCommandHandler(this IServiceCollection services) =>
        services.BuildServiceProvider().GetRequiredService<ICommandHandler>();

    public static void RegisterHandlers(this CommandDispatcher dispatcher, ICommandHandler commandHandler)
    {
        dispatcher.RegisterHandler<NewPostCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<EditMessageCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<LikePostCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<AddCommentCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<EditCommentCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<RemoveCommentCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<DeletePostCommand>(commandHandler.HandleAsync);
        dispatcher.RegisterHandler<RestoreReadDbCommand>(commandHandler.HandleAsync);
    }
}
