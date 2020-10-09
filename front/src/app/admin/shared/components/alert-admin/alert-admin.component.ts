import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import {Alert, AlertService} from '../../../../shared/alert.service'

@Component({
  selector: 'app-alert-admin',
  templateUrl: './alert-admin.component.html',
  styleUrls: ['./alert-admin.component.scss']
})
export class AlertAdminComponent implements OnInit, OnDestroy {

  @Input() delay = 5000
 public alert:Alert={
    type:'danger',
    text:''
  }

  aSub:Subscription
   
  constructor(
   private alertService:AlertService
  ) { }

  ngOnInit(): void {
    this.aSub = this.alertService.alert$.subscribe(alert=>{
      this.alert=alert

      const timeout = setTimeout(()=>{
        clearTimeout(timeout)
        this.alert.text = ''
      }, this.delay)
    })
  }

  ngOnDestroy(): void {
    if(this.aSub) {
      this.aSub.unsubscribe()
    }
  }
 
}
