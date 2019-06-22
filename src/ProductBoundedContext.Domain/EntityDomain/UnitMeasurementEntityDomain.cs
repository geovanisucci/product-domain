using FluentValidator;
using FluentValidator.Validation;

namespace ProductBoundedContext.Domain.EntityDomain
{
    public class UnitMeasurementEntityDomain : Notifiable
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                            .IsNotNullOrEmpty(Code, "Campo Código", "Este campo não pode ser vazio")
                            .HasMaxLen(Code, 6, "Campo Código", "Este campo pode conter no máximo 6 caracteres")
                            .IsNotNullOrEmpty(Description, "Campo descrição", "Este campo não pode ser vazio.")
                            .HasMaxLen(Description, 20, "Campo Descrição", "Este campo pode conter no máximo 20 caracteres."));

            return Valid;
        }
    }
}