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
  createTasks(fields){
    // our http response is an observable, store it in the variable tempObservable
    let tempObservable = this._http.post('/tasks/', {"title": "null!", "description": "I'm a null"});
    // subscribe to our observable and provide the code we would like to do with our data from the response
    tempObservable.subscribe(data => console.log("Updating a task!", data));
  }
  displayTasks(id){
    // our http response is an observable, store it in the variable tempObservable
    let tempObservable = this._http.get('/tasks/' + id);
    // subscribe to our observable and provide the code we would like to do with our data from the response
    tempObservable.subscribe(data => console.log("Viewing a task!", data));
  }
  updateTasks(id, fields){
    // our http response is an observable, store it in the variable tempObservable
    let tempObservable = this._http.put('/tasks/' + id, fields);
    // subscribe to our observable and provide the code we would like to do with our data from the response
    tempObservable.subscribe(data => console.log("Updating a task!", data));
  }
  deleteTasks(id){
    // our http response is an observable, store it in the variable tempObservable
    let tempObservable = this._http.delete('/tasks/' + id);
    // subscribe to our observable and provide the code we would like to do with our data from the response
    tempObservable.subscribe(data => console.log("Deleting a task!", data));
  }
}
