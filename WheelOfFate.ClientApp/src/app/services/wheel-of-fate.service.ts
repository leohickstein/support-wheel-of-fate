import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/Observable";
import { environment } from "../../environments/environment";
import * as moment from "moment";

@Injectable()
export class WheelOfFateService {
    private url: string = environment.apiUrl;

    constructor(private http: HttpClient) {}

    generateBauSchedule(
        startDate: Date,
        endDate: Date,
        numberOfShifts: number,
        numberOfEmployees: number
    ): Observable<schedule[]> {
        return this.http.get<schedule[]>(
            `${this.url}/bau/generate?` +
                `startDate=${moment(startDate).format("YYYY-MM-DD")}&` +
                `endDate=${moment(endDate).format("YYYY-MM-DD")}&` +
                `numberOfShifts=${numberOfShifts}&` +
                `numberOfEmployees=${numberOfEmployees}`
        );
    }

    getBauOptions(): Observable<string[]> {
        return this.http.get<string[]>(`${this.url}/bau/options`);
    }
}
