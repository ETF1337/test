import React, { useState } from 'react';
import ItemForm from './components/ItemForm';
import ItemTable from './components/ItemTable';

const App = () => {
    const [items, setItems] = useState([]);

    const addItem = (item) => {
        setItems([...items, item]);
    };

    const exportToExcel = async () => {
        if (items.length === 0) {
            alert('Нет данных для экспорта');
            return;
        } 
        const response = await fetch('http://localhost:5049/api/items/export', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(items), 
        });

        if (!response.ok) {
            console.error('Ошибка при экспорте в Excel:', response.statusText);
            return;
        }

        const blob = await response.blob(); 
        const url = window.URL.createObjectURL(blob); 
        const a = document.createElement('a');
        a.href = url;
        a.download = 'items.xlsx'; 
        document.body.appendChild(a);
        a.click(); 
        a.remove();
        window.URL.revokeObjectURL(url);
    };

    return (
        <div>
            <h1>Тест</h1>
            <ItemForm addItem={addItem} />
            <ItemTable items={items} />
            <button onClick={exportToExcel}>Экспорт в Excel</button>
        </div>
    );
};

export default App;