import React, {useEffect, useState} from "react";
import { useParams } from "react-router-dom";
import { getOrderById } from "../services/orders.service";
import IOrder from "../models/order";
import OrderItemsComponent from "../components/order-items.component";
import CustomerComponent from "../components/customer.component";

export default function Order()  {
    const {orderId} = useParams<{ orderId: string }>();

    const [order, setOrder] = useState<IOrder>();

    useEffect(() => {
         orderDetails()
             .then(o => {
                 console.log(`Loaded order by id ${o.id} with ${o?.itemGuids.length} items`);
                 setOrder(o);
             });
    }, []);

    const orderDetails = async () => {
        return await getOrderById(parseInt(orderId))
    }

    if (!order) {
        return <div className="text-center">
            <div className="spinner-border" role="status" />
        </div>
    }

    return <div>
        {order && (
            <h2>Order #{order.id}</h2>
        )}

        {order && (
            <div>
                <div className="row">
                <CustomerComponent order={order}/>
                </div>
                <div className="row">
                <OrderItemsComponent  order={order}/>
                </div>
            </div>
        )}
    </div>;
}