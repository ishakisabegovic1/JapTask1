import { Jap } from './../_models/Jap';
import { ProgramItemUpsert } from './../_models/ProgramItemUpsert';
import { ActivatedRoute } from '@angular/router';
import { JapsService } from './../_services/japs.service';
import { Component, OnInit } from '@angular/core';
import { ItemsService } from '../_services/items.service';
import { Item } from '../_models/Item';
import { Pagination } from '../_models/Pagination';

@Component({
  selector: 'app-programitemadd',
  templateUrl: './programitemadd.component.html',
  styleUrls: ['./programitemadd.component.css']
})
export class ProgramitemaddComponent implements OnInit {
  private sub:any;
  id:number;
  items: Item[];
  program: Jap;
  programItem = new ProgramItemUpsert();
  pagination: Pagination;
  constructor(private programService: JapsService, private route:ActivatedRoute, private itemService:ItemsService) { }

  ngOnInit(): void {

    this.itemService.getItems().subscribe(response =>{
      this.items = response.result;
      this.pagination = response.pagination;
    })



    this.sub = this.route.params.subscribe(params=> {
      this.id = +params['id'];
    });
    this.programItem.programId = this.id;

    this.programService.getProgramById(this.id).subscribe(response=>{
      this.program = response;
    });
  }

  addProgramItem(){
    this.programService.addProgramItem(this.programItem).subscribe(response=>{
      console.log(response);
    })
  }




}
