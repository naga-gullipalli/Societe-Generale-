import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MarketdataCreateComponent } from './marketdata-create.component';

describe('MarketdataCreateComponent', () => {
  let component: MarketdataCreateComponent;
  let fixture: ComponentFixture<MarketdataCreateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MarketdataCreateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MarketdataCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
