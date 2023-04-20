export interface Kategoria {
  id: number;
  nev: string;
}

export interface Ingatlan {
  id: number;
  kategoria: number;
  leiras: string;
  hirdetesDatuma: Date;
  tehermentes: boolean;
  ar: number;
  kepUrl: string;
}
