import {http} from "./http/http";
import ICatalogItem from "../models/catalogItem";

export const getTotalCatalogItemsCount = async (): Promise<number> => {
    const { data } = await http.get<number>("/api/catalog/items/count");
    return data;
};

export const getCatalogItemByGuid = async (itemGuid: string): Promise<ICatalogItem> => {
    const { data } = await http.get<ICatalogItem>(`/api/catalog/items/${itemGuid}`);
    return data;
};