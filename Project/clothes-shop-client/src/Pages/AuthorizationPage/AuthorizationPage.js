import { React, useState } from "react";
import PropTypes from "prop-types";
import "./AuthorizationPage.css";
import { Navigate } from "react-router-dom";
import routingUrl from "../../constants/routingUrl";
import RegistrationForm from "../../Components/RegistrationForm/RegistrationForm";
import LoginForm from "../../Components/LoginForm/LoginForm";

const AuthorizationPage = () => {
    const [AuthComponent, setAuthCOmponent] = useState();
    const renderLogin = () => {
        setAuthCOmponent(<LoginForm />);
    };
    return (
        <div className="row d-flex justify-content-center">
            <div className="col-lg-6 centered-form">
                <LoginForm />
            </div>
            <div className="col-lg-6 centered-form">
                <RegistrationForm />
            </div>
        </div>
    );
};
/*
AuthorizationPage.propTypes = {
    component: PropTypes.element
};
 */
export default AuthorizationPage;
