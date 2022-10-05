import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { StudentsComponent } from './students/students.component';
import { StudentdetailsComponent } from './studentdetails/studentdetails.component';
import { SelectionsComponent } from './selections/selections.component';
import { SelectiondetailsComponent } from './selectiondetails/selectiondetails.component';
import { LoginComponent } from './login/login.component';
import { JapsComponent } from './japs/japs.component';
import { StudenteditComponent } from './studentedit/studentedit.component';
import { SelectioneditComponent } from './selectionedit/selectionedit.component';
import { StudentaddComponent } from './studentadd/studentadd.component';
import { SelectionaddComponent } from './selectionadd/selectionadd.component';


const routes : Routes = [
  {path:'login', component:LoginComponent},
  {path:'japs', component: JapsComponent},
  {path:'students', component: StudentsComponent},
  {path:'student/:id', component: StudentdetailsComponent},
  {path:'student/edit/:id', component: StudenteditComponent},  
  {path:'students/add', component: StudentaddComponent},  
  {path:'selections', component: SelectionsComponent},
  {path:'selection/:id', component: SelectiondetailsComponent},
  {path:'selection/edit/:id', component: SelectioneditComponent},
  {path:'selections/add', component:SelectionaddComponent}
  
 // {path:'**', component: LoginComponent, pathMatch: 'full'}

];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports:[RouterModule]
  
})
export class AppRoutingModule { }
