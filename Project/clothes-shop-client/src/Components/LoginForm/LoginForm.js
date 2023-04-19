import React from "react";
import "bootstrap/dist/css/bootstrap.css";

const LoginForm = () => {
    return (
        <div className="container">
            <div className="row">
                <h2> You already have an account</h2>
            </div>
            <div className="row mb-3 text-alignment-center">
                <div className="col-md-6">
                    <div className="row">
                        <h3 className="col-md-6">Email</h3>
                        <input className="col-md-6"></input>
                    </div>
                </div>
            </div>
            <div className="row mb-3">
                <div className="col-md-6">
                    <div className="row">
                        <h3 className="col-md-6">Password</h3>
                        <input className="col-md-6"></input>
                    </div>
                </div>
            </div>
            <button className="btn btn-primary btn-lg">Register</button>
        </div>
    );
};

export default LoginForm;
