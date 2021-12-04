import {http} from "./http/http";
import ICustomer from "../models/customer";

export const getTotalCustomersCount = async (): Promise<number> => {
    const { data } = await http.get<number>("/api/customers/count");
    return data;
};

export const getCustomerByGuid = async (customerGuid: string): Promise<ICustomer> => {
    const { data } = await http.get<ICustomer>(`/api/customers/${customerGuid}`);
    return data;
};