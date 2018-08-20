import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private _http: HttpClient) { }
  getSharks(){
    return this._http.get('/sharks');
  }
  getShark(shark){
    return this._http.get('/sharks/' + shark);
  }
  createShark(shark){
    return this._http.post('/sharks', shark);
  }
  updateShark(shark){
    return this._http.put('/sharks/' + shark._id, shark);
  }
  deleteShark(shark){
    return this._http.delete('/sharks/' + shark._id);
  }
}
