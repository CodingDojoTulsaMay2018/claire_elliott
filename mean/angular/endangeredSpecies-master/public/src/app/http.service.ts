import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private _http: HttpClient) {

  }
  getAnimals(){
    return this._http.get('/animals');
  }
  createAnimals(animal){
    return this._http.post('/animals', animal);

  }
  getAnimal(animal){
    return this._http.get('/animals/' + animal);

  }
}