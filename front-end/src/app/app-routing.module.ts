import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './pages/layout/layout.component';
import { FormEditComponent } from './pages/form-edit/form-edit/form-edit.component';
import { FormInputEditComponent } from './pages/form-input-edit/form-input-edit/form-input-edit.component';
import { FormInputListComponent } from './pages/form-input-list/form-input-list/form-input-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'layout', pathMatch: 'full'
  },
  {
    path: 'layout',
    component: LayoutComponent,
  },
  {
    path: 'form-edit',
    component: FormEditComponent,
  },
  { path: 'form-input-list/:formId', component: FormInputListComponent },
  { path: 'form-input-edit/:formId', component: FormInputEditComponent },
  { path: 'form-input-edit/:formId/:inputId', component: FormInputEditComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
