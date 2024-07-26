import { Photo } from './photo';

export interface WatchDetail {
  id: number;
  brand: string;
  calibre: string;
  caseMaterial: string;
  crystal: string;
  dial: string;
  lume: boolean;
  reference: string;
  movementType: string;
  price: number;
  powerReserve: number;
  stock: number;
  strapBraceletMaterial: string;
  diameter: number;
  thickness: number;
  length: number;
  lugWidth: number;
  watchType: string;
  waterResistance: number;
  otherSpecifications: string;
  photos: Photo[];
}
