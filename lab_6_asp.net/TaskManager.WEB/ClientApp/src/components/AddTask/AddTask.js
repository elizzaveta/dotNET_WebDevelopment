import React, {Component, useEffect, useState} from 'react';
import {get, json, post} from "../../commonFunctions";

export default function AddTask() {

    const [employeesData, setEmployeesData] = useState({
        data: null,
        loading: true
    })

    const url = `https://localhost:5001/employees`;
    useEffect(() => {
        fetch(url, {
            "method": "GET"
        })
            .then(json)
            .then(response => {
                setEmployeesData({
                    data: response,
                    loading: false
                })
            });
    }, [url])

    let employees = [];
    if (employeesData.loading) employees = []
    else {
        employeesData.data.forEach(emp => {
            let t = 0
            emp.tasks.forEach(task => {
                if (task.status.name != "Done") {
                    t += 1
                }
            })
            employees.push({
                employee: emp,
                tasks: t
            })
        })
        
    }


    let content = (employeesData.loading)
        ? <p><em>Loading...</em></p>
        :
        <div>
            <h1>Add new task</h1>
            <div className="form-group">
                <label htmlFor="title">Title</label>
                <input className="form-control" type="text" id="title" name="title"/>
            </div>
            <div className="form-group">
                <label htmlFor="description">Description</label>
                <input className="form-control" type="text" id="description" name="description"/>
            </div>
            <div className="form-group">
                <label htmlFor="time">Time for accomplishment:</label>
                <input className="form-control" type="text" id="time" name="time"/>
            </div>
            <div className="form-group">
                <label htmlFor="priority">Priority:</label>
                <select className="form-control" id="priority" name="priority">
                    <option value="1">Low</option>
                    <option value="2">Middle</option>
                    <option value="3">High</option>
                </select>
            </div>
            <div className="form-group">
                <label htmlFor="employee">Employee:</label>
                <select className="form-control" id="employee" name="employee">
                    {employees.map(e =>
                        <option
                            value={e.employee.id}>{e.employee.firstName + " " + e.employee.lastName + " ---- Project: " + e.employee.project.name + " ---- Active tasks :" + e.tasks}</option>
                    )}
                </select>
            </div>
            <div>
                <button className="btn btn-success" onClick={onlc}>Add</button>
            </div>
        </div>
    ;


    return (
        <div>
            {content}
        </div>
    )
}

async function onlc(){
    await PostTask();
}

async function PostTask() {
    const url = `https://localhost:5001/tasks/task`;

    let title = document.getElementById("title").value;
    let description = document.getElementById("description").value;
    let priority = document.getElementById("priority").value;
    let time = document.getElementById("time").value;
    let employeeId = document.getElementById("employee").value;


    let task = {
        title: title,
        description: description,
        time: time,
        PriorityId: priority,
        StatusId: 1,
        EmployeeId: employeeId
    }
    console.log(task)

    let jsontask = JSON.stringify(task);
    console.log(jsontask)
    
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsontask
    };
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(data => console.log(data));

}

//
//
// async function getEmployee(id) {
//     const url = `https://localhost:5001/employees/employee/` + id;
//     let employee;
//     await fetch(url, {
//         "method": "GET"
//     })
//         .then(json)
//         .then(response => {
//             employee = response;
//         });
//
//     return employee;
// }
//
// function getPriority(id) {
//     let priority = {
//         id: id,
//         name: ""
//     }
//     switch (id) {
//         case "1":
//             priority.name = "Low";
//             break;
//         case "2":
//             priority.name = "Middle";
//             break;
//         case "3":
//             priority.name = "High";
//             break;
//     }
//     return priority;
// }