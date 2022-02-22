import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../commonFunctions";

export default function EmployeeTasksDetails(fields){
    const project_id = fields.id;
    const url = `https://localhost:5001/projects/project-team-employees/` + project_id;
    const [employeeData, SetEmployeeData]= useState({
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
            {employeeData.data.map(employee =>
                <div>
                    <input className="hide" id={"hde-"+employee.id} type="checkbox"/>
                    <label htmlFor={"hde-"+employee.id}>{employee.firstName + " "+ employee.lastName}</label>
                    <div>
                        {employee.tasks.map(task=>
                            <Link to={"/task-details/"+task.id}><div>{task.id +". " + task.description}</div></Link>
                        )}
                    </div>
                </div>
            )}
        </div>
    ;
    return(
        <div>
            {content}
        </div>
    )
}
