import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../../commonFunctions";
import './TaskTree.css'

export default function ProjectTaskTree(fields) {
    const url = `https://localhost:5001/projects`;
    const displayOption = fields.option;
    const [projectData, SetTProjectData] = useState({
        data: null,
        loading: true
    })


    useEffect(() => {
        fetch(url, {
            "method": "GET"
        })
            .then(json)
            .then(response => {
                SetTProjectData({
                    data: response,
                    loading: false
                })
            });
    }, [url])

    let content = (projectData.loading)
        ? <p><em>Loading...</em></p>
        :
        <div>
            {(displayOption==="details")
                ?<h1>Choose task to view detais:</h1>
                :<h1>Choose task to update:</h1>
            }
            {projectData.data.map(project =>
                <div>
                    
                    <input className="hide" id={"hd-"+project.id} type="checkbox"/>
                    <label htmlFor={"hd-"+project.id}>{project.name}</label>
                    <div>
                        
                        {project.tasks.map(task=>
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

