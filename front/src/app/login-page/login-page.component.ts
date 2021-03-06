import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms'
import {AuthRequest} from '../shared/interface'
import { AuthService } from '../shared/service/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  form:FormGroup


  constructor(
    public auth:AuthService,
    private router: Router
  ) { }


  ngOnInit(): void {

    this.form=new FormGroup({
      email: new FormControl(null, [Validators.email, Validators.required]),
      password: new FormControl(null, [Validators.required, Validators.minLength(6)]),
    })
  }

  submit(){
    const model:AuthRequest = {
      Email: this.form.value.email,
      Password: this.form.value.password
    }
    this.auth.Login(model).subscribe(()=>{
      this.form.reset
      this.auth.ClearAuthError() 
      if(this.auth.isRoleAdmin())
      {
        this.router.navigate(['/admin', 'dashboard'])        
      }
      else{
        this.router.navigate(['/'])
      }
    })
  }
}
