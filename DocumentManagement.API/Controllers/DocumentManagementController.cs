using AutoMapper;
using DocumentManagement.API.DTOs;
using DocumentManagement.Application.Interfaces.Application;
using DocumentManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManagement.API.Controllers
{
    [ApiController]
    public class DocumentManagementController : ControllerBase
    {
        private readonly ILogger<DocumentManagementController> _logger;
        private readonly IDocumentHandler _documentHandler;
        private readonly IMapper _mapper;
        public DocumentManagementController(ILogger<DocumentManagementController> logger, IDocumentHandler documentHandler, IMapper mapper)
        {
            _logger = logger;
            _documentHandler = documentHandler;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/document")]
        public IActionResult UploadDocument(UploadDocumentRequest uploadDocumentRequest)
        {
            Document documentRequest = _mapper.Map<Document>(uploadDocumentRequest);
            Document documentResponse = _documentHandler.UploadDocument(documentRequest);
            UploadDocumentResponse uploadDocumentResponse = _mapper.Map<UploadDocumentResponse>(documentResponse);

            return Ok(uploadDocumentResponse);
        }

        [HttpGet]
        [Route("api/document/download/{documentPath}")]
        public  FileContentResult DownloadDocument(string documentPath)
        {
            var document = _documentHandler.DownloadDocument(documentPath);
            DownloadDocumentResponse response = _mapper.Map<DownloadDocumentResponse>(document);
            
            MemoryStream ms = new MemoryStream();
            response.Stream.CopyTo(ms);
            return File(ms.ToArray(), "application/octet-stream", response.FileName);
        }
    }
}