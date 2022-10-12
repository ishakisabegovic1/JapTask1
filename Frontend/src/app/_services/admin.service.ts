import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AdminReport } from '../_models/AdminReport';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getAdminReport(){
    return this.http.get<AdminReport[]>(this.baseUrl+'Admin');
  }

}
