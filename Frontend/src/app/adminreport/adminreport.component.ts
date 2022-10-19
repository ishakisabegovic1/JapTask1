import { Component, OnInit } from '@angular/core';
import { AdminReport } from '../_models/AdminReport';
import { AdminService } from '../_services/admin.service';

@Component({
  selector: 'app-adminreport',
  templateUrl: './adminreport.component.html',
  styleUrls: ['./adminreport.component.css']
})
export class AdminreportComponent implements OnInit {
  report: AdminReport[];
  numberOfSt: number;
  overall: number;
  constructor(public adminService: AdminService) { }

  ngOnInit(): void {
    this.overall = 0;
    this.numberOfSt = 0;
    this.loadReports();

  }

  loadReports(){
    this.adminService.getAdminReport().subscribe(response => {
      this.report = response;
      console.log(response);

       this.numberOfStudents();


    })


  }

  numberOfStudents(){
    if(this.report != null){
    this.report.forEach(el=>{
      this.numberOfSt += el.numberOfStudents;
    })
    console.log(this.numberOfSt);
    this.overallSuccess();
  }
  }

  overallSuccess(){
    this.report.forEach(el => {
      this.overall +=  el.numberOfSuccess;
    });
    console.log(this.overall);
    this.overall = this.overall / this.numberOfSt;
    // this.overall *= 100.00;

    this.overall = Math.round(this.overall*10000)/100;

  }



}
