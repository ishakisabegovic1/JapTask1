import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { StudentsComponent } from './students/students.component';
import { StudentdetailsComponent } from './studentdetails/studentdetails.component';
import { SelectionsComponent } from './selections/selections.component';
import { SelectiondetailsComponent } from './selectiondetails/selectiondetails.component';
import { AppRoutingModule } from './app-routing.module';
import { ProgramsComponent } from './programs/programs.component';
import { StudenteditComponent } from './studentedit/studentedit.component';
import { SelectioneditComponent } from './selectionedit/selectionedit.component';
import { StudentaddComponent } from './studentadd/studentadd.component';
import { SelectionaddComponent } from './selectionadd/selectionadd.component';
import {PaginationModule} from 'ngx-bootstrap/pagination';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/has-role.directive';
import { AdminreportComponent } from './adminreport/adminreport.component';
import { ItemsComponent } from './items/items.component';
import { ProgramdetailsComponent } from './programdetails/programdetails.component';
import { ProgramaddComponent } from './programadd/programadd.component';
import { ProgrameditComponent } from './programedit/programedit.component';
import { ProgramitemaddComponent } from './programitemadd/programitemadd.component';
import { ItemaddComponent } from './itemadd/itemadd.component';
import { ItemeditComponent } from './itemedit/itemedit.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    StudentsComponent,
    StudentdetailsComponent,
    SelectionsComponent,
    SelectiondetailsComponent,
    ProgramsComponent,
    StudenteditComponent,
    SelectioneditComponent,
    StudentaddComponent,
    SelectionaddComponent,
    AdminPanelComponent,
    HasRoleDirective,
    AdminreportComponent,
    ItemsComponent,
    ProgramdetailsComponent,
    ProgramaddComponent,
    ProgrameditComponent,
    ProgramitemaddComponent,
    ItemaddComponent,
    ItemeditComponent,

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    PaginationModule.forRoot(),

  ],
  exports: [
    PaginationModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
