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
  constructor(public adminService: AdminService) { }

  ngOnInit(): void {
    this.loadReports();
  }

  loadReports(){
    this.adminService.getAdminReport().subscribe(response => {
      this.report = response;
      console.log(response);
    })
  }

}
