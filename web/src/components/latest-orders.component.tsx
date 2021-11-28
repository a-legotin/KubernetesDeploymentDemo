import React, {Component} from 'react';
import axios from "axios";


export default interface IOrder {
    id?: any | null,
    guid: string
}


type Props = {};

type State = {
    orders: Array<IOrder>
};

export default class LatestOrders extends Component<Props, State>{
    constructor(props: Props) {
        super(props);
        this.retrieveLatestOrders = this.retrieveLatestOrders.bind(this);

        this.state = {
            orders: []
        };
    }

    componentDidMount() {
        this.retrieveLatestOrders();
    }

    retrieveLatestOrders() {
        console.log("API url is " + process.env.REACT_APP_API_URL);
        axios.get<Array<IOrder>>('http://' + process.env.REACT_APP_API_URL + `/orders/latest?portion=10`)
            .then((response: any) => {
                this.setState({
                    orders: response.data
                });
                console.log(response.data);
            })
            .catch((e: Error) => {
                console.log(e);
            });
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
                            <th scope="col">Header</th>
                            <th scope="col">Header</th>
                            <th scope="col"></th>
                        </tr>
                        </thead>
                        <tbody>
                        {orders &&
                        orders.map((order: IOrder) => (
                            <tr>
                                <td>{order.id}</td>
                                <td>{order.guid}</td>
                                <td>data</td>
                                <td>placeholder</td>
                                <td><i className="bi bi-arrow-right-circle"></i></td>
                            </tr>
                        ))}

                        </tbody>
                    </table>
                </div>
            </div>
        )
    }
}

