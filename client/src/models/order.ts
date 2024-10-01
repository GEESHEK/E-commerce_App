import { CustomerDetails } from './customerDetail';
import { Item } from './item';

export interface Order {
  CustomerDetail: CustomerDetails;
  Item: Item[];
}
