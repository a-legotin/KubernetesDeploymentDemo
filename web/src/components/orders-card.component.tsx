import React, {FunctionComponent} from 'react';

type CardProps = {
    title: string,
    value: number
}

const cardStyle = `
    width: 10rem;
`

export const Card: FunctionComponent<CardProps> = ({title, value}) =>
    <div className="card">
    <style>{cardStyle}</style>
        <div className="card-body">
            <div className="d-flex align-items-center">
                <div className="subheader">{ title }</div>
            </div>
            <div className="h1 mb-3">{value}</div>
        </div>
    </div>
