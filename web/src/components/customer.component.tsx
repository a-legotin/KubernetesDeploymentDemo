import IOrder from "../models/order";
import {Component} from "react";
import ICustomer from "../models/customer";
import {getCustomerByGuid} from "../services/customers.service";

type Props = {
    order: IOrder
};

type State = {
    customer: ICustomer
};

export default class CustomerComponent extends Component<Props, State>{

    componentDidMount() {
        const fetchData = async () => {
            return await getCustomerByGuid(this.props.order.customerGuid);
        };

        fetchData().then(r => {
            console.log(`Loaded order ${this.props.order.id} items`)
            this.setState({
                customer: r
            });
        });
    }

    renderLoader = () => {
        return <div className="text-center">
            <div className="spinner-border" role="status" />
        </div>
    }

    renderCustomerDetails = () => {
        const {customer}  = this.state;

        return <div className="card">
            <div className="card-body">
                <div className="d-flex align-items-center">
                    <div className="subheader">Customer #{customer.id}</div>
                </div>
                <div className="h3 mb-3">{customer.first_name} {customer.last_name}</div>
                <div className="h6 mb-3">{customer.email}</div>
            </div>
        </div>
    }

    renderCustomer = () => {
        return this.state ? this.renderCustomerDetails() : this.renderLoader();
    }

    render() {
        return <div>        {this.renderCustomer()}
        </div>
    }
}
