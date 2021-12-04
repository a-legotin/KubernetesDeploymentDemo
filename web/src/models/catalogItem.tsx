import IItemCategory from "./itemCategory";

export default interface ICatalogItem {
    guid: string,
    description: string,
    cost: number,
    category: IItemCategory
}