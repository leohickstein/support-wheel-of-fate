import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import {} from "jasmine";
import { NavMenuComponent } from "./nav-menu.component";

describe("NavMenuComponent", () => {
    let component: NavMenuComponent;
    let fixture: ComponentFixture<NavMenuComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [NavMenuComponent]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(NavMenuComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
