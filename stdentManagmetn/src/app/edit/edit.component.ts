import { Component, OnInit } from "@angular/core";
import{Router,ActivatedRoute} from "@angular/router";
import {HttpClient} from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: "app-edit",
  templateUrl: "./edit.component.html",
  styleUrls: ["./edit.component.scss"]
})

export class EditComponent implements OnInit {
  formGroup : FormGroup;
  id:any;
  constructor(private builder:FormBuilder, private activatedRoute:ActivatedRoute,private http:HttpClient,private router:Router) { 

  }

  ngOnInit() {
    this.id = this.activatedRoute.snapshot.paramMap.get("id");
    console.log("sajfh"+this.id);
    this.formGroup = this.builder.group({
      name:[' ',Validators.required],
      mobile:['',Validators.required]
    });
  }
  submit(){
    console.log(this.formGroup.value.name+"  ");
    console.log()
    this.http.put("https://localhost:44347/api/Student",{studentId:+this.id,studentName:this.formGroup.value.name,mobile:this.formGroup.value.mobile}).subscribe(res => {
      console.log(res);
      this.router.navigate(['/all']);
    });
  }
}
