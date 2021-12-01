import React, {Component} from "react";
import {Card} from "./orders-card.component";
import LatestOrders from "./latest-orders.component";
import {getTotalOrdersCount} from "../services/orders.service";
import {getTotalCustomersCount} from "../services/customers.service";
import {getTotalCatalogItemsCount} from "../services/catalog.service";

type Props = {};

type State = {
    content: string;
    totalOrders: number,
    totalCustomers: number,
    totalCatalogItems: number
}

export default class Home extends Component<Props, State> {
    constructor(props: Props) {
        super(props);

        this.state = {
            content: "",
            totalOrders: 0,
            totalCustomers: 0,
            totalCatalogItems: 0
        };
    }

    componentDidMount() {
        const fetchData = async () => {
            const ordersTotal = await getTotalOrdersCount();
            const customersTotal = await getTotalCustomersCount();
            const catalogTotal = await getTotalCatalogItemsCount();

            this.setState({
                totalOrders: ordersTotal,
                totalCustomers: customersTotal,
                totalCatalogItems: catalogTotal
            });
        };

        fetchData().then(r => console.log("Loaded stat data"));
    }

    render() {
        const {totalOrders, totalCatalogItems, totalCustomers} = this.state;

        return (
            <div className="container">
                <div className="row row-cols-1 row-cols-md-3 mb-3 text-center">
                    {totalOrders &&
                    <div className="col-sm-6">
                        <Card title="Orders total" value={this.state.totalOrders}/>
                    </div>
                    }

                    {totalCustomers &&
                    <div className="col-sm-6">
                        <Card title="Customers total" value={totalCustomers}/>
                    </div>
                    }

                    {totalCatalogItems &&
                    <div className="col-sm-6">
                        <Card title="Items in the catalog" value={totalCatalogItems}/>
                    </div>
                    }

                </div>
                <LatestOrders/>
            </div>
        );
    }
}
