import { ItemsService } from './../_services/items.service';
import { Component, OnInit } from '@angular/core';
import { Item } from '../_models/Item';
import { Pagination } from '../_models/Pagination';
import { summaryForJitName } from '@angular/compiler/src/aot/util';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {
  items: Item[];
  nameFilter:string;
  descFilter:string;
  urlFilter:string;
  orderBy:string;
  pagination: Pagination;
  pageNumber = 1;
  pageSize = 5;

  constructor(private itemService: ItemsService) { }

  ngOnInit(): void {
    this.loadItems();
  }
  loadItems(){
    this.itemService.getItems(
      this.pageNumber, this.pageSize,
      this.nameFilter, this.descFilter,
       this.urlFilter, this.orderBy)
       .subscribe(response => {
      this.items = response.result;
      this.pagination = response.pagination;
      console.log(response);
    })
  }

  pageChanged(event:any){
    this.pageNumber = event.page;
    this.loadItems();
  }

  onFilter(){
    if(this.nameFilter == "") this.nameFilter = null;
    if(this.descFilter == "") this.descFilter = null;
    if(this.urlFilter == "") this.urlFilter = null;
    this.orderBy = null;
    this.loadItems();
  }

  deleteItem(id:number){
    this.itemService.deleteItem(id).subscribe(response=>{
      console.log(response);
    })

  }

  sortName(){
    this.orderBy = "Name";
    this.loadItems();
  }

  sortDesc(){
    this.orderBy = "Desc";
    this.loadItems();
  }

  sortUrl(){
    this.orderBy = "Url";
    this.loadItems();
  }

  sortHours(){
    this.orderBy ="Hours";
    this.loadItems();
  }





}
