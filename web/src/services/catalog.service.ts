import {http} from "./http/http";

export const getTotalCatalogItemsCount = async (): Promise<number> => {
    const { data } = await http.get<number>("/api/catalog/items/count");
    return data;
};