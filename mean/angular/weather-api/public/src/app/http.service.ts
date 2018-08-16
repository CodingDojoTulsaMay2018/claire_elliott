import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private _http: HttpClient) {

  }
  getWeather(id){
    return this._http.get(`https://api.openweathermap.org/data/2.5/forecast?id=${id}&units=imperial&appid=33063196c2d62c14efdd47b18ce008ab`);
  }
}