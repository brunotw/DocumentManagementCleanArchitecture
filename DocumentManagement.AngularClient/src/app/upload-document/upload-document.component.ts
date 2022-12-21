import { Component, OnInit } from '@angular/core';
import { DocumentService } from '../document.service';

@Component({
  selector: 'app-upload-document',
  templateUrl: './upload-document.component.html',
  styleUrls: ['./upload-document.component.css']
})

export class UploadDocumentComponent implements OnInit {
  fileName: string;
  fileExtension: string;
  fileBase64: string;
  imageExtensions: string[] = ["JPG", "JPEG", "JPE", "BMP", "GIF", "PNG"];

  constructor(private documentService: DocumentService) { }

  ngOnInit(): void {
  
  }

  onFileSelected(event: any) {
    debugger;
    const file: File = event.target.files[0];

    if (file) {
      this.fileName = file.name;
      this.fileExtension = String(file.name.split('.').pop());

      if (file.size > 3000000) {
        alert("Max file size 3MB.");
        this.clearFileVariables();
        return;
      }

      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.fileBase64 = reader.result != null ? reader.result.toString() : "";
        console.log(this.fileBase64);
      };
    }
    else {
      this.clearFileVariables();
    }
  }

  shouldEnableSubmit() {
    if (!this.fileName || this.fileName.length === 0) {
      return false;
    }

    if (!this.fileBase64 || this.fileBase64.length === 0) {
      return false;
    }

    return true;
  }

  showImagePreview() {
    if (this.isImage()) {
      return this.fileBase64;
    }
    else {
      return this.getBrowseImageBase64();
    }
  }

  onSubmit() {
    this.documentService.uploadDocument(this.fileName, this.fileBase64).subscribe({
      next: data => {
        this.clearFileVariables();
        this.documentService.updateList();
      },
      error: error => {
        console.error('There was an error. Error details: ', error);
      }
    })
  }

  private clearFileVariables() {
    this.fileName = "";
    this.fileBase64 = "";
    this.fileExtension = "";
  }
  
  private isImage() {
    return this.imageExtensions.includes(this.fileExtension);
  }

  private getBrowseImageBase64() {
    return "data:image/webp;base64,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";
  }
}
