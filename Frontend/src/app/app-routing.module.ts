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
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AdminGuard } from './_guards/admin.guard';
import { StudentGuard } from './_guards/student.guard';


const routes : Routes = [
  {path:'login', component:LoginComponent},
  {path:'japs', component: JapsComponent, canActivate:[AdminGuard]},
  {path:'students', component: StudentsComponent},
  {path:'student/:id', component: StudentdetailsComponent},
  {path:'student/edit/:id', component: StudenteditComponent, canActivate:[AdminGuard]},  
  {path:'students/add', component: StudentaddComponent, canActivate:[AdminGuard]},  
  {path:'selections', component: SelectionsComponent, canActivate:[AdminGuard]},
  {path:'selection/:id', component: SelectiondetailsComponent, canActivate:[AdminGuard]},
  {path:'selection/edit/:id', component: SelectioneditComponent, canActivate:[AdminGuard]},
  {path:'selections/add', component:SelectionaddComponent, canActivate:[AdminGuard]},
  {path:'admin', component:AdminPanelComponent, canActivate:[AdminGuard]},
  
 // {path:'**', component: LoginComponent, pathMatch: 'full'}

];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports:[RouterModule]
  
})
export class AppRoutingModule { }
