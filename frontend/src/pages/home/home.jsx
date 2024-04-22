import React from 'react';
import './home.css';

const Home = () => {
    return (
        <div className="container">
            <h1 className="heading">Welcome to Eventopia</h1>
            <div className="card">
                <h2>Discover Events</h2>
                <p>Find exciting events happening near you.</p>
                <button className="button">Discover Events</button>
            </div>
            <div className="card">
                <h2>Create Events</h2>
                <p>Create and host your own events.</p>
                <button className="button">Create Events</button>
            </div>
            <div className="card">
                <h2>Account</h2>
                <p>Manage your account settings.</p>
                <button className="button">Account</button>
            </div>
            <div className="card">
                <h2>Login</h2>
                <p>Login to your Eventopia account.</p>
                <button className="button">Login</button>
            </div>
        </div>
    );
}

export default Home;
