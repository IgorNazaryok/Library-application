import { NgModule } from '@angular/core';
import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { MainLayoutComponent } from './shared/components/main-layout/main-layout.component';
import { HomePageComponent } from './home-page/home-page.component';
import { MyBooksPageComponent } from './myBook-page/myBooks-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';


const routes: Routes = [
  {path:'', component: MainLayoutComponent, 
  children:[
      {path:'', redirectTo: '/', pathMatch:'full'},
      {path:'', component: HomePageComponent},
      {path:'mybooks', component: MyBooksPageComponent},
      {path:'login', component: LoginPageComponent},
      {path:'registration', component: RegistrationPageComponent},
      {path:'refresh=1', component: HomePageComponent}
    ]
  },
  {path:'admin',  loadChildren: './admin/admin.module#AdminModule'},
  {path:'**', redirectTo: '/'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes, 
    {preloadingStrategy:PreloadAllModules})
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
