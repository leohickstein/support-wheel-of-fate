import { WheelOfFateService } from "./../../services/wheel-of-fate.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "wheel-of-fate",
  templateUrl: "./wheel-of-fate.component.html",
  styleUrls: ["./wheel-of-fate.component.css"]
})
export class WheelOfFateComponent implements OnInit {
  constructor(private svc: WheelOfFateService) {}

  ngOnInit() {
    // this.svc.getPokemons().subscribe(data => {
    //     this.pokemonData = data;
    //   });
  }
}
