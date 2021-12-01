import React, { FunctionComponent } from 'react';

type CardProps = {
    title: string,
    value: number
}

export const Card: FunctionComponent<CardProps> = ({ title, value }) =>
<div className="card mb-sm-1 rounded-1 shadow-sm">
    <div className="card-header py-1">
        <h4 className="my-0 fw-normal">{ title }</h4>
    </div>
    <div className="card-body">
        <h1 className="card-title pricing-card-title">{ value }</h1>
    </div>
</div>