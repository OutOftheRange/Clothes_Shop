import React from "react";
import "bootstrap/dist/css/bootstrap.css";
import "./RegistrationForm.css";

const RegistrationForm = () => {
    return (
        <div className="container justify-content-center">
            <div className="row">
                <h2> You never have been here </h2>
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
                        <h3 className="col-md-6">Phone number</h3>
                        <input className="col-md-6"></input>
                    </div>
                </div>
            </div>
            <div className="row mb-3">
                <div className="col-md-6">
                    <div className="row">
                        <h3 className="col-md-6">Name</h3>
                        <input className="col-md-6"></input>
                    </div>
                </div>
            </div>
            <div className="row mb-3">
                <div className="col-md-6">
                    <div className="row">
                        <h3 className="col-md-6">Surname</h3>
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

export default RegistrationForm;
