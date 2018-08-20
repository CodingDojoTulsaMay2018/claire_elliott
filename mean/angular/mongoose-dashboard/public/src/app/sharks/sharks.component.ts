import { HttpService } from './../http.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sharks',
  templateUrl: './sharks.component.html',
  styleUrls: ['./sharks.component.css']
})
export class SharksComponent implements OnInit {
  selectedSharks: any;
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
    this.getSharksFromService();
  }
  getSharksFromService(){
    let observable = this._httpService.getSharks();
    observable.subscribe(data => {
      this.selectedSharks = data;
    });
  }
}
