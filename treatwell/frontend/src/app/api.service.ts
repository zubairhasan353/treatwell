import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from './Customer';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiURL: string = 'http://localhost:59261/api/CustomerProfile?UserId=23909c0a-6dbf-4cf6-950e-787bb932acce';

  constructor(private httpClient: HttpClient) {}

  public getCustomer(id){
    return this.httpClient.get('http://localhost:59261/api/CustomerProfile?UserId=23909c0a-6dbf-4cf6-950e-787bb932acce');
  }
  
}


//http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=42657f9d58edc3d48b3df5e84cf7cf07
