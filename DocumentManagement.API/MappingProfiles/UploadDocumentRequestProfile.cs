using AutoMapper;
using DocumentManagement.API.DTOs;
using DocumentManagement.Domain.Entities;

namespace DocumentManagement.API.Configurations
{
    public class UploadDocumentRequestProfile : Profile
    {
        public UploadDocumentRequestProfile()
        {
            CreateMap<UploadDocumentRequest, Document>()
                   .ForMember(dest => dest.FileName, opt => opt.MapFrom(source => source.FileName))
                   .ForMember(dest => dest.DocumentBase64, opt => opt.MapFrom(source => source.DocumentBase64));
        }
    }
}
