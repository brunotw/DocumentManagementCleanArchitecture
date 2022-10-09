using AutoMapper;
using DocumentManagement.API.DTOs;
using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Interfaces.Application;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [Route("api/document/upload")]
        public IActionResult UploadDocument(UploadRequest uploadDocumentRequest)
        {
            try
            {
                UploadDocumentRequest documentRequest = _mapper.Map<UploadDocumentRequest>(uploadDocumentRequest);
                UploadDocumentResponse documentResponse = _documentHandler.UploadDocument(documentRequest);
                UploadResponse uploadDocumentResponse = _mapper.Map<UploadResponse>(documentResponse);

                return Ok(uploadDocumentResponse);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Request Uri: {UriHelper.GetDisplayUrl(Request)}");
                _logger.LogInformation($"Payload: {JsonConvert.SerializeObject(uploadDocumentRequest)}");
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/document/download/{documentId}")]
        public FileContentResult DownloadDocument(long documentId)
        {
            try
            {
                var document = _documentHandler.DownloadDocument(documentId);
                DownloadResponse response = _mapper.Map<DownloadResponse>(document);

                MemoryStream ms = new MemoryStream();
                response.Stream.CopyTo(ms);
                return File(ms.ToArray(), "application/octet-stream", response.FileName);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Request Uri: {UriHelper.GetDisplayUrl(Request)}");
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpDelete]
        [Route("api/document/delete/{documentId}")]
        public IActionResult DeleteDocument(long documentId)
        {
            try
            {
                _documentHandler.DeleteDocument(documentId);

                return Ok($"Document with id {documentId} successfully deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Request Uri: {UriHelper.GetDisplayUrl(Request)}");
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}