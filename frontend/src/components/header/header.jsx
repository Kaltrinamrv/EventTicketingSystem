import React from 'react';
import './header.css';

const Header = () => {
    return (
        <header className="header">
            <h1 className="logo">EVENTOPIA</h1>
            <nav className="nav">
                <ul>
                    <li><a href="#discover-events">Discover Events</a></li>
                    <li><a href="#create-events">Create Events</a></li>
                    <li><a href="#account">Account</a></li>
                    <li><a href="#login">Login</a></li>
                </ul>
            </nav>
        </header>
    );
}

export default Header;
