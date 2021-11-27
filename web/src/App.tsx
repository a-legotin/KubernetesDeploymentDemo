import { Component } from "react";
import { Switch, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import Home from "./components/home.component";

type Props = {};

type State = {
}

class App extends Component<Props, State> {
  constructor(props: Props) {
    super(props);
    this.state = {
      currentUser: undefined,
    };
  }

  componentDidMount() {

  }

  render() {
    return (
      <div>
        <nav className="navbar navbar-expand navbar-dark bg-dark">
          <Link to={"/"} className="navbar-brand">
            K8S deployment demo
          </Link>
          <div className="navbar-nav mr-auto">
            <li className="nav-item">
              <Link to={"/home"} className="nav-link">
                Home
              </Link>
            </li>
          </div>
        </nav>

        <div className="container mt-3">
          <Switch>
            <Route exact path={["/", "/home"]} component={Home} />
          </Switch>
        </div>
      </div>
    );
  }
}

export default App;