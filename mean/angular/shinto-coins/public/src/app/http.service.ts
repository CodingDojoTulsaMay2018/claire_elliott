import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class HttpService {
  wallet = 0;
  history = [];
  coinRate = 1;
  constructor(private _http: HttpClient) { }

  getQuestions(){
    return this._http.get('https://opentdb.com/api.php?amount=1&category=19&difficulty=medium');
  }
}
