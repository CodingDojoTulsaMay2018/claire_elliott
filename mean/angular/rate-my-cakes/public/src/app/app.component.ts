import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'public';
  selectedPokes = [];
  selectedPoke: any;
  newPoke: any;
  newRating = {
    comment: "",
    star: 1
  }
  constructor(private _httpService: HttpService) {}

  ngOnInit(){
    this.getPokesFromService();
    this.newPoke = {
      name: "",
      species: "",
      trainer: "",
      url: ""
    }
  }

  getPokesFromService(){
    let observable = this._httpService.getPokes();
    observable.subscribe(data => {
      console.log("Got all Pokemon", data);
      this.selectedPokes = data.pokes;
    });
  }
  createPokeFromService(){
    let observable = this._httpService.createPoke(this.newPoke);
    observable.subscribe(data => {
      console.log("Create a Pokemon", data);
      if (data.error) {
        if (data.error.errors.name) {
          this.errors.push(data.error.errors.name.message);
        }
        if (data.error.errors.species) {
          this.errors.push(data.error.errors.species.message);
        }
      }else{
        this.ngOnInit();
        this.newPoke = {
          name: "",
          species: "",
          trainer: "",
          url: ""
        }
      }
    });
  }
  updatePokeFromService(poke){
    console.log(poke)
    let observable = this._httpService.updatePoke(poke, this.newRating);
    observable.subscribe(data => {
      console.log("Update a Pokemon", data);
      if (data.error){
        console.log(data.error);
      }else{
        this.ngOnInit();
        this.newRating = {
          comment: "",
          star: 0
        }
      }
    });
  }
  pokeToShow(poke){
    this.selectedPoke = poke;
  }
}