import {http} from "./http/http";
import IOrder from "../models/order";

export const fetchLatestOrders = async (): Promise<IOrder[]> => {
    const { data } = await http.get<IOrder[]>("/api/orders/latest?portion=10");
    return data;
};

export const getTotalOrdersCount = async (): Promise<number> => {
    const { data } = await http.get<number>("/api/orders/count");
    return data;
};