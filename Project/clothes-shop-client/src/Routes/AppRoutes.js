import React from "react";
import { Route, Routes } from "react-router-dom";
import routingUrl from "../constants/routingUrl";
import LoginForm from "../Components/LoginForm/LoginForm";
import RegistrationForm from "../Components/RegistrationForm/RegistrationForm";
import AuthorizationPage from "../Pages/AuthorizationPage/AuthorizationPage";
import Layout from "../Components/Layout";


const AppRoutes = () => {
    return (
        <>
            <Routes>
                <Route path="/" element={<Layout />}/>
                
                
                <Route
                    path={routingUrl.pathToLoginPage}
                    element={<AuthorizationPage />}
                />
                <Route
                    path={routingUrl.pathToRegistrationPage}
                    element={<RegistrationForm />}
                />
            </Routes>
        </>
    );
};

export default AppRoutes;
