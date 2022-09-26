import { Component, OnInit } from '@angular/core';
import { Jap } from '../_models/Jap';
import { SelectionClass } from '../_models/SelectionClass';
import { JapsService } from '../_services/japs.service';
import { SelectionsService } from '../_services/selections.service';

@Component({
  selector: 'app-selectionadd',
  templateUrl: './selectionadd.component.html',
  styleUrls: ['./selectionadd.component.css']
})
export class SelectionaddComponent implements OnInit {

  selection:SelectionClass = new SelectionClass;
  japs: Jap[];

  constructor(private selectionService:SelectionsService, private japService:JapsService) { }

  ngOnInit(): void {
    this.japService.getJaps().subscribe(jap=>{
      this.japs = jap;
    })
  }
  addSelection(){
    this.selection.id = 0;
    this.selection.jap="";
    this.selectionService.addSelection(this.selection).subscribe(()=>{
      console.log(this.selection);
    },error=>console.log(error));
  }
}
