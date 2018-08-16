import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-tulsa',
  templateUrl: './tulsa.component.html',
  styleUrls: ['./tulsa.component.css']
})
export class TulsaComponent implements OnInit {
  weather: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    let observable = this._httpService.getWeather(4553433);
    observable.subscribe(data => {
      console.log("Got data! ", data);
      this.weather = data;
    })
  }

}
