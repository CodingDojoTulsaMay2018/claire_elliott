import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-hiroshima',
  templateUrl: './hiroshima.component.html',
  styleUrls: ['./hiroshima.component.css']
})
export class HiroshimaComponent implements OnInit {
  weather: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    let observable = this._httpService.getWeather(1862415);
    observable.subscribe(data => {
      console.log("Got data! ", data);
      this.weather = data;
    })
  }

}
