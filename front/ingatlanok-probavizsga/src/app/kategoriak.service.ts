import { Injectable } from '@angular/core';
import { Kategoria } from './interfaces';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class KategoriakService {
  kategoriaDataChanged: Subject<Kategoria[]> = new Subject<Kategoria[]>();
  private kategoriaData: Kategoria[] = [];

  constructor() {}

  setKategoriak(kategoriak: Kategoria[]) {
    this.kategoriaData = kategoriak;
    console.log('kategoriak:');
    console.log(this.kategoriaData);

    this.kategoriaDataChanged.next(this.kategoriaData.slice());
  }
}
