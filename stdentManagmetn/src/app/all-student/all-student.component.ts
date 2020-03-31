import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import{Router} from '@angular/router';

@Component({
    selector: 'all-student',
    templateUrl: 'all-student.component.html',
    styleUrls: ['all-student.component.scss']
})
export class AllStudentComponent implements OnInit{

    result:any;
    constructor(private router:Router,private http:HttpClient){}

    ngOnInit(){
        this.http.get<any>('https://localhost:44347/api/Student').subscribe(res => {
            this.result = res;
        });
    }
   
}
