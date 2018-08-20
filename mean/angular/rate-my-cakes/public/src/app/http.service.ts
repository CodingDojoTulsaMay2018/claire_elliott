import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private _http: HttpClient) {

  }
  getPokes(){
    return this._http.get('/pokemon');
  }
  getPoke(poke){
    return this._http.get('/pokemon/' + poke);
  }
  createPoke(poke){
    return this._http.post('/pokemon', poke);
  }
  updatePoke(poke, rating){
    return this._http.put('/pokemon/' + poke._id, rating);
  }
}