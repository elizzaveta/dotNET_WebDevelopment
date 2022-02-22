import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../../commonFunctions";
import './TaskTree.css'

export default function EmployeeTaskTree(fields) {
    const url = `https://localhost:5001/employees`;
    const displayOption = fields.option;
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
        <div>
            {(displayOption==="details")
                ?<h1>Choose task to view detais:</h1>
                :<h1>Choose task to update:</h1>
            }
            {employeeData.data.map(employee =>
                <div>

                    <input className="hide" id={"hd-"+employee.id} type="checkbox"/>
                    <label htmlFor={"hd-"+employee.id}>{employee.firstName+" "+employee.lastName}</label>
                    <div>

                        {employee.tasks.map(task=>
                            <div>{(displayOption==="details")
                                ?<Link to={"/all-tasks/task/"+task.id}><div>{task.id +". " + task.title}</div></Link>
                                :<Link to={"/edit-task-status/"+task.id}><div>{task.id +". " + task.title}</div></Link>
                            }</div>

                        )}
                    </div>
                </div>
            )}
        </div>
    ;


    return (
        <div>
            {content}
        </div>
    )
}

