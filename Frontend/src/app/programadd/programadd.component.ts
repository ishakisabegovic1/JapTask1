import { ProgramItemUpsert } from './../_models/ProgramItemUpsert';
import { ItemsService } from './../_services/items.service';
import { JapsService } from './../_services/japs.service';
import { Component, OnInit } from '@angular/core';
import { ProgramClass } from '../_models/ProgramClass';
import { Item } from '../_models/Item';
import { Pagination } from '../_models/Pagination';

@Component({
  selector: 'app-programadd',
  templateUrl: './programadd.component.html',
  styleUrls: ['./programadd.component.css']
})
export class ProgramaddComponent implements OnInit {
  program = new ProgramClass;
  programItem = new ProgramItemUpsert;
  items: Item[];
  pagination: Pagination;
  constructor(private programService: JapsService, private itemService: ItemsService) { }

  ngOnInit(): void {
    this.itemService.getItems().subscribe(response =>{
      this.items = response.result;

    })
  }

  addProgram(){
    this.programService.addProgram(this.program).subscribe(response=>{
      console.log(response);
          if(this.programItem){
            console.log(response.id);
            this.programItem.programId = response.id;
          this.programService.addProgramItem(this.programItem).subscribe(resp=>{
            console.log(resp);
          }
          , error=> console.log(error));
        }

    }, error => console.log(error));

  }

}
