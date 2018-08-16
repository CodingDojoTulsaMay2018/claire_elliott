import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HiroshimaComponent } from './hiroshima.component';

describe('HiroshimaComponent', () => {
  let component: HiroshimaComponent;
  let fixture: ComponentFixture<HiroshimaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HiroshimaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HiroshimaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
