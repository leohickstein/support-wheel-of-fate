import { TestBed, inject } from "@angular/core/testing";
import { WheelOfFateService } from "./wheel-of-fate.service";

describe("WheelOfFateService", () => {
    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [WheelOfFateService]
        });
    });

    it("should be created", inject(
        [WheelOfFateService],
        (service: WheelOfFateService) => {
            expect(service).toBeTruthy();
        }
    ));
});
