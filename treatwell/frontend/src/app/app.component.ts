import { Component, OnInit } from '@angular/core';
import { ApiService } from './api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'frontend';
  id;
  user;
   customer: any;
  constructor(private apiService : ApiService){

  }

  

  ngOnInit(){
this.getCustomer();
  }

  getCustomerByid(){
    this.apiService.getCustomer(this.id).subscribe(data=>{
      console.log(data);
      this.customer = data;
    },error=>{
      console.log(error);
    }
      )  }

  getCustomer(){
this.apiService.getCustomer('islamabad,pk').subscribe(data=>{
  console.log(data);
  this.customer = data;
},error=>{
  console.log(error);
}
  )  }
}
