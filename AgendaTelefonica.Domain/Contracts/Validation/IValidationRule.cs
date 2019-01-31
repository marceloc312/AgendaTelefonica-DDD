namespace AgendaTelefonica.Domain.Contracts.Validation
{
    public interface IValidationRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Valid(TEntity entity);
    }
}