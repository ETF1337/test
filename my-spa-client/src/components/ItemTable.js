import React from 'react';
import './ItemTable.css'; 

const ItemTable = ({ items }) => {
    return (
        <table className="item-table">
            <thead>
                <tr>
                    <th className="table-header">Значение 1</th>
                    <th className="table-header">Значение 2</th>
                </tr>
            </thead>
            <tbody>
                {items.map((item, index) => (
                    <tr key={index}>
                        <td className="table-cell">{item.name}</td>
                        <td className="table-cell">{item.description}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default ItemTable;