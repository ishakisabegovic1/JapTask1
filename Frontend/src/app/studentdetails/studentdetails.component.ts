import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from '../_models/Student';
import { SelectionsService } from '../_services/selections.service';
import { StudentsService } from '../_services/students.service';
import { Selection } from '../_models/Selection';
import { CommentsService } from '../_services/comments.service';
import { Comment } from '../_models/Comment';
import { UserStudent } from '../_models/UserStudent';
import { HasRoleDirective } from '../_directives/has-role.directive';

@Component({
  selector: 'app-studentdetails',
  templateUrl: './studentdetails.component.html',
  styleUrls: ['./studentdetails.component.css']
})
export class StudentdetailsComponent implements OnInit {
  student : Student;
  id:number;

  selection: Selection;
  jap: string;
  newComment = new Comment();
  comments:UserStudent[];

  private sub:any;

  constructor(
    private studentService: StudentsService,
     private route: ActivatedRoute,
    private selectionService:SelectionsService,
    private commentService:CommentsService,
    private accountService:AccountService) {

   }

  ngOnInit(): void {
    this.loadStudent();

  }

    loadStudent(){

      this.sub = this.route.params.subscribe(params=> {
        this.id = +params['id'];
      });

        if(this.accountService.id != 0){
          this.id = this.accountService.id;
        }


      this.studentService.getStudent(this.id).subscribe(student => {
        this.student=student;

        this.selectionService.getSelection(this.student.selectionId).subscribe(selection =>{
          this.selection = selection;
          console.log(selection);

          this.commentService.getCommentsById(this.student.id).subscribe(comments =>{
            this.comments = comments;
            console.log(comments);
          })

        }, error=>console.log(error))
        console.log(this.student);
      }, error => console.log(error));




    }

    addComment(id:number){
      if(this.newComment.comment != ""){
      this.newComment.studentId = this.student.id;
      this.newComment.adminId = 3;
        this.commentService.addNewComment(this.newComment).subscribe(()=>{
          console.log(this.newComment);
        }, error=>console.log(error));
      }
        this.loadStudent();
    }

    deleteComment(id:number){
      this.commentService.deleteComment(id).subscribe(()=>{
        console.log(this.newComment);
      },error=>console.log(error));
      this.loadStudent();
    }


}
