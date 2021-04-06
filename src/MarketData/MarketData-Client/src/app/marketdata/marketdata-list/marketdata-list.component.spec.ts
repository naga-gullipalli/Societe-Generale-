import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketdataListComponent } from './marketdata-list.component';

describe('MarketdataListComponent', () => {
  let component: MarketdataListComponent;
  let fixture: ComponentFixture<MarketdataListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MarketdataListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketdataListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
