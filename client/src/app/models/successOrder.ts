import {CustomerDetail} from "./customerDetail";
import {Item} from "./item";

export interface SuccessOrder {
  id: number;
  dateTime: string;
  statusType: string;
  customerDetail: CustomerDetail;
  items: Item[];
  total: number;
}
