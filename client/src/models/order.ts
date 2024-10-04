import {CustomerDetail} from './customerDetail';
import {Item} from './item';

export interface Order {
  CustomerDetail: CustomerDetail;
  Items: Item[];
}
