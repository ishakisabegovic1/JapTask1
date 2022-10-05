import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from '../_models/Student';
import { Selection } from '../_models/Selection';
import { SelectionsService } from '../_services/selections.service';
import { StudentsService } from '../_services/students.service';

@Component({
  selector: 'app-selectiondetails',
  templateUrl: './selectiondetails.component.html',
  styleUrls: ['./selectiondetails.component.css']
})
export class SelectiondetailsComponent implements OnInit {

  selection : Selection;
  id:number;
  students: Student[];
  
  jap: string;
  
  private sub:any;

  constructor( private selectionService:SelectionsService , private studentsService: StudentsService, private route: ActivatedRoute) {
    
   }

  ngOnInit(): void {
    this.loadSelection();
    
  }

    loadSelection(){
      this.sub = this.route.params.subscribe(params=> {
        this.id = +params['id'];
      });

      this.selectionService.getSelection(this.id).subscribe(selection => {        
        this.selection=selection;    

        this.studentsService.getStudentsBySelectionId(this.selection.id).subscribe(students =>{
          this.students = students;
          console.log(students);
         
        }, error=>console.log(error))      
        console.log(this.selection);
      }, error => console.log(error));    

      
            
      
    }

}
