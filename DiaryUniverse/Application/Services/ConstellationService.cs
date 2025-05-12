using DiaryUniverse.Application.DTOs.BaseResponse;
using DiaryUniverse.Application.DTOs.Constellation;
using DiaryUniverse.Application.Services.Interfaces;
using DiaryUniverse.Infrastructure.Data.Models;
using DiaryUniverse.Infrastructure.Repositories;

namespace DiaryUniverse.Application.Services;

public class ConstellationService(IUnitOfWork unitOfWork) : IConstellationService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public Task<IServiceResponse<List<Constellation>>> GetAllConstellations()
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResponse<Constellation>> GetConstellationById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IServiceResponse<Constellation?>> CreateConstellation(AddConstellationDto dto)
    {
        if (dto.User != null)
        {
            var newItem = new Constellation
            {
                User = dto.User,
                Name = dto.Name,
                Description = "=)",
                Id = Guid.NewGuid(),
                Stars = [],
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatedBy = dto.User.Id,
                UserId = dto.User.Id,
            };
            try
            {
                var repository = _unitOfWork.GetRepository<Constellation>();
                await repository.AddAsync(newItem);
                await repository.SaveAsync();
                return ServiceResponse<Constellation>.Success();
            }
            catch (Exception ex)
            {
                return ServiceResponse<Constellation>.Failure(ex.Message);
            }
        }
        
        else 
            return ServiceResponse<Constellation>.Failure("User does not exist");
    }

    public Task<IServiceResponse<Constellation?>> CreateConstellation(Constellation constellation)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResponse<Constellation?>> UpdateConstellation(Constellation constellation)
    {
        throw new NotImplementedException();
    }

    public Task<IServiceResponse<Constellation?>> DeleteConstellation(Constellation constellation)
    {
        throw new NotImplementedException();
    }
}