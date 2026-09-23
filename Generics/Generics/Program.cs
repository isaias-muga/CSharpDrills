namespace Generics
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }

    public class EntityRepository<T, TId> where T : IEntity<TId> where TId : notnull
    {
        private readonly Dictionary<TId, T> _entities = new Dictionary<TId, T>();

        public void Add(T entity)
        {
            _entities[entity.Id] = entity;
        }
        public T? GetById(TId id)
        {
            _entities.TryGetValue(id, out var entity);
            return entity;
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.Values;
        }
    }

    public class Product : IEntity<int>
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var productRepository = new EntityRepository<Product, int>();

            productRepository.Add(new Product { Id = 2, Name = "Smartphone" });
            productRepository.Add(new Product { Id = 1, Name = "Laptop" });

            var retrievedProduct = productRepository.GetById(1);

            Console.WriteLine($"Retrieved Product: {retrievedProduct?.Name}");

            var allProducts = productRepository.GetAll();

            Console.WriteLine("All Products:");
            foreach (var p in allProducts)
            {
                Console.WriteLine($"{p.Name}");
            }
        }
    }

}
