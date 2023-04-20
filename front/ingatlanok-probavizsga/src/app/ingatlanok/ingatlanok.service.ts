import { Injectable } from '@angular/core';
import { Ingatlan } from '../interfaces';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class IngatlanokService {
  ingatlanDataChanged: Subject<Ingatlan[]> = new Subject<Ingatlan[]>();
  private ingatlanData: Ingatlan[] = [];

  constructor() {}

  setIngatlanok(ingatlanok: Ingatlan[]) {
    this.ingatlanData = ingatlanok;
    this.ingatlanDataChanged.next(this.ingatlanData.slice())
  }
}
