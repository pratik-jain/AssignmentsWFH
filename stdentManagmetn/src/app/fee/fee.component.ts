import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ActivatedRoute,Route, Router} from '@angular/router';

@Component({
    selector: 'fee',
    templateUrl: 'fee.component.html',
    styleUrls: ['fee.component.scss']
})
export class FeeComponent implements OnInit {
    id;
    feePaid = false;
    feeStatus = "not Paid";
    result:any;
    constructor(private acRoute : ActivatedRoute, private http:HttpClient,private router:Router){}

    ngOnInit(){
        
        this.id = this.acRoute.snapshot.paramMap.get("id");
        this.http.get<any>('https://localhost:44347/api/Fees/'+this.id).subscribe(res => {
            this.result = res;
            console.log(res);  
            if(this.result.FeeStatus == true){
                this.feePaid = true;
                this.feeStatus = "Paid";
            }          
        });
    }
    pay(){
        this.http.put('https://localhost:44347/api/Fees',{studentId:+this.id}).subscribe(res => {
            console.log(res);

            this.router.navigate(['/all']);
        });
    }
}
