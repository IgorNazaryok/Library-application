import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {RouterModule} from '@angular/router'
import { AdminLayoutComponent } from './shared/components/admin-layout/admin-layout.component';
import {LoginPageComponent} from './login-page/login-page.component';
import {RegistrationPageComponent} from './registration-page/registration-page.component';
import { DashboardPageComponent } from './dashboard-page/dashboard-page.component';
import { CreatePageComponent } from './create-page/create-page.component';
import { EditPageComponent } from './edit-page/edit-page.component'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {AuthGuard} from './shared/service/auth.guard'
import {ShareModule} from '../shared/shared.module'
import {ListRedersPipe} from './shared/listRedersPipe'
import {AuthorPipe} from './shared/authorPipe';
import {AlertAdminComponent} from './shared/components/alert-admin/alert-admin.component'

@NgModule({
  declarations: [
    AdminLayoutComponent,
    LoginPageComponent,
    RegistrationPageComponent,
    DashboardPageComponent,
    CreatePageComponent,
    EditPageComponent,
    ListRedersPipe,
    AuthorPipe,
    AlertAdminComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ShareModule,
    RouterModule.forChild([
      {path: '', component: AdminLayoutComponent, 
      children:[
        {path: '', redirectTo: '/admin/login', pathMatch: 'full'},
        {path:'login', component: LoginPageComponent},
        {path:'registration', component: RegistrationPageComponent},
        {path:'create', component: CreatePageComponent, canActivate: [AuthGuard]},
        {path:'dashboard', component: DashboardPageComponent, canActivate: [AuthGuard]},
        {path:'book/:id/edit', component: EditPageComponent, canActivate: [AuthGuard]}
      ]}
    ])
  ],
  exports:[
    RouterModule
  ],
  providers: [AuthGuard]
})
export class AdminModule { }
