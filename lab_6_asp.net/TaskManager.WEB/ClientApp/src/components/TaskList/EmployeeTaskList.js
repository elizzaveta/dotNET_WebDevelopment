import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../../commonFunctions";

export default function EmployeeTaskList() {
    const {employeeId} = useParams()
    const url = `https://localhost:5001/tasks/employee/` + employeeId;
    const [taskData, SetTaskData] = useState({
        data: null,
        loading: true
    })


    useEffect(() => {
        fetch(url, {
            "method": "GET"
        })
            .then(json)
            .then(response => {
                SetTaskData({
                    data: response,
                    loading: false
                })
            });
    }, [url])


    let content = (taskData.loading)
        ? <p><em>Loading...</em></p>
        :
        <div className="table-responsive">
            <table className="table table-striped">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Title</th>
                    <th>Project</th>
                    <th>Employee</th>
                    <th>Status</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                {taskData.data.map(task =>
                    <tr>
                        <td>{task.id}</td>
                        <td>{task.title}</td>
                        <td>{task.employee.project.name}</td>
                        <td>{task.employee.firstName} {task.employee.lastName}</td>
                        <td>{task.status.name}</td>
                        <td>
                            <div className="btn-group-vertical">

                                <button className="btn btn-info">
                                    <Link to={"/all-tasks/task/" + task.id}>Details</Link>
                                </button>
                                <button className="btn btn-info">
                                    <Link to={"/edit-task-status/" + task.id}>Edit Status</Link>
                                </button>


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





