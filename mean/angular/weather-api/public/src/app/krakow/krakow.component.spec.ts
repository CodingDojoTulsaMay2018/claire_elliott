import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KrakowComponent } from './krakow.component';

describe('KrakowComponent', () => {
  let component: KrakowComponent;
  let fixture: ComponentFixture<KrakowComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KrakowComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KrakowComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
