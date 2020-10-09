import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Provider } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { registerLocaleData } from '@angular/common';
import ruLocale from '@angular/common/locales/ru';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainLayoutComponent } from './shared/components/main-layout/main-layout.component';
import { HomePageComponent } from './home-page/home-page.component';
import { AdminModule } from './admin/admin.module';
import { BookComponent } from './shared/components/book/book.component';
import {ShareModule} from './shared/shared.module';
import {AuthInterceptor} from './shared/auth.interceptor';
import {ListAuthorPipe} from './shared/listAutor.pipe';
import {AlertComponent} from './shared/components/alert/alert.component'
import {AlertService} from './shared/alert.service'

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
    BookComponent,
    ListAuthorPipe,
    AlertComponent
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminModule,
    ShareModule
  ],
  providers: [INTERCEPTOR_PROVIDER, AlertService],
  bootstrap: [AppComponent]
})
export class AppModule { }
