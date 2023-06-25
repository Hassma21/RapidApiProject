using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x =>x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim Alanı Boş Geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir Alanı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("En az 2 karakter");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("En az 3 karakter");
        }
    }
}
