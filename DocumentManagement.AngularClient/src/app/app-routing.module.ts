import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { UploadDocumentComponent } from './upload-document/upload-document.component';

const routes: Routes = [
    {
        path: 'upload',
        component: UploadDocumentComponent,
    },
    { 
        path: 'list', 
        component: AppComponent
     },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})

export class AppRoutingModule { }
