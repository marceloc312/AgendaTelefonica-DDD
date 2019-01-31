using AgendaTelefonica.Domain.Validation;

namespace AgendaTelefonica.Domain.Contracts.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}