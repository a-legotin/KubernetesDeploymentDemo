import React, {Component} from 'react';
import IOrder from "../models/order";
import ICatalogItem from "../models/catalogItem";
import {getCatalogItemByGuid} from "../services/customers.service";

type Props = {
    order: IOrder
};

type State = {
    items: Array<ICatalogItem>
};

export default class OrderItemsComponent extends Component<Props, State>{
    constructor(props: Props) {
        super(props);
        this.state = {
            items: []
        };
    }

    componentDidMount() {
        const fetchData = async () => {
            return await Promise.all(this.props.order.itemGuids.map(async value => {
                console.log(`Loading order ${this.props.order.id} item ${value}`)
                return await getCatalogItemByGuid(value);
            }));
        };

        fetchData().then(r => {
            console.log(`Loaded order ${this.props.order.id} items`)
            this.setState({
                items: r
            });
        });
    }


    render() {
        const { items } = this.state;

        return (
            <div>
                <h2>Order items</h2>
                <div className="table-responsive">
                    <table className="table table-striped table-sm">
                        <thead>
                        <tr>
                            <th scope="col">Guid</th>
                            <th scope="col">Description</th>
                            <th scope="col">Cost</th>
                            <th scope="col">Category</th>
                        </tr>
                        </thead>
                        <tbody>
                        {items && items.map((item: ICatalogItem) => (
                            <tr key={item.guid}>
                                <td>{item.guid}</td>
                                <td>{item.description}</td>
                                <td>{item.cost}</td>
                                <td>{item.category?.description}</td>
                            </tr>
                        ))}
                        </tbody>
                    </table>
                </div>
            </div>
        )
    }
}

