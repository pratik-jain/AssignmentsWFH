import { Component, OnInit } from '@angular/core';
import {ReactiveFormsModule,FormGroup,FormBuilder, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
    selector: 'register',
    templateUrl: 'register.component.html',
    styleUrls: ['register.component.scss']
})
export class RegisterComponent implements OnInit {

    formGroup:FormGroup;
    constructor(private builder:FormBuilder,private http:HttpClient, private router: Router) {
        
    }

    ngOnInit(){
        this.formGroup = this.builder.group({
            userName:['',Validators.required],
            email:['',Validators.required],
            mobile:['',Validators.required],
            password:['',Validators.required],
            course:['Courses',Validators.required],
        });
    }

    submit(){
        this.http.post<any>('https://localhost:44347/api/Student',{studentName:this.formGroup.value.userName,
        email:this.formGroup.value.email,mobile:this.formGroup.value.mobile
        ,password:this.formGroup.value.password,courseId:1}).subscribe(res => { 
            console.log(res);
            sessionStorage.setItem('user',JSON.stringify(res));
            this.router.navigate(['/all']);
        });
    }
}
