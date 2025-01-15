import {CustomerDetail} from './customerDetail';
import {Item} from './item';

export interface Order {
  customerDetail: CustomerDetail;
  items: Item[];
}
