import { JapsService } from './../_services/japs.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProgramItem } from '../_models/ProgramItem';
import { ProgramItemUpsert } from '../_models/ProgramItemUpsert';

@Component({
  selector: 'app-programdetails',
  templateUrl: './programdetails.component.html',
  styleUrls: ['./programdetails.component.css']
})
export class ProgramdetailsComponent implements OnInit {
  private sub:any;
  id:number;
  programItems: ProgramItem[];
  newOrderNumber: number;
  count: number;
  constructor(private programService: JapsService,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadProgramDetails();
  }

  loadProgramDetails(){
    this.sub = this.route.params.subscribe(params=> {
      this.id = +params['id'];
    });
    this.programService.getProgramDetails(this.id).subscribe(response=>{
      console.log(response);
      this.programItems = response;
      this.count = this.programItems.length;
    })
  }

  createRange(number){
    // return new Array(number);
    return new Array(number).fill(0)
      .map((n, index) => index + 1);
  }

  updateProgramItem(programItem: ProgramItemUpsert, newOrderN: number){
    this.programService.updateProgramItem(programItem, this.newOrderNumber).subscribe(response=>{
      console.log(response);
      console.log(programItem);
      console.log(this.newOrderNumber);
      this.loadProgramDetails();
    },error => {
      console.log(error);
    })

  }
}
