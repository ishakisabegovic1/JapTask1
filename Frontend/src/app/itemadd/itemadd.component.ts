
import { ItemsService } from './../_services/items.service';
import { Component, OnInit } from '@angular/core';
import { ItemClass } from '../_models/ItemClass';

@Component({
  selector: 'app-itemadd',
  templateUrl: './itemadd.component.html',
  styleUrls: ['./itemadd.component.css']
})
export class ItemaddComponent implements OnInit {
  item = new ItemClass;
  constructor(private itemService: ItemsService) { }

  ngOnInit(): void {

  }

  addItem(){
    this.itemService.addItem(this.item).subscribe(response=>{
      console.log(response);
    });
  }

}
