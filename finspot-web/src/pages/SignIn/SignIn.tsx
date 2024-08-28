import { useState } from "react";
import "./SignIn.scss";
import { SubmitButton } from "../../components/SubmitButton/SubmitButton";

export function SignIn() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const onSubmit = () => {
    console.log("submit");
  };

  return (
    <div className="sign-in__container">
      <div className="title__contaier">
        <span className="title">Sign In</span>
      </div>

      <div className="inputs__container">
        <form>
          <div className="input__container">
            <input type="text" className="text-input" placeholder="email" />
          </div>
          <div className="input__container">
            <input
              type="password"
              className="text-input"
              placeholder="password"
            />
          </div>
        </form>

        <div className="submit-button__container">
            <SubmitButton title="SIGN IN" callback={onSubmit} />
        </div>
      </div>

      <div className="sign-up__container">
        <span>Have no account?</span>
        <a className="sign-up-link" href="/sign-up">
          Sign Up
        </a>
      </div>
    </div>
  );
}
