import { Component, OnInit } from '@angular/core';
import { Jap } from '../_models/Jap';
import { JapsService } from '../_services/japs.service';

@Component({
  selector: 'app-japs',
  templateUrl: './programs.component.html',
  styleUrls: ['./programs.component.css']
})
export class ProgramsComponent implements OnInit {
  japs: Jap[];
  constructor(private japService:JapsService) { }

  ngOnInit(): void {
    this.loadJaps();
  }

  loadJaps(){
    this.japService.getJaps().subscribe(japs => {
      console.log(japs);
      this.japs = japs;
    })
  }

  deleteProgram(id: number){
    this.japService.deleteProgram(id).subscribe(response=>{
      console.log(response);
    })
  }
}
