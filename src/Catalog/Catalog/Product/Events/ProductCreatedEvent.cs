namespace Catalog.Product.Events;

public record ProductCreatedEvent(Models.Product product): IDomainEvent;
