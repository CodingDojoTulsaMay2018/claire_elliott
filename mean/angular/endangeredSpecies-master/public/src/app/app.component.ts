import { Component, OnInit } from '@angular/core';
import { HttpService } from './http.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  newAnimal: any;
  constructor(private _httpService: HttpService){
  }
    // ngOnInit will run when the component is initialized, after the constructor method.
    ngOnInit(){
      this.getAnimalsFromService();
      this.newAnimal = { name: "", population: ""};
    }
    animals: any;
    animal: any;
    name: string;
    population: number;
    errors: any;
    shouldDisplaySection: boolean;
    onSubmit(){
      this.errors = [];
      let observable = this._httpService.createAnimals(this.newAnimal);
      observable.subscribe(data => {
        console.log("Created new animal!", data);
        if(data.errors){
            if(data.errors.name){
              this.errors.push(data.errors.name.message);
            }
            if(data.errors.population){
              this.errors.push(data.errors.population.message);
            }
          }
          
        this.newAnimal = { name: "", population: ""};
      });
      this.getAnimalsFromService();
    }
    getAnimalsFromService(){
      let observable = this._httpService.getAnimals();
      observable.subscribe(data => {
        console.log("Got our animals!", data);
        this.animals = data;
      });
    }

    onButtonClick(animal){
      this.animal = animal;
      console.log("Button clicked!");
    }
    hideSection($event){
      $event.stopPropagation();
      this.shouldDisplaySection = false;
    }
    showSection(animal){
      this.shouldDisplaySection = true;
      this.animal = animal;
    }
}