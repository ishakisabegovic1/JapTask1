import { Component, OnInit } from '@angular/core';
import { Jap } from '../_models/Jap';
import { JapsService } from '../_services/japs.service';

@Component({
  selector: 'app-japs',
  templateUrl: './japs.component.html',
  styleUrls: ['./japs.component.css']
})
export class JapsComponent implements OnInit {
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
}
