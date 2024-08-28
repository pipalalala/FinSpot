import { Outlet } from "react-router-dom";
import { Header } from "../Header/Header";
import { Footer } from "../../components/Footer";
import "./Layout.scss";

export function Layout() {
  return (
    <>
      <Header />
      <div className="content__container">
        <Outlet></Outlet>
      </div>
      <div className="spacer"></div>
      <div className="footer__container">
        <Footer />
      </div>
    </>
  );
}
