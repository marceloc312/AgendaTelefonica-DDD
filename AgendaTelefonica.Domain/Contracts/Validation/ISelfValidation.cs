using AgendaTelefonica.Domain.Validation;

namespace AgendaTelefonica.Domain.Contracts.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
		bool IsValid();
    }
}