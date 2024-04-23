import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Header from './components/Header/Header';
import About from './components/pages/About';
import DiscoverEvent from './components/pages/DiscoverEvent';
import CreateEvent from './components/pages/CreateEvent';
import LogIn from './components/pages/LogIn';

const App = () => {
    return (
        <Router>
            <div>
                <Header />
                <Switch>
                    <Route path="/about" component={About} />
                    <Route path="/discover-event" component={DiscoverEvent} />
                    <Route path="/create-event" component={CreateEvent} />
                    <Route path="/login" component={LogIn} />
                </Switch>
            </div>
        </Router>
    );
}

export default App;
