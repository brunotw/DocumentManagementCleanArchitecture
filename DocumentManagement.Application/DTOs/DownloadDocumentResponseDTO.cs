using System;
using System.IO;

namespace DocumentManagement.Application.DTOs
{
    public class DownloadDocumentResponseDTO
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Stream Stream { get; set; }
    }
}
