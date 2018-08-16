import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-tokyo',
  templateUrl: './tokyo.component.html',
  styleUrls: ['./tokyo.component.css']
})
export class TokyoComponent implements OnInit {
  weather: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    let observable = this._httpService.getWeather(1850147);
    observable.subscribe(data => {
      console.log("Got data! ", data);
      this.weather = data;
    })
  }

}
