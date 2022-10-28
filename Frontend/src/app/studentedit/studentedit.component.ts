import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from '../_models/Student';
import { SelectionsService } from '../_services/selections.service';
import { StudentsService } from '../_services/students.service';
import { Selection } from '../_models/Selection';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-studentedit',
  templateUrl: './studentedit.component.html',
  styleUrls: ['./studentedit.component.css']
})
export class StudenteditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  student:Student;
  id:number;

  selection: Selection;
  selections: Selection[];
  jap: string;

  private sub:any;

  constructor(private studentService:StudentsService, private route: ActivatedRoute, private selectionService:SelectionsService) {

   }

  ngOnInit(): void {
    this.loadStudent();
    this.selectionService.getSelections().subscribe(selections=>{
      console.log(selections);
      this.selections = selections;
    });
  }

  loadStudent(){
    this.sub = this.route.params.subscribe(params=> {
      this.id = +params['id'];
    });

    this.studentService.getStudent(this.id).subscribe(student => {
      this.student=student;

      this.selectionService.getSelection(this.student.selectionId).subscribe(selection =>{
        this.selection = selection;
        console.log(selection);

      }, error=>console.log(error))
      console.log(this.student);
    }, error => console.log(error));
  }

  updateStudent(){

    this.studentService.updateStudent(this.student).subscribe(response=>{
      console.log(this.student);
      console.log(response);
      this.editForm.reset(this.student);
    }, error => console.log(error))

  }


}
