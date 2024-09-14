import { Component } from '@angular/core';
import { DataService } from '../service/data.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Trading.App';
  positions: any[] = [];

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.dataService.getPositions().subscribe(data => {
      this.positions = data;
    });
  }
}
