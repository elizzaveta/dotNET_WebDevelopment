import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../../commonFunctions";

export default function EmployeeList() {
    const url = `https://localhost:5001/employees`;
    const [employeeData, SetEmployeeData] = useState({
        data: null,
        loading: true
    })


    useEffect(() => {
        fetch(url, {
            "method": "GET"
        })
            .then(json)
            .then(response => {
                SetEmployeeData({
                    data: response,
                    loading: false
                })
            });
    }, [url])

    let content = (employeeData.loading)
        ? <p><em>Loading...</em></p>
        :
        <div className="table-responsive">
            <table className="table table-striped">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                {employeeData.data.map(employee =>
                    <tr>
                        <td>{employee.id}</td>
                        <td>{employee.firstName}</td>
                        <td>{employee.lastName}</td>
                        <td>
                            <div className="btn-group-vertical">
                                <Link to={"/all-tasks/employee/"+employee.id}>
                                    <button className="btn btn-info">
                                        Get tasks
                                    </button>
                                </Link>
                            </div>
                        </td>
                    </tr>
                )}
                </tbody>
            </table>
        </div>
    ;


    return (
        <div>
            {content}
        </div>
    )
}

