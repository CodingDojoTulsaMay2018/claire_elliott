import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OkinawaComponent } from './okinawa.component';

describe('OkinawaComponent', () => {
  let component: OkinawaComponent;
  let fixture: ComponentFixture<OkinawaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OkinawaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OkinawaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
