import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/admin/shared/service/auth.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent implements OnInit {

  constructor(
    private router: Router,
    public authService:AuthService) { }

  ngOnInit(): void {
    
  }

  logout(event:Event){
    event.preventDefault()
    this.authService.logout()
    this.router.navigate(['refresh=1'])
    console.log('logout');
    
  }

}
