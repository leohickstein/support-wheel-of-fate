import { WheelOfFateService } from "./../../services/wheel-of-fate.service";
import { Component, OnInit } from "@angular/core";
import { FormControl, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material";
import { environment } from "../../../environments/environment";

@Component({
    selector: "wheel-of-fate",
    templateUrl: "./wheel-of-fate.component.html",
    styleUrls: ["./wheel-of-fate.component.css"]
})
export class WheelOfFateComponent implements OnInit {
    startDate = new FormControl(new Date(2018, 5, 11));
    endDate = new FormControl(new Date(2018, 5, 22));
    numberOfShifts: number;
    numberOfEmployees: number;
    schedules: schedule[];
    error: any = { isError: false, errorMessage: "" };

    constructor(
        private api: WheelOfFateService,
        public snackBar: MatSnackBar
    ) {}

    ngOnInit() {
        this.numberOfShifts = 2;
        this.numberOfEmployees = 10;
        this.schedules = [];
    }

    compareTwoDates() {
        if (new Date(this.endDate.value) < new Date(this.startDate.value)) {
            this.error = {
                isError: true,
                errorMessage: `End Date can't start before Start Date`
            };
        } else {
            this.error = [];
        }
    }

    generateSchedule() {
        this.api
            .generateBauSchedule(
                this.startDate.value,
                this.endDate.value,
                this.numberOfShifts,
                this.numberOfEmployees
            )
            .subscribe(
                result => {
                    this.schedules = result;
                    console.log(
                        `Called API nd returned ${JSON.stringify(
                            { data: this.schedules },
                            null,
                            4
                        )}`
                    );
                },
                error =>
                    this.openSnackBar(
                        `Error acessing BAU Api: ${environment.apiUrl}`,
                        "Dismiss"
                    )
            );
    }

    openSnackBar(message: string, action: string) {
        this.snackBar.open(message, action, {
            duration: 3000,
            horizontalPosition: "center",
            verticalPosition: "top"
        });
    }
}
