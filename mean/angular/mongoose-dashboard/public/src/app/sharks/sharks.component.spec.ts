import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SharksComponent } from './sharks.component';

describe('SharksComponent', () => {
  let component: SharksComponent;
  let fixture: ComponentFixture<SharksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SharksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SharksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
