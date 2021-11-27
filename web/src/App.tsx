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
  }

  componentDidMount() {
  }


  render() {
      return (
        <div className="container">
          <header className="d-flex flex-wrap justify-content-center py-3 mb-4 border-bottom">
              <Link to={"/"} className="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-dark text-decoration-none">
                K8S deployment demo
              </Link>

            <ul className="nav nav-pills">
                <li className="nav-item">
                    <Link to={"/home"} className="nav-link">
                        Home
                    </Link>
                </li>
            </ul>
          </header>
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