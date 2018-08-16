import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-kumamoto',
  templateUrl: './kumamoto.component.html',
  styleUrls: ['./kumamoto.component.css']
})
export class KumamotoComponent implements OnInit {
  weather: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    let observable = this._httpService.getWeather(1858419);
    observable.subscribe(data => {
      console.log("Got data! ", data);
      this.weather = data;
    })
  }

}
