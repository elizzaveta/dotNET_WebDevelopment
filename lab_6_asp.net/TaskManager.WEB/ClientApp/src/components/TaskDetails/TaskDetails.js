import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../../commonFunctions";

export default function TaskDetails(){
    const {id} = useParams();
    const url = `https://localhost:5001/tasks/task/` + id;
    const [taskData, SetTaskData]= useState({
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
        <div>
            <h1>Task details</h1>
            <p>Id: {taskData.data.id}</p>
            <p>Title: {taskData.data.title}</p>
            <p>Description: {taskData.data.description}</p>
            <p>Priority: {taskData.data.priority.name}</p>
            <p>Status: {taskData.data.status.name}</p>
            <p>Project: {taskData.data.employee.project.name}</p>
            {(taskData.data.employee == null)?<div>Employee: None</div>:
                <p>Employee: {taskData.data.employee.firstName + " "+taskData.data.employee.lastName}</p>
            }
        </div>
    ;
    return(
        <div>
            {content}
        </div>
    )
}
