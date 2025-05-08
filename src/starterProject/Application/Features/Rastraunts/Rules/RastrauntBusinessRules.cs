using Application.Features.Rastraunts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Rastraunts.Rules;

public class RastrauntBusinessRules : BaseBusinessRules
{
    private readonly IRastrauntRepository _rastrauntRepository;
    private readonly ILocalizationService _localizationService;

    public RastrauntBusinessRules(IRastrauntRepository rastrauntRepository, ILocalizationService localizationService)
    {
        _rastrauntRepository = rastrauntRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RastrauntsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RastrauntShouldExistWhenSelected(Restraunt? rastraunt)
    {
        if (rastraunt == null)
            await throwBusinessException(RastrauntsBusinessMessages.RastrauntNotExists);
    }

    public async Task RastrauntIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Restraunt? rastraunt = await _rastrauntRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RastrauntShouldExistWhenSelected(rastraunt);
    }
}