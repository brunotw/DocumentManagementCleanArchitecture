using AutoMapper;
using DocumentManagement.API.DTOs;
using DocumentManagement.Application.DTOs;

namespace DocumentManagement.API.Configurations
{
    public class UploadDocumentRequestProfile : Profile
    {
        public UploadDocumentRequestProfile()
        {
            CreateMap<UploadRequest, UploadDocumentRequest>()
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(source => source.FileName))
                   .ForMember(dest => dest.DocumentBase64, opt => opt.MapFrom(source => source.DocumentBase64));
        }
    }
}
