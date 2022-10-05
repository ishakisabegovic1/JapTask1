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
import { JapsComponent } from './japs/japs.component';
import { StudenteditComponent } from './studentedit/studentedit.component';
import { SelectioneditComponent } from './selectionedit/selectionedit.component';
import { StudentaddComponent } from './studentadd/studentadd.component';
import { SelectionaddComponent } from './selectionadd/selectionadd.component';
import {PaginationModule} from 'ngx-bootstrap/pagination';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    LoginComponent,
    StudentsComponent,
    StudentdetailsComponent,
    SelectionsComponent,
    SelectiondetailsComponent,
    JapsComponent,
    StudenteditComponent,
    SelectioneditComponent,
    StudentaddComponent,
    SelectionaddComponent,    
    
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
