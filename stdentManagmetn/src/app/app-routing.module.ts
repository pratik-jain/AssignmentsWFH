import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {FeeComponent} from './fee/fee.component';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';
import {AllStudentComponent} from './all-student/all-student.component';
import {EditComponent} from './edit/edit.component';

const routes: Routes = [
  {path:'fee/:id',component:FeeComponent},
  {path:'',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'all',component:AllStudentComponent},
  {path:'edit/:id',component:EditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
