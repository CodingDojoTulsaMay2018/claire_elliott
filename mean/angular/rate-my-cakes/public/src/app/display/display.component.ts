import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.css']
})
export class DisplayComponent implements OnInit {
  @Input() pokeToShow: any;
  constructor() { }
  
  ngOnInit() {
  }

  findAverageRating(){
    let sum = 0;
    for(let i = 0; i < this.pokeToShow.ratings.length; i++){
      sum += parseInt(this.pokeToShow.ratings[i].star);
    }
    console.log("sum " + sum + "Length: " + this.pokeToShow.ratings.length);
    if(sum/this.pokeToShow.ratings.length > 1){
      return ((sum/this.pokeToShow.ratings.length).toFixed(2) + " Stars");
    }
    else if(sum/this.pokeToShow.ratings.length <= 1){
      return (sum/this.pokeToShow.ratings.length + " Star");
    }
    else{
      return "0 Stars";
    }
  }
}