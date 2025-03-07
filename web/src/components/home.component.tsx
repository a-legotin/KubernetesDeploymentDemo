import { Component } from "react";
import { Card } from "./orders-card.component";
import LatestOrders from "./latest-orders.component";
import { getTotalOrdersCount } from "../services/orders.service";
import { getTotalCustomersCount } from "../services/customers.service";
import { getTotalCatalogItemsCount } from "../services/catalog.service";

// Proper interface definitions
interface Props {}

interface State {
    content: string;
    totalOrders: number;
    totalCustomers: number;
    totalCatalogItems: number;
    loading: boolean;
    error: string | null;
}

export default class Home extends Component<Props, State> {
    private _isMounted: boolean = false;

    constructor(props: Props) {
        super(props);
        this.state = {
            content: "",
            totalOrders: 0,
            totalCustomers: 0,
            totalCatalogItems: 0,
            loading: false,
            error: null
        };
    }

    componentDidMount() {
        this._isMounted = true;
        this.fetchData();
    }

    componentWillUnmount() {
        this._isMounted = false;
    }

    async fetchData() {
        try {
            this.setState({ loading: true, error: null });
            
            const [ordersTotal, customersTotal, catalogTotal] = await Promise.all([
                getTotalOrdersCount(),
                getTotalCustomersCount(),
                getTotalCatalogItemsCount()
            ]);

            if (this._isMounted) {
                this.setState({
                    totalOrders: ordersTotal || 0,
                    totalCustomers: customersTotal || 0,
                    totalCatalogItems: catalogTotal || 0,
                    loading: false
                });
                console.log("Loaded stat data");
            }
        } catch (error) {
            if (this._isMounted) {
                this.setState({
                    loading: false,
                    error: error instanceof Error ? error.message : 'Failed to load statistics'
                });
                console.error("Error loading stats:", error);
            }
        }
    }

    renderCard(title: string, value: number) {
        return (
            <div className="col">
                <Card title={title} value={value} />
            </div>
        );
    }

    renderLoader() {
        return (
            <div className="col">
                <div className="text-center">
                    <div className="spinner-border" role="status">
                        <span className="visually-hidden">Loading...</span>
                    </div>
                </div>
            </div>
        );
    }

    renderError() {
        return (
            <div className="alert alert-danger" role="alert">
                {this.state.error}
                <button 
                    className="btn btn-link" 
                    onClick={() => this.fetchData()}
                >
                    Retry
                </button>
            </div>
        );
    }

    render() {
        const { totalOrders, totalCustomers, totalCatalogItems, loading, error } = this.state;

        if (error) {
            return (
                <div className="container">
                    {this.renderError()}
                </div>
            );
        }

        return (
            <div className="container">
                <div className="row row-cols-1 row-cols-md-3 mb-3">
                    {loading 
                        ? (
                            <>
                                {this.renderLoader()}
                                {this.renderLoader()}
                                {this.renderLoader()}
                            </>
                        ) 
                        : (
                            <>
                                {this.renderCard("Orders total", totalOrders)}
                                {this.renderCard("Customers total", totalCustomers)}
                                {this.renderCard("Catalog items", totalCatalogItems)}
                            </>
                        )
                    }
                </div>
                <LatestOrders />
            </div>
        );
    }
}