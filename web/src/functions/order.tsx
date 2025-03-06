import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getOrderById } from "../services/orders.service";
import IOrder from "../models/order";
import OrderItemsComponent from "../components/order-items.component";
import CustomerComponent from "../components/customer.component";

const Order: React.FC = () => {
    const { orderId } = useParams<{ orderId?: string }>(); 
    
    
    const [order, setOrder] = useState<IOrder | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchOrderDetails = async () => {
            if (!orderId) {
                setError("Invalid order ID");
                setLoading(false);
                return;
            }

            const id = parseInt(orderId);
            if (isNaN(id)) {
                setError("Invalid order ID format");
                setLoading(false);
                return;
            }

            try {
                setLoading(true);
                setError(null);
                const orderData = await getOrderById(id);
                setOrder(orderData);
                console.log(`Loaded order by id ${orderData.id} with ${orderData.itemGuids.length} items`);
            } catch (err) {
                setError(err instanceof Error ? err.message : "Failed to load order");
            } finally {
                setLoading(false);
            }
        };

        fetchOrderDetails();
    }, [orderId]); 

    
    if (loading) {
        return (
            <div className="text-center">
                <div className="spinner-border" role="status">
                    <span className="visually-hidden">Loading...</span>
                </div>
            </div>
        );
    }

    
    if (error) {
        return (
            <div className="alert alert-danger" role="alert">
                {error}
            </div>
        );
    }

    
    if (!order) {
        return <div>No order found</div>;
    }

    
    return (
        <div>
            <h2>Order #{order.id}</h2>
            <div className="row">
                <CustomerComponent order={order} />
            </div>
            <div className="row">
                <OrderItemsComponent order={order} />
            </div>
        </div>
    );
};

export default Order;