import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { DocumentService } from '../document.service';
import { Document } from './Document';

@Component({
  selector: 'app-list-document',
  templateUrl: './list-document.component.html',
  styleUrls: ['./list-document.component.css'],
})
export class ListDocumentComponent implements OnInit {
  fileName: string;
  fileBase64: string;
  previewFileName: string;

  imageSource: any;
  files: Document[] = new Array();

  constructor(
    private documentService: DocumentService,
    private _sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.files = this.documentService.getDocuments();
    this.documentService.receiveUpdate().subscribe((data) => {
      this.files = data;
    });
  }

  downloadDocument(doc: Document) {
    const downloadLink = document.createElement('a');
    downloadLink.href = doc.documentBase64;
    downloadLink.download = doc.fileName;
    downloadLink.click();
  }

  viewDocumentModal(doc: any) {
    this.imageSource = this._sanitizer.bypassSecurityTrustResourceUrl(
      doc.documentBase64
    );
    this.previewFileName = doc.fileName;
  }

  deleteDocument(documentId: number) {
    this.documentService.deleteDocument(documentId).subscribe({
      next: (data) => {
        console.log(data);
        this.ngOnInit();
      },
      error: (error) => {
        console.error('There was an error. Error details: ', error.error);
        alert('There was an error. Error details: ' + error.error);
      },
    });
  }

  editDocument() {}
}
