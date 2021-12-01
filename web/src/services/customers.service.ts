import {http} from "./http/http";

export const getTotalCustomersCount = async (): Promise<number> => {
    const { data } = await http.get<number>("/api/customers/count");
    return data;
};