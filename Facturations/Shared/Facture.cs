using System;
using System.ComponentModel.DataAnnotations;

namespace Facturations.Shared
{
  public class Facture
  {
    [Required(ErrorMessage = "Champ obligatoire")]
    public string client { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    public string reference { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    public DateTime dateEmission { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    [GreaterThan("dateEmission", ErrorMessage = "La date d'émission doit être inférieure à la date attendue pour le règlement.")]
    public DateTime dateReglementAttendu { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    [Range(0, double.MaxValue)]
    [GreaterOrEquals("montantRegle", ErrorMessage = "Le montant dû doit être supérieur ou égal au montant réglé.")]
    public double montantDu { get; set; }

    [Required(ErrorMessage = "Champ obligatoire")]
    [Range(0, double.MaxValue)]
    [LessOrEquals("montantDu", ErrorMessage = "Le montant réglé doit être inférieur ou égal au montant dû.")]
    public double montantRegle { get; set; }

    public Facture(string client, string reference, DateTime dateEmission, DateTime dateReglementAttendu, double montantDu, double montantRegle)
    {
      this.client = client;
      this.reference = reference;
      this.dateEmission = dateEmission;
      this.dateReglementAttendu = dateReglementAttendu;
      this.montantDu = montantDu;
      this.montantRegle = montantRegle;
    }

    public Facture() {}
  }

  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
  public class GreaterThanAttribute : ValidationAttribute
  {
    private readonly string _comparisonProperty;
    public GreaterThanAttribute(string comparisonProperty)
    {
      _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      ErrorMessage = ErrorMessageString;
      if (value.GetType() == typeof(IComparable))
      {
        throw new ArgumentException("value has not implemented IComparable interface");
      }

      var currentValue = (IComparable)value;
      var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
      if (property == null)
      {
        throw new ArgumentException("Comparison property with this name not found");
      }
      var comparisonValue = property.GetValue(validationContext.ObjectInstance);
      if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
      {
        throw new ArgumentException("Comparison property has not implemented IComparable interface");
      }
      if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
      {
        throw new ArgumentException("The properties types must be the same");
      }
      if (currentValue.CompareTo((IComparable)comparisonValue) <= 0)
      {
        return new ValidationResult(ErrorMessage);
      }

      return ValidationResult.Success;
    }
  }

  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
  public class GreaterOrEqualsAttribute : ValidationAttribute
  {
    private readonly string _comparisonProperty;
    public GreaterOrEqualsAttribute(string comparisonProperty)
    {
      _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      ErrorMessage = ErrorMessageString;
      if (value.GetType() == typeof(IComparable))
      {
        throw new ArgumentException("value has not implemented IComparable interface");
      }

      var currentValue = (IComparable)value;
      var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
      if (property == null)
      {
        throw new ArgumentException("Comparison property with this name not found");
      }
      var comparisonValue = property.GetValue(validationContext.ObjectInstance);
      if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
      {
        throw new ArgumentException("Comparison property has not implemented IComparable interface");
      }
      if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
      {
        throw new ArgumentException("The properties types must be the same");
      }
      if (currentValue.CompareTo((IComparable)comparisonValue) < 0)
      {
        return new ValidationResult(ErrorMessage);
      }

      return ValidationResult.Success;
    }
  }

  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
  public class LessOrEqualsAttribute : ValidationAttribute
  {
    private readonly string _comparisonProperty;
    public LessOrEqualsAttribute(string comparisonProperty)
    {
      _comparisonProperty = comparisonProperty;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      ErrorMessage = ErrorMessageString;
      if (value.GetType() == typeof(IComparable))
      {
        throw new ArgumentException("value has not implemented IComparable interface");
      }

      var currentValue = (IComparable)value;
      var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
      if (property == null)
      {
        throw new ArgumentException("Comparison property with this name not found");
      }
      var comparisonValue = property.GetValue(validationContext.ObjectInstance);
      if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
      {
        throw new ArgumentException("Comparison property has not implemented IComparable interface");
      }
      if (!ReferenceEquals(value.GetType(), comparisonValue.GetType()))
      {
        throw new ArgumentException("The properties types must be the same");
      }
      if (currentValue.CompareTo((IComparable)comparisonValue) > 0)
      {
        return new ValidationResult(ErrorMessage);
      }

      return ValidationResult.Success;
    }
  }
}