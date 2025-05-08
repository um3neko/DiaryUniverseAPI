using DiaryUniverse.Application.DTOs.BaseResponse;
using DiaryUniverse.Application.DTOs.Constellation;
using DiaryUniverse.Infrastructure.Data.Models;

namespace DiaryUniverse.Application.Services.Interfaces;

public interface IConstellationService
{
    Task<IServiceResponse<List<Constellation>>> GetAllConstellations();
    Task<IServiceResponse<Constellation>> GetConstellationById(Guid id);
    Task<IServiceResponse<Constellation?>> CreateConstellation(AddConstellationDto dto);
    Task<IServiceResponse<Constellation?>> UpdateConstellation(Constellation constellation);
    Task<IServiceResponse<Constellation?>> DeleteConstellation(Constellation constellation);
    
}