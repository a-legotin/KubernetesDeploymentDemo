export default interface IOrder {
    id?: any | null,
    guid: string,
    customerName: string,
    itemGuids: string[],
    updatedAt: string
}

