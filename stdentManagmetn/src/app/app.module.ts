import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {ReactiveFormsModule, FormsModule} from '@angular/forms';
import {Router} from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FeeComponent} from './fee/fee.component';
import {LoginComponent} from './login/login.component';
import {RegisterComponent} from './register/register.component';
import {AllStudentComponent} from './all-student/all-student.component';
import {EditComponent} from './edit/edit.component';

@NgModule({
  declarations: [
    AppComponent, FeeComponent, LoginComponent, RegisterComponent, AllStudentComponent,EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, ReactiveFormsModule, FormsModule, HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
