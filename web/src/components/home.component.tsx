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

        const renderLoader = () => {
          return <div className="text-center">
              <div className="spinner-border" role="status" />
          </div>
        }

        const renderCard = (title: string, value: number) => {
            return <div className="col">
                <Card title={title} value={value}/>
            </div>
        }

        const renderOrdersTotal = () => {
            return totalOrders ? renderCard("Orders total", this.state.totalOrders) : renderLoader();
        }

        const renderCustomersTotal = () => {
            return totalCustomers ? renderCard("Customers total", this.state.totalCustomers) : renderLoader();

        }

        const renderCatalogItemsTotal = () => {
            return totalCatalogItems ? renderCard("Catalog items", this.state.totalCatalogItems) : renderLoader();
        }

        return (
            <div className="container">
                <div className="row row-cols-1 row-cols-md-3 mb-3">
                    {renderOrdersTotal()}
                    {renderCustomersTotal()}
                    {renderCatalogItemsTotal()}
                </div>
                <LatestOrders/>
            </div>
        );
    }
}
