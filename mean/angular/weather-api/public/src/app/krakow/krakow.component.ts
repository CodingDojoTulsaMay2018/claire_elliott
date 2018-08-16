import { HttpService } from './../http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-krakow',
  templateUrl: './krakow.component.html',
  styleUrls: ['./krakow.component.css']
})
export class KrakowComponent implements OnInit {
  weather: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    let observable = this._httpService.getWeather(3094802);
    observable.subscribe(data => {
      console.log("Got data! ", data);
      this.weather = data;
    })
  }
}
