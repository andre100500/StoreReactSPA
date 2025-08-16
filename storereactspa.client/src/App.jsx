import {useState } from 'react';
import Login from './Login';
import './App.css';

function App() {
    const [token, setTokenState] = useState(localStorage.getItem('token'));
    const setToken = (userToken) => {
        localStorage.setItem('token', userToken);
        setTokenState(userToken);
    };
    if (!token) {
        return <Login setToken={setToken} />;
    }
    return (
        <div>
            <h1>Admin Panel</h1>
            {/* Your AdminPanelComponent where you fetch products */}
        </div>
    );
}

export default App;