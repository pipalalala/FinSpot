import { useState } from "react";

export function SignUp() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [dateOfBirth, setDateOfBirth] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const onSubmit = () => {
    const body = {
        firstName,
        lastName,
        dateOfBirth,
        email,
        password,
        gender: "Male"
    }
    // Call auth service
  };

  return (
    <div className="sign-up__container">
      <input
        type="text"
        value={firstName}
        onChange={(event) => {
          setFirstName(event.target.value);
        }}
        className="first-name__container"
      />

      <input
        type="text"
        value={lastName}
        onChange={(event) => {
          setLastName(event.target.value);
        }}
        className="last-name__container"
      />

      <input
        type="date"
        value={dateOfBirth}
        onChange={(event) => {
          setDateOfBirth(event.target.value);
        }}
        className="date-of-birth__container"
      />

      <input
        type="text"
        value={email}
        onChange={(event) => {
          setEmail(event.target.value);
        }}
        className="email__container"
      />

      <input
        type="text"
        value={password}
        onChange={(event) => {
          setPassword(event.target.value);
        }}
        className="password__container"
      />

      <button onClick={() => onSubmit()}>Sign Up</button>
    </div>
  );
}
