import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WheelOfFateComponent } from './wheel-of-fate.component';

describe('WheelOfFateComponent', () => {
  let component: WheelOfFateComponent;
  let fixture: ComponentFixture<WheelOfFateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WheelOfFateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WheelOfFateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
