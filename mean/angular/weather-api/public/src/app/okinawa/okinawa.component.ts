import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-okinawa',
  templateUrl: './okinawa.component.html',
  styleUrls: ['./okinawa.component.css']
})
export class OkinawaComponent implements OnInit {
  weather: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    let observable = this._httpService.getWeather(1894616);
    observable.subscribe(data => {
      console.log("Got data! ", data);
      this.weather = data;
    })
  }

}
