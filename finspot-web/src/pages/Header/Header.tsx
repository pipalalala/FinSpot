import "./Header.scss";
import logo from "../../assets/icons/app_icon_secondary.ico";
import { CancelButton } from "../../components/CancelButton/CancelButton";
import { useNavigate } from 'react-router-dom';

export function Header() {
  const router = useNavigate();

  const redirectToSignUp = () => {
    router('/sign-up');
  };

  return (
    <div className="header__container">
      <div className="logo__container">
        <a href="/">
          <img src={logo} alt="logo" />
          <span>FinSpot</span>
        </a>
      </div>

      <div className="nav-panel__container">
        <a href="/" className="nav-panel-link">
          About us
        </a>
        <a href="/" className="nav-panel-link">
          API
        </a>
        <a href="/" className="nav-panel-link">
          FAQ
        </a>
      </div>

      <div className="account-controls__container">
        <a href="sign-in" className="nav-panel-link">
          Sign In
        </a>

        <CancelButton title="Sign Up" callback={redirectToSignUp} />
      </div>
    </div>
  );
}
