import { BrowserRouter, Route, Routes as ReactRoutes } from "react-router-dom";
import { Account } from "./components/Account";
import { Home } from "./components/Home";
import { Layout } from "./pages/Layout/Layout";
import { SignUp } from "./pages/SignUp/SignUp";
import { SignIn } from "./pages/SignIn/SignIn";

export function Routes() {
  return (
    <BrowserRouter>
      <ReactRoutes>
        <Route path="/" element={<Layout />}>
          <Route path="/" element={<Home />} />
          <Route path="/account" element={<Account />} />
          <Route path="/sign-up" element={<SignUp />} />
          <Route path="/sign-in" element={<SignIn />} />
        </Route>
      </ReactRoutes>
    </BrowserRouter>
  );
}
