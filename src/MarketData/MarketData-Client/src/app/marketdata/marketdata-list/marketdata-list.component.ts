import { Component, OnInit } from '@angular/core';
import { FxData } from 'src/app/model/marketdata';
import { MarketDataService } from 'src/app/services/marketdata.service';

@Component({
  selector: 'app-marketdata-list',
  templateUrl: './marketdata-list.component.html',
  styleUrls: ['./marketdata-list.component.css']
})
export class MarketdataListComponent implements OnInit {
  fxData: FxData[];
  errorMessage: string;

  constructor(private marketDataService: MarketDataService) { }

  ngOnInit(): void {
    this.loadMarketData();
  }

  loadMarketData(){
    this.marketDataService.getMarketData().subscribe(
      marketdata => {
        this.fxData = marketdata
      },
      error => this.errorMessage = <any>error
    );
  }
}
