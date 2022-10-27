import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Jap } from '../_models/Jap';
import { ProgramClass } from '../_models/ProgramClass';
import { ProgramItemUpsert } from '../_models/ProgramItemUpsert';

@Injectable({
  providedIn: 'root'
})
export class JapsService {



  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getJaps() {
    return this.http.get<Jap[]>(this.baseUrl+'Programs');
  }

  getProgramDetails(id: number){
    return this.http.get<any>(this.baseUrl+'Programs/programItems/'+id);
  }

  addProgram(program: ProgramClass){
    return this.http.post<ProgramClass>(this.baseUrl+'Programs/add-program',program);
  }

  addProgramItem(programItem: ProgramItemUpsert){
    return this.http.post<ProgramItemUpsert>(this.baseUrl+'Programs/add-item', programItem);
  }

  deleteProgram(id: number){
    return this.http.delete<ProgramClass>(this.baseUrl+'Programs/delete-program/'+id);
  }

  editProgram(program: ProgramClass){
   return this.http.put<ProgramClass>(this.baseUrl+'Programs/edit-program/'+program.id, program);
  }

  getProgramById(id:number){
    return this.http.get<ProgramClass>(this.baseUrl+'Programs/'+id);
  }





}
