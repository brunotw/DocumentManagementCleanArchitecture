using AutoMapper;
using DocumentManagement.API.DTOs;
using DocumentManagement.Domain.Entities;

namespace DocumentManagement.API.MappingProfiles
{
    public class UploadDocumentResponseProfile : Profile
    {
        public UploadDocumentResponseProfile()
        {
            CreateMap<Document, UploadDocumentResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(source => source.FileName));
        }
    }
}
