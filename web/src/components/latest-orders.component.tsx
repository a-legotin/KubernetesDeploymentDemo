import React, {FunctionComponent} from 'react';

type LatestOrdersProps = {
}

export const LatestOrders: FunctionComponent<LatestOrdersProps> = ({}) =>
    <div>
        <h2>Latest orders</h2>
        <div className="table-responsive">
            <table className="table table-striped table-sm">
                <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Header</th>
                    <th scope="col">Header</th>
                    <th scope="col">Header</th>
                    <th scope="col">Header</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>1,001</td>
                    <td>random</td>
                    <td>data</td>
                    <td>placeholder</td>
                    <td>text</td>
                </tr>
                </tbody>
            </table>
        </div>
    </div>
