import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {map} from 'rxjs/operators';
import { User } from '../_models/user';
import {ReplaySubject} from 'rxjs';
import { environment } from 'src/environments/environment';
import { JsonPipe } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
 baseUrl = environment.apiUrl;

 private currentUserSource = new ReplaySubject<User>(1);
 currentUser$ = this.currentUserSource.asObservable();
 role: string;
 id: number;
 isStudent:boolean;
 isAdmin:boolean;
  constructor(private http: HttpClient, private route: Router){
   }

   login(model:any){
    return this.http.post(this.baseUrl + 'Auth/login', model).pipe(
      map((response: User) => {
        const user = response;
        if(user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
          console.log(user);
          this.role = user.roles;
          this.id = user.studentId;
          return response;
        }
      })
    );
   }

   setCurrentUser(user: User){

    this.currentUserSource.next(user);
   }

   logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.role="";
    this.isStudent =false;
    this.isAdmin=false;
    this.route.navigateByUrl('login');
   }

  }
