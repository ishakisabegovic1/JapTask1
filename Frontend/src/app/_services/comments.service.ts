import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Comment } from '../_models/Comment';
import { UserStudent } from '../_models/UserStudent';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getComments() {
    return this.http.get<UserStudent[]>(this.baseUrl+'UserStudents');
  }

  getCommentsById(id: number){
    return this.http.get<UserStudent[]>(this.baseUrl+'UserStudents/'+id);
  }

  addNewComment(comment:Comment){
    console.log(comment);
    return this.http.post<Comment>(this.baseUrl + 'UserStudents/add-comment/'+comment.studentId, comment);
  }

  deleteComment(id:number){
    return this.http.delete<Comment>(this.baseUrl+ 'UserStudents/delete-comment/'+id);
  }
}
