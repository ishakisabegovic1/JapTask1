import { ActivatedRoute } from '@angular/router';
import { ItemClass } from './../_models/ItemClass';
import { Component, OnInit } from '@angular/core';
import { ItemsService } from '../_services/items.service';
import { Item } from '../_models/Item';

@Component({
  selector: 'app-itemedit',
  templateUrl: './itemedit.component.html',
  styleUrls: ['./itemedit.component.css']
})
export class ItemeditComponent implements OnInit {
  item: Item;
  private sub:any;
  id:number;

  constructor(private itemService: ItemsService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadItem();
  }

  loadItem(){
    this.sub = this.route.params.subscribe(params=> {
      this.id = +params['id'];
    });

    this.itemService.getItemById(this.id).subscribe(response => {
      this.item = response;
    });
  }
  editItem(){
    this.itemService.editItem(this.item).subscribe(response=>{
      console.log(response);
    })
  }
}
