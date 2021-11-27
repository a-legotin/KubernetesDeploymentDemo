import React, { Component } from "react";
import {Card} from "./orders-card.component";
import {LatestOrders} from "./latest-orders.component";

type Props = {};

type State = {
  content: string;
}

export default class Home extends Component<Props, State> {
  constructor(props: Props) {
    super(props);

    this.state = {
      content: ""
    };
  }


  render() {
    return (
      <div className="container">
          <div className="row row-cols-1 row-cols-md-3 mb-3 text-center">
              <div className="col-sm-6">
                  <Card title="Orders total" paragraph="100" />
              </div>
              <div className="col-sm-6">
                  <Card title="Customers total" paragraph="1000" />
              </div>
              <div className="col-sm-6">
                  <Card title="Items in the catalog" paragraph="5000" />
              </div>
          </div>
          <LatestOrders />
      </div>
    );
  }
}
