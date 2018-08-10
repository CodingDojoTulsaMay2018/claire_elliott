import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class HttpService {

    constructor(private _http: HttpClient) {
      this.getPokemon();
    }
    getPokemon(){
    let raichu = this._http.get('https://pokeapi.co/api/v2/pokemon/26/');
    raichu.subscribe(data => {
        console.log(`${data.name[0].toUpperCase()}${data.name.slice(1)}'s abilities are ${data.abilities[0].ability.name} and ${data.abilities[1].ability.name}.`);
        let ability = this._http.get(`${data.abilities[0].ability.url}`);
        ability.subscribe(data => {
            let pokemons = 0;
            for(var p of data.pokemon){
                pokemons++;
            }
            console.log(`${pokemons} pokemon have the ${data.name} ability.`);
        })
      });
    }
}