import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListDocumentComponent } from './list-document/list-document.component';
import { UploadDocumentComponent } from './upload-document/upload-document.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'list',
    component: ListDocumentComponent,
  },
  {
    path: 'upload',
    component: UploadDocumentComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
