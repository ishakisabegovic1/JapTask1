import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Selection } from '../_models/Selection';
import { Student } from '../_models/Student';
import { SelectionsService } from '../_services/selections.service';
import { StudentsService } from '../_services/students.service';
import { NgForm } from '@angular/forms';
import { StudentClass } from '../_models/StudentClass';

@Component({
  selector: 'app-studentadd',
  templateUrl: './studentadd.component.html',
  styleUrls: ['./studentadd.component.css']
})
export class StudentaddComponent implements OnInit {
  student = new StudentClass();
  selections:Selection[];
  


  constructor(private studentService:StudentsService, private route: ActivatedRoute, private selectionService:SelectionsService) {
    
   }

  ngOnInit(): void {
    this.selectionService.getSelections().subscribe(selections=>{
      console.log(selections);
      this.selections = selections;
    });
  }

  addStudent(){
    console.log(this.student);
    this.student.id=0;
    this.student.selection='string';
    this.studentService.addStudent(this.student).subscribe(()=>
    {
      console.log(this.student);
    }, error=> console.log(error))
  }

}
