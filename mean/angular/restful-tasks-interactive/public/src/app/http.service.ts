import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private _http: HttpClient){
  }
  getTasks(){
    // our http response is an observable, store it in the variable tempObservable
    return this._http.get('/tasks');
  }
}
