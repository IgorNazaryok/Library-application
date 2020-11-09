import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Provider } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainLayoutComponent } from './shared/components/main-layout/main-layout.component';
import { HomePageComponent } from './home-page/home-page.component';
import { MyBooksPageComponent } from './myBook-page/myBooks-page.component';
import { AdminModule } from './admin/admin.module';
import { BookComponent } from './shared/components/book/book.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import {ShareModule} from './shared/shared.module';
import {AuthInterceptor} from './shared/auth.interceptor';
import {ListAuthorPipe} from './shared/listAutor.pipe';
import {AlertComponent} from './shared/components/alert/alert.component'
import {AlertService} from './shared/alert.service'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

const INTERCEPTOR_PROVIDER: Provider = {
  provide: HTTP_INTERCEPTORS,
  multi: true,
  useClass: AuthInterceptor
}

@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    HomePageComponent,
    MyBooksPageComponent,
    BookComponent,
    ListAuthorPipe,
    AlertComponent,
    LoginPageComponent,
    RegistrationPageComponent
 
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    AdminModule,
    ShareModule
  ],
  providers: [INTERCEPTOR_PROVIDER, AlertService],
  bootstrap: [AppComponent]
})
export class AppModule { }
