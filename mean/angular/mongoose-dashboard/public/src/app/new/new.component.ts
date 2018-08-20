import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {
  newShark = {
    name: "",
    species: "",
    age: "",
    location: "",
    img: ""
  }
  constructor(private _httpService: HttpService) { }

  ngOnInit() {
  }
  createSharkFromService(){
    let observable = this._httpService.createShark(this.newShark)
    observable.subscribe(data => {
      console.log("Creating a shark!", data);
      this.newShark = {
        name: "",
        species: "",
        age: "",
        location: "",
        img: ""
      }
    })
  }
}
