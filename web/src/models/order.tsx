export default interface Order {
    id?: any | null,
    guid: string,
    customerName: string,
    itemGuids: string[],
    updatedAt: string
}