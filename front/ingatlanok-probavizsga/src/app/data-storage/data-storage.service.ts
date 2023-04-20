import { Injectable } from '@angular/core';
import { IngatlanokService } from '../ingatlanok/ingatlanok.service';
import { map, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Ingatlan, Kategoria } from '../interfaces';
import { KategoriakService } from '../kategoriak.service';

@Injectable({
  providedIn: 'root',
})
export class DataStorageService {
  constructor(
    private http: HttpClient,
    private ingatlanService: IngatlanokService,
    private kategoriaService: KategoriakService
  ) {}

  fetchIngatlanok() {
    console.log('fetching ingatlanok');

    return this.http
      .get<Ingatlan[]>(URL + '/ingatlan/list')
      .pipe(
        map((ingatlanok) => {
          const ingatlanData = ingatlanok.map((ingatlan) => {
            const record: Ingatlan = {
              id: ingatlan.id,
              kategoria: ingatlan.kategoria,
              leiras: ingatlan.leiras,
              hirdetesDatuma: ingatlan.hirdetesDatuma,
              tehermentes: ingatlan.tehermentes,
              ar: ingatlan.ar,
              kepUrl: ingatlan.kepUrl,
            };
            return { ...record };
          });
          return ingatlanData;
        }),
        tap({
          next: (data) => {
            this.ingatlanService.setIngatlanok(data.slice());
          },
          error: (error) => console.log(error),
        })
      )
      .subscribe();
  }

  fetchKategoriak() {
    console.log('fetching kategoriak');

    return this.http
      .get<Kategoria[]>(URL + '/kategoria/list')
      .pipe(
        map((kategoriak) => {
          const kategoriaData = kategoriak.map((kategoria) => {
            const record: Kategoria = {
              id: kategoria.id,
              nev: kategoria.nev,
            };
            return { ...record };
          });
          return kategoriaData;
        }),
        tap({
          next: (data) => {
            this.kategoriaService.setKategoriak(data.slice());
          },
          error: (error) => console.log(error),
        })
      )
      .subscribe();
  }
}
export const URL = 'https://localhost:7248/api';
