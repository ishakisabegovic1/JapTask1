import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';

  constructor(public accountService: AccountService, private route: Router, private cd: ChangeDetectorRef){}
  ngOnInit(){
     this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    if (user) {
      this.accountService.setCurrentUser(user);

    }
    // if(this.isStudent) {
    //      this.route.navigateByUrl('student/profile');
    // } else
    // if(this.isAdmin){
    //   this.route.navigateByUrl('students');
    // }
    // this.cd.detectChanges();
  }

  isStudent(): boolean{
    return this.accountService.isStudent;
  }

  isAdmin(): boolean{
    return this.accountService.isAdmin;
  }

}
