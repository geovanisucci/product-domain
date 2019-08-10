using System;
using FluentValidator;
using FluentValidator.Validation;

namespace ProductBoundedContext.Domain.EntityDomain
{
    public class ProductEntityDomain : Notifiable
    {
        public string Id { get; set; }        
        public string Description { get; set; }
        public string BarCode { get; set; }
        public string UnitMeasurementId { get; set; }  
        public int Active { get; set; }
        public DateTime CreatedAt { get; set; }      
        public DateTime? UpdatedAt { get; set; } 

        public bool Validate()
        {
            AddNotifications(new ValidationContract()
                            .IsNotNullOrEmpty(Description, "Campo Descrição", "Este campo não pode ser vazio.")
                            .HasMaxLen(Description, 250, "Campo Descrição", "Este campo deve conter no máximo 250 caracteres.")
                            .IsNotNullOrEmpty(BarCode, "Campo Código de Barras", "Este campo não pode ser vazio."));


            return Valid;
        }
    }
}