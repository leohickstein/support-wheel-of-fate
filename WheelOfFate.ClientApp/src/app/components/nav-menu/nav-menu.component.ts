import { Component, OnInit, isDevMode } from "@angular/core";

@Component({
    selector: "nav-menu",
    templateUrl: "./nav-menu.component.html",
    styleUrls: ["./nav-menu.component.css"]
})
export class NavMenuComponent implements OnInit {
    constructor() {}

    ngOnInit() {
        if (isDevMode()) {
            console.log("👋 Development!");
        } else {
            console.log("💪 Production!");
        }
    }
}
