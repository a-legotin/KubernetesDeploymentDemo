import React, {Component} from 'react';
import IOrder from "../models/order";
import { fetchLatestOrders } from "../services/orders.service";
import {
    Link,
} from "react-router-dom";

type Props = {};

type State = {
    orders: Array<IOrder>
};

export default class LatestOrders extends Component<Props, State>{
    constructor(props: Props) {
        super(props);
        this.state = {
            orders: []
        };
    }

    componentDidMount() {
        const fetchData = async () => {
            const orders = await fetchLatestOrders();
            this.setState({
                orders: orders
            });
        };

        fetchData().then(r => console.log("Loaded latest orders"));
    }


    render() {
        const {  orders } = this.state;

        return (
            <div>
                <h2>Latest orders</h2>
                <div className="table-responsive">
                    <table className="table table-striped table-sm">
                        <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">Guid</th>
                            <th scope="col">Customer</th>
                            <th scope="col">Items</th>
                            <th scope="col"></th>
                        </tr>
                        </thead>
                        <tbody>
                        {orders && orders.map((order: IOrder) => (
                            <tr key={order.id}>
                                <td>{order.id}</td>
                                <td>{order.guid}</td>
                                <td>{order.customerName}</td>
                                <td>{order.itemGuids.length}</td>
                                <td><Link to={`order/${order.id}`}><i className="bi bi-arrow-right-circle"></i></Link></td>
                            </tr>
                        ))}

                        </tbody>
                    </table>
                </div>
            </div>
        )
    }
}

