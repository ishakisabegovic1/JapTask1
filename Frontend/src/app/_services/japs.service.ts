import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Jap } from '../_models/Jap';

@Injectable({
  providedIn: 'root'
})
export class JapsService {

  

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getJaps() {
    return this.http.get<Jap[]>(this.baseUrl+'Programs');
  }
}
