namespace Catalog.Product.Events;

public class ProductPriceChangedEvent : IDomainEvent
{
    public Models.Product Product { get; }

    public ProductPriceChangedEvent(Models.Product product)
    {
        Product = product;
    }
}