import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-ping',
  templateUrl: './ping.component.html'
})
export class PingComponent {
  private pingResult: PingResult;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PingResult>(baseUrl + 'ping/127.0.0.1').subscribe(result => {
      this.pingResult = result;
    }, error => console.error(error));
  }
}

interface PingResult {
  address: string;
  time: string;
  status: string;
}
