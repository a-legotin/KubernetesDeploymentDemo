import React, { Component } from 'react';
import { fetchLatestOrders } from "../services/orders.service";
import { Link } from "react-router-dom";
import IOrder from "../models/order";
import 'bootstrap-icons/font/bootstrap-icons.css';
import 'bootswatch/dist/zephyr/bootstrap.min.css';
import moment from 'moment';

interface Props {}

interface State {
    orders: IOrder[];
    loading: boolean;
    error: string | null;
}

export default class LatestOrders extends Component<Props, State> {
    constructor(props: Props) {
        super(props);
        this.state = {
            orders: [],
            loading: false,
            error: null
        };
    }

    componentDidMount() {
        this.fetchOrders();
    }

    async fetchOrders() {
        try {
            this.setState({ loading: true, error: null });
            const orders = await fetchLatestOrders();
            this.setState({
                orders: orders || [], 
                loading: false
            });
            console.log("Loaded latest orders");
        } catch (error) {
            this.setState({
                loading: false,
                error: error instanceof Error ? error.message : 'An error occurred'
            });
            console.error("Error loading orders:", error);
        }
    }

    render() {
        const { orders, loading, error } = this.state;

        if (loading) {
            return <div>Loading orders...</div>;
        }

        if (error) {
            return (
                <div className="alert alert-danger">
                    Error: {error}
                    <button 
                        className="btn btn-link" 
                        onClick={() => this.fetchOrders()}
                    >
                        Retry
                    </button>
                </div>
            );
        }

        if (!orders.length) {
            return <div>No orders found</div>;
        }

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
                                <th scope="col">Updated</th>
                                <th scope="col">Details</th>
                            </tr>
                        </thead>
                        <tbody>
                            {orders.map((order: IOrder) => (
                                <tr key={order.id}>
                                    <td>{order.id}</td>
                                    <td>{order.guid}</td>
                                    <td>{order.customerName}</td>
                                    <td>{order.itemGuids.length}</td>
                                    <td>{moment(order.updatedTime).format('dddd, MMMM D [at] h:mm A')}</td>
                                    <td>
                                        <Link to={`order/${order.id}`}>
                                            <i className="bi bi-arrow-right-circle"></i>
                                        </Link>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}