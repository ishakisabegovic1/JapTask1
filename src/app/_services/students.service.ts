import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { i18nMetaToJSDoc } from '@angular/compiler/src/render3/view/i18n/meta';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/Pagination';
import { Student } from '../_models/Student';
import { StudentClass } from '../_models/StudentClass';
import { StudentParams } from '../_models/StudentParams';

// const httpOptions = {
//   headers: new HttpHeaders({
//    Authorization: 'Bearer '+ JSON.parse(localStorage.getItem('user'))?.token
//   })
// }


@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  baseUrl = environment.apiUrl;
  studentParams: StudentParams;
  paginatedResult: PaginatedResult<Student[]> = new PaginatedResult<Student[]>();

  constructor(private http: HttpClient) { }

  setStudentParams(params:StudentParams){
    this.studentParams = params;
  }

  resetStudentParams(){
    this.studentParams = new StudentParams();
    return this.studentParams;
  }
  
  // getStudents() {
    
  //   return this.http.get<Student[]>(this.baseUrl+'Students');
  // }

  getStudents(page?: number, itemsPerPage?:number, name?:string, selection?:string, status?:string, orderby?:string) {
    let params = new HttpParams();
    if(page != null && itemsPerPage != null){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
      if(name != null) params = params.append('nameFilter',name.toString());
      if(selection != null) params = params.append('selectionFilter',selection.toString());
      if(status != null) params = params.append('statusFilter',status.toString());
      if(orderby != null) params = params.append('OrderBy',orderby.toString());
    }

    return this.http.get<Student[]>(this.baseUrl+'Students', { observe: 'response', params}).pipe(
      map(response => {
        this.paginatedResult.result=response.body;
        
        if(response.headers.get('Pagination') != null){
          this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        console.log(this.paginatedResult.pagination);
        console.log(response);
        return this.paginatedResult;
      })

    );
  }

  getStudent(id: number){
    return this.http.get<Student>(this.baseUrl+'Students/'+id);
  }

  getStudentsBySelectionId(id:number){
    return this.http.get<Student[]>(this.baseUrl+'Students/selectionStudents/'+id);
  }

  updateStudent(student: Student){
    return this.http.put<Student>(this.baseUrl + 'Students/edit-student/'+student.id, student);
  }
  
  addStudent(student:StudentClass){
    return this.http.post<StudentClass>(this.baseUrl + 'Students/add-student', student);
  }

  deleteStudent(id:number){
    return this.http.delete<Student>(this.baseUrl + 'Students/delete-student/'+id);
  }


}
