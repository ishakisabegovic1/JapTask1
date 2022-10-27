import { JapsService } from './../_services/japs.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProgramItem } from '../_models/ProgramItem';

@Component({
  selector: 'app-programdetails',
  templateUrl: './programdetails.component.html',
  styleUrls: ['./programdetails.component.css']
})
export class ProgramdetailsComponent implements OnInit {
  private sub:any;
  id:number;
  programItems: ProgramItem[];
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
    })
  }
}
