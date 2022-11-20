import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Document } from './document/Document';



@Injectable({
  providedIn: 'root'
})

export class DocumentService {
  imageSource: any;
  private static readonly apiBaseUri = "https://localhost:7175/api/document";
  
  constructor(private http: HttpClient) { }

  getDocuments(): Document[] {
    let files: Document[] = new Array();

    this.http.get(`${DocumentService.apiBaseUri}/all`, { responseType: 'json' }).subscribe(data => {
      let filesArray = Object.assign([new Document()], data);

      filesArray.forEach(doc => {
        let newInstance = new Document();
        newInstance.id = doc.id;
        newInstance.fileName = doc.fileName;
        newInstance.fileExtension = doc.fileExtension;
        newInstance.documentBase64 = doc.documentBase64;

        files.push(newInstance);
      });
    });

    return files;
  }

  deleteDocument(documentId: number) {
    const options = {
      responseType: "text" as const
    }

    return this.http.delete(`${DocumentService.apiBaseUri}/delete/` + documentId, options);
  }
}
