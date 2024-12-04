using FluentValidation;

namespace ProSolutionFormsAPI.Models
{
    public class CriminalConvictionsModel
    {
        public ICollection<CriminalConvictionModel>? Convictions { get; set; }
    }

    public class CriminalConvictionsValidator : AbstractValidator<CriminalConvictionsModel>
    {
        public CriminalConvictionsValidator()
        {
            RuleFor(c => c.Convictions).ForEach(x => x.SetValidator(new CriminalConvictionValidator()));
        }
    }
}
