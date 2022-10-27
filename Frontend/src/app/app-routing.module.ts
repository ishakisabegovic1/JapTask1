import { ProgramdetailsComponent } from './programdetails/programdetails.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { StudentsComponent } from './students/students.component';
import { StudentdetailsComponent } from './studentdetails/studentdetails.component';
import { SelectionsComponent } from './selections/selections.component';
import { SelectiondetailsComponent } from './selectiondetails/selectiondetails.component';
import { LoginComponent } from './login/login.component';
import { ProgramsComponent } from './programs/programs.component';
import { StudenteditComponent } from './studentedit/studentedit.component';
import { SelectioneditComponent } from './selectionedit/selectionedit.component';
import { StudentaddComponent } from './studentadd/studentadd.component';
import { SelectionaddComponent } from './selectionadd/selectionadd.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { AdminGuard } from './_guards/admin.guard';
import { StudentGuard } from './_guards/student.guard';
import { AdminreportComponent } from './adminreport/adminreport.component';
import { ItemsComponent } from './items/items.component';
import { ProgramaddComponent } from './programadd/programadd.component';
import { ProgrameditComponent } from './programedit/programedit.component';
import { ProgramitemaddComponent } from './programitemadd/programitemadd.component';
import { ItemaddComponent } from './itemadd/itemadd.component';
import { ItemeditComponent } from './itemedit/itemedit.component';


const routes : Routes = [
  {path:'login', component:LoginComponent},
  {path:'japs', component: ProgramsComponent, canActivate:[AdminGuard]},
  {path: 'program/:id', component: ProgramdetailsComponent, canActivate:[AdminGuard]},
  {path: 'programs/add', component: ProgramaddComponent, canActivate:[AdminGuard]},
  {path: 'programs/edit/:id', component: ProgrameditComponent, canActivate:[AdminGuard]},
  {path: 'programs/:id/add-item', component: ProgramitemaddComponent, canActivate:[AdminGuard]},
  {path:'students', component: StudentsComponent, canActivate:[AdminGuard]},
  {path:'student/:id', component: StudentdetailsComponent, canActivate:[AdminGuard]},
  {path:'stud/profile', component: StudentdetailsComponent, canActivate:[StudentGuard]},
  {path:'student/edit/:id', component: StudenteditComponent, canActivate:[AdminGuard]},
  {path:'students/add', component: StudentaddComponent, canActivate:[AdminGuard]},
  {path:'selections', component: SelectionsComponent, canActivate:[AdminGuard]},
  {path:'selection/:id', component: SelectiondetailsComponent, canActivate:[AdminGuard]},
  {path:'selection/edit/:id', component: SelectioneditComponent, canActivate:[AdminGuard]},
  {path:'selections/add', component:SelectionaddComponent, canActivate:[AdminGuard]},
  {path:'adminreport', component:AdminreportComponent, canActivate:[AdminGuard]},
  {path:'items', component:ItemsComponent, canActivate:[AdminGuard]},
  {path:'item/add-item', component:ItemaddComponent, canActivate:[AdminGuard]},
  {path:'item/edit/:id', component:ItemeditComponent, canActivate:[AdminGuard]},





];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports:[RouterModule]

})
export class AppRoutingModule { }
