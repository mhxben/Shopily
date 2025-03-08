import { useState } from "react";
import { registerUser } from "../services/api";
import { useNavigate } from "react-router-dom";

const Register = () => {
  const [userData, setUserData] = useState({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    phoneNumber: "",
    role: "User",
  });

  const navigate = useNavigate();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUserData({ ...userData, [e.target.name]: e.target.value });
  };

  const handleRegister = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await registerUser(userData);
      navigate("/login");
    } catch (error) {
      console.error("Registration failed", error);
    }
  };

  return (
    <div className="register-container">
      <h2>Register</h2>
      <form onSubmit={handleRegister} className="register-form">
        <div className="input-group">
          <label>First Name</label>
          <input type="text" name="firstName" value={userData.firstName} onChange={handleChange} required />
        </div>

        <div className="input-group">
          <label>Last Name</label>
          <input type="text" name="lastName" value={userData.lastName} onChange={handleChange} required />
        </div>

        <div className="input-group">
          <label>Email</label>
          <input type="email" name="email" value={userData.email} onChange={handleChange} required />
        </div>

        <div className="input-group">
          <label>Password</label>
          <input type="password" name="password" value={userData.password} onChange={handleChange} required />
        </div>

        <div className="input-group">
          <label>Phone Number</label>
          <input type="text" name="phoneNumber" value={userData.phoneNumber} onChange={handleChange} required />
        </div>

        <button type="submit" className="register-btn">Register</button>
      </form>
    </div>
  );
};

export default Register;
