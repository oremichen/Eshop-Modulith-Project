namespace Catalog.Product.Events;

public class ProductCreatedEvent: IDomainEvent
{
    private Models.Product Product {  get; }

    public ProductCreatedEvent(Models.Product product)
    {
        Product = product;
    }
}
