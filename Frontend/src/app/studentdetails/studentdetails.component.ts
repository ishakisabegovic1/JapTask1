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
import { StudentItem } from '../_models/StudentItem';

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
  studentItems: StudentItem[];
  orderList: number[];


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

      // this.sub = this.route.params.subscribe(params=> {
      //   this.id = +params['id'];
      // });
// popraviti
        if(this.accountService.id != 0){
          this.id = this.accountService.id;
          console.log(this.id);
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
            console.log(this.student.id);
            this.studentService.getStudentProgram(this.student.id).subscribe(response => {
              this.studentItems = response;
              console.log(response);
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
          this.loadStudent();
        }, error=>console.log(error));
      }

    }

    deleteComment(id:number){
      this.commentService.deleteComment(id).subscribe(()=>{
        console.log(this.newComment);
        this.loadStudent();
      },error=>console.log(error));

    }


}
