import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../commonFunctions";
import ProjectEmployeesTasks from "./ProjectEmployeesTasks";

export default function EditTaskStatus(){
    const project_url = `https://localhost:5001/projects`;
    const [projectData, SetProjectData]= useState({
        data: null,
        loading: true
    })


    useEffect(() => {
        fetch(project_url, {
            "method": "GET"
        })
            .then(json)
            .then(response => {
                SetProjectData({
                    data: response,
                    loading: false
                })
            });
    }, [project_url])

    let content = (projectData.loading)
        ? <p><em>Loading...</em></p>
        :
        <div>
            {projectData.data.map(project =>
                <div>
                    <input className="hide" id={"hd-"+project.id} type="checkbox"/>
                    <label htmlFor={"hd-"+project.id}>{project.name}</label>
                    <div>
                        <ProjectEmployeesTasks id={project.id}/>
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
