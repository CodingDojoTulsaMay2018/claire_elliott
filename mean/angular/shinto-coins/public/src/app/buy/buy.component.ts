import { HttpService } from './../http.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html',
  styleUrls: ['./buy.component.css']
})
export class BuyComponent implements OnInit {
  wallet = this._httpService.wallet;
  coinRate = this._httpService.coinRate;
  amount: number;
  constructor(private _httpService: HttpService) { }
  ngOnInit() {
  }
  buyCoins(){
    
  }
}
