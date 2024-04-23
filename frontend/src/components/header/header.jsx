import React from 'react';
import { Link } from 'react-router-dom';

const Header = () => {
    return (
        <header className="bg-black text-white p-4 flex justify-between items-center">
            <Link to="/" className="text-white text-lg font-semibold">Eventopia</Link>
            <nav>
                <ul className="flex space-x-4">
                    <li><Link to="/about" className="hover:text-purple-500">About</Link></li>
                    <li><Link to="/discover-event" className="hover:text-purple-500">Discover Event</Link></li>
                    <li><Link to="/create-event" className="hover:text-purple-500">Create Event</Link></li>
                    <li><Link to="/login" className="hover:text-purple-500">Log In</Link></li>
                </ul>
            </nav>
        </header>
    );
}

export default Header;
