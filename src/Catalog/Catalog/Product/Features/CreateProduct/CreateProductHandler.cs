using MediatR;

namespace Catalog.Product.Features.CreateProduct
{
    public class CreateProductCommand: IRequest<CreateProductResult>
    {
        public CreateProductCommand(string name, List<string> category, string description, string imageFile, decimal price) 
        {
            Name = name;
            Category = category;
            Description = description;
            ImageFile = imageFile;
            Price = price;

        }
        public string Name { get; set; }
        public List<string> Category {  get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateProductResult
    {
        public CreateProductResult(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
