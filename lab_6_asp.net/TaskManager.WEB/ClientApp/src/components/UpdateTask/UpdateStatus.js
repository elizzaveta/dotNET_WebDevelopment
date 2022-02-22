import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json, put} from "../../commonFunctions";
// import './TaskChoice.css'

export default function UpdateStatus() {
    const {taskId} =useParams();
    const task_url = `https://localhost:5001/tasks/task/`+taskId;
    const [taskData, SetTaskData] = useState({
        data: null,
        loading: true
    })


    useEffect(() => {
        fetch(task_url, {
            "method": "GET"
        })
            .then(json)
            .then(response => {
                SetTaskData({
                    data: response,
                    loading: false
                })
            });
    }, [task_url])

    let content = (taskData.loading)
        ? <p><em>Loading...</em></p>
        :
        <div>
            <h1>Appoint employee for task</h1>
            <h2>Task</h2>
            <p>Id: {taskData.data.id}</p>
            <p>Title: {taskData.data.title}</p>
            <p>Description: {taskData.data.description}</p>
            <p>Priority: {taskData.data.priority.name}</p>
            <p>Status: {taskData.data.status.name}</p>
            <label htmlFor="status">Status:</label>
            <select id="status" name="status">
                <option value="1">NotStarted</option>
                <option value="2">OnExecution</option>
                <option value="3">Done</option>
            </select><br/>
            <p>Project id: {taskData.data.employee.project.id}</p>
            <p>Employee: {taskData.data.employee.firstName + " "+taskData.data.employee.lastName}</p>

            <button onClick={()=>PutTask(taskData.data)}>Update</button>
        </div>
    ;


    return (
        <div>
            {content}
        </div>
    )
}


function PutTask(task){
    const url = `https://localhost:5001/tasks/task`;

    let statusId = document.getElementById("status").value;
    
    
    let task_obj = {
        id: task.id,
        title: task.title,
        description: task.description,
        time: task.time,
        PriorityId: task.priority.id,
        StatusId: statusId,
        employee: task.employee.id
    }
    let json = JSON.stringify(task_obj);
    put(url, json)

}
