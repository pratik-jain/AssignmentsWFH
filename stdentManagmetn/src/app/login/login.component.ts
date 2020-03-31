import { Component, OnInit } from '@angular/core';
import {ReactiveFormsModule, FormGroup, FormBuilder, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import { HttpClient} from '@angular/common/http';

@Component({
    selector: 'login',
    templateUrl: 'login.component.html',
    styleUrls: ['login.component.scss']
})
export class LoginComponent implements OnInit {
  formGroup: FormGroup;
  result: any;
  constructor(private builder: FormBuilder, private router: Router, private http: HttpClient) {
  }


  ngOnInit(): void {
    this.formGroup = this.builder.group({
        email: ['', Validators.required],
        password: ['', Validators.required]
    });   
  }

  logIn() {
     this.http.post<any>('https://localhost:44347/api/login',{email: this.formGroup.value.email, password: this.formGroup.value.password}).subscribe(res => {
         console.log(res);
         if(res != 0){
            this.router.navigate(['/all']);
         }
         else{
           alert("wrong id pass");
         }
     });


  }
}
