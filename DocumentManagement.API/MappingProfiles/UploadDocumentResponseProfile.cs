using AutoMapper;
using DocumentManagement.API.DTOs;
using DocumentManagement.Application.DTOs;

namespace DocumentManagement.API.MappingProfiles
{
    public class UploadDocumentResponseProfile : Profile
    {
        public UploadDocumentResponseProfile()
        {
            CreateMap<UploadDocumentResponse, UploadResponse>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(source => source.ExternalId))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(source => source.Name));
        }
    }
}
