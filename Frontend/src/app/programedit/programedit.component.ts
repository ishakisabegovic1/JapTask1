import { JapsService } from './../_services/japs.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ProgramClass } from '../_models/ProgramClass';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-programedit',
  templateUrl: './programedit.component.html',
  styleUrls: ['./programedit.component.css']
})
export class ProgrameditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  program = new ProgramClass;
  id: number;
  private sub:any;
  constructor(private programService:JapsService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProgram();
  }

  loadProgram(){
    this.sub = this.route.params.subscribe(params=> {
      this.id = +params['id'];
    });

    this.programService.getProgramById(this.id).subscribe(response => {
      console.log(response);
      this.program = response;
    })


  }

  editProgram(){
    this.programService.editProgram(this.program).subscribe(response=>{
      this.editForm.reset(this.program);
    });
  }

}
