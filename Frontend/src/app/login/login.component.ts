import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model : any = {}
  currentUser$: Observable<User>;
  baseUrl = environment.apiUrl;

  constructor(public accountService : AccountService, private router:Router,  private cd: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }


  login(){
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      if(response.roles == 'Student')
        this.router.navigateByUrl("stud/profile");
      else if(response.roles == 'Admin')
        this.router.navigateByUrl('students');
    }, error => {
      console.log(error);
    })
    this.cd.detectChanges();

  }

  logout(){
    this.router.navigateByUrl(this.baseUrl+'login');
    this.accountService.logout();

  }







}
