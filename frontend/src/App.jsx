import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Home from './home'; // Import your Home component

const App = () => {
    return (
        <Router>
            <Switch>
                <Route exact path="/" component={Home} />
                {/* Add more routes here if needed */}
            </Switch>
        </Router>
    );
}

export default App;
