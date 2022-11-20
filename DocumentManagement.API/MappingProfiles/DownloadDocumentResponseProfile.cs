using AutoMapper;
using DocumentManagement.API.DTOs;
using DocumentManagement.Application.DTOs;

namespace DocumentManagement.API.MappingProfiles
{
    public class DownloadDocumentResponseProfile : Profile
    {
        public DownloadDocumentResponseProfile()
        {
            CreateMap<DownloadDocumentResponse, DownloadResponse>()
                     .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                     .ForMember(dest => dest.FileName, opt => opt.MapFrom(mapExpression: source => source.FileName))
                     .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(mapExpression: source => source.FileExtension))
                     .ForMember(dest => dest.DocumentBase64, opt => opt.MapFrom(mapExpression: source => source.DocumentBase64));
        }
    }
}
