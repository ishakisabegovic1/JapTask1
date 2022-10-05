import { Component, OnInit } from '@angular/core';
import { Pagination } from '../_models/Pagination';
import { Student } from '../_models/Student';
import { StudentParams } from '../_models/StudentParams';
import { StudentsService } from '../_services/students.service';


@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  students: Student[];
  studentParams: StudentParams;
  nameFilter: string;
  selectionFilter:string;
  statusFilter:string;
  orderby:string;
  pagination: Pagination;
  pageNumber = 1;
  pageSize = 5;

  constructor(private studentService: StudentsService) {
    
   }

  ngOnInit(): void {
    
    this.loadStudents();
  }

  loadStudents(){
    this.studentService.getStudents(this.pageNumber, this.pageSize, this.nameFilter, this.selectionFilter,this.statusFilter, this.orderby).subscribe(response => {
      console.log(response.result);
      this.students = response.result;
      this.pagination = response.pagination;
    }, error => console.log(error));
  }

  deleteStudent(id: number){
   this.studentService.deleteStudent(id).subscribe(student=>{
  console.log(student);
  }, error=>console.log(error));
  this.loadStudents();
  }

  pageChanged(event:any){
    this.pageNumber = event.page;
    this.loadStudents();
  }

  onFilter(){
    console.log(this.nameFilter);
    if(this.nameFilter=="") this.nameFilter=null; 
    if(this.selectionFilter=="") this.selectionFilter=null;
    if(this.statusFilter=="") this.statusFilter=null;
    this.orderby=null;
    this.loadStudents();
  }

  sortName(){
    this.orderby="Name";
    this.loadStudents();
  }

  sortStatus(){
    this.orderby="Status";
    this.loadStudents();
  }
  sortSelection(){
    this.orderby="Selection";
    this.loadStudents();
  }

  
}
