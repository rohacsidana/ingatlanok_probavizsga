import { Component, OnInit } from '@angular/core';
import { DataStorageService } from '../data-storage/data-storage.service';

@Component({
  selector: 'app-ingatlanok',
  templateUrl: './ingatlanok.component.html',
  styleUrls: ['./ingatlanok.component.css'],
})
export class IngatlanokComponent implements OnInit {
  constructor(private dataStorageService: DataStorageService) {}

  ngOnInit(): void {
    this.dataStorageService.fetchIngatlanok();
    this.dataStorageService.fetchKategoriak();
  }
}
