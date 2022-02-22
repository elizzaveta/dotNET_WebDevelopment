import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../../commonFunctions";

export default function ProjectTaskList() {
    const {projectId} = useParams()
    const url = `https://localhost:5001/projects/tasks/project/` + projectId;
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
                                <Link to={"/all-tasks/task/" + task.id}>
                                    <button className="btn btn-info">
                                        Details
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





