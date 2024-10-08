import {CustomerDetail} from "./customerDetail";
import {Item} from "./item";

export interface SuccessOrder {
  id: number;
  dataTime: string;
  statusType: string;
  customerDetail: CustomerDetail;
  items: Item[];
  total: number;
}
