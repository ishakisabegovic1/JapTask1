import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { JapsService } from '../_services/japs.service';
import { SelectionsService } from '../_services/selections.service';
import { Selection } from '../_models/Selection';
import { Jap } from '../_models/Jap';
@Component({
  selector: 'app-selectionedit',
  templateUrl: './selectionedit.component.html',
  styleUrls: ['./selectionedit.component.css']
})
export class SelectioneditComponent implements OnInit {
  selection:Selection;
  japs:Jap[];
  id:number;
  private sub:any;
  constructor(private selectionService:SelectionsService, private route: ActivatedRoute, private japService:JapsService) { }

  ngOnInit(): void {
    this.loadSelection();
  }

  loadSelection(){
    this.sub = this.route.params.subscribe(params=> {
      this.id = +params['id'];
    });

    this.selectionService.getSelection(this.id).subscribe(selection=>{
      this.selection = selection;
      console.log(selection);
      this.japService.getJaps().subscribe(japs=>{
        this.japs=japs;
      })
      
    })


  }

  updateSelection(){
    this.selectionService.updateSelection(this.selection).subscribe(()=>{
      console.log(this.selection);
    },error=>console.log(error));
  }

  deleteSelection(){

    
  }



}
