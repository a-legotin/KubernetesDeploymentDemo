export default interface IOrder {
    id?: any | null,
    guid: string,
    customerName: string,
    customerGuid: string,
    itemGuids: string[],
    updatedTime: string
}

