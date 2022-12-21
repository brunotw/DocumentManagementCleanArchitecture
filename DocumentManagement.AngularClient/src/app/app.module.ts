import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { DocumentComponent } from './list-document/document.component';
import { HttpClientModule } from '@angular/common/http';
import { DocumentService } from './document.service';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { UploadDocumentComponent } from './upload-document/upload-document.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    DocumentComponent,
    UploadDocumentComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatIconModule,
    MatButtonModule,
    AppRoutingModule
  ],
  providers: [DocumentService],
  bootstrap: [AppComponent]
})

export class AppModule { }
