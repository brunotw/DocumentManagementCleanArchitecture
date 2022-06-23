using AutoMapper;
using DocumentManagement.API.DTOs;

namespace DocumentManagement.API.MappingProfiles
{
    public class DownloadDocumentResponseProfile : Profile
    {
        public DownloadDocumentResponseProfile()
        {
            CreateMap<Application.DTOs.DownloadDocumentResponseDTO, DownloadDocumentResponse>()
                     .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                     .ForMember(dest => dest.FileName, opt => opt.MapFrom(mapExpression: source => source.FileName))
                     .ForMember(dest => dest.Stream, opt => opt.MapFrom(mapExpression: source => source.Stream));
        }
    }
}
