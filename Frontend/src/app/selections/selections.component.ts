import { Component, OnInit } from '@angular/core';
import { SelectionsService } from '../_services/selections.service';
import {Selection} from '../_models/Selection';
import { Pagination } from '../_models/Pagination';

@Component({
  selector: 'app-selections',
  templateUrl: './selections.component.html',
  styleUrls: ['./selections.component.css']
})
export class SelectionsComponent implements OnInit {
  nameFilter:string;
  japFilter:string;
  statusFilter:string;
  startDateFilter:Date;
  endDateFilter:Date;
  orderBy:string;
  selections: Selection[];
  pagination: Pagination;
  pageNumber = 1;
  pageSize = 5;

  constructor(private selectionService: SelectionsService) { }

  ngOnInit(): void {
    this.loadSelections();
  }

  loadSelections(){
    this.selectionService.getSelectionsP(this.pageNumber,this.pageSize, this.nameFilter,this.japFilter,
       this.statusFilter, this.orderBy, this.startDateFilter, this.endDateFilter)
    .subscribe(response => {
      console.log(response.result);
      this.selections = response.result;
      this.pagination = response.pagination;
    }, error => console.log(error));
  }

  deleteSelection(id:number){
    this.selectionService.deleteSelection(id).subscribe(selection=>{
      console.log(selection);
    },error=>console.log(error));

    this.loadSelections();
  }

  pageChanged(event:any){
    this.pageNumber = event.page;
    this.loadSelections();
  }

  onFilter(){
    if(this.nameFilter=="") this.nameFilter = null;
    if(this.japFilter=="")this.japFilter = null;
    if(this.statusFilter=="")this.statusFilter = null;
    
    // if startDateFilter is clear it should be set to null here, so it doesnt go to selections service 
    this.orderBy = null;
    this.loadSelections();
  }

  sortStatus(){
    this.orderBy = "Status";
    
    this.loadSelections();
  }

  sortName(){
    this.orderBy = "Name";
    this.loadSelections();
  }

  sortJap(){
    this.orderBy = "Jap";
    this.loadSelections();

  }
  sortStartDate(){
    this.orderBy = "StartDate";
    this.loadSelections();

  }
  sortEndDate(){
    this.orderBy = "EndDate";
    this.loadSelections();

  }

}
