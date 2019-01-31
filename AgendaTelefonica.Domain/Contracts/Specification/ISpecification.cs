namespace AgendaTelefonica.Domain.Contracts.Specification
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}