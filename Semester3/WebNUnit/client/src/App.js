import './App.css';
import { Header } from './components/Navbar'
import { Route, BrowserRouter, Switch } from 'react-router-dom'
import { Home } from './Pages/Home'
import {LoadTheAssembly} from "./Pages/LoadTheAssembly";
import {RunTests} from "./Pages/RunTests";
import {History} from "./Pages/History";

function App() {
  return (
    <BrowserRouter>
      <Header/>
      <div className="container pt-4">
        <Switch>
            <Route path={'/load-assembly'} component={LoadTheAssembly}/>
            <Route path={'/'} exact component={Home}/>
            <Route path={'/run-tests'} component={RunTests}/>
            <Route path={'/history'} component={History}/>
        </Switch>
      </div>
    </BrowserRouter>
  );
}

export default App;
