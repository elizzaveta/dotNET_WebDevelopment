import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";
import {json} from "../../commonFunctions";

export default function ProjectList() {
    const url = `https://localhost:5001/projects`;
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
        <div className="table-responsive">
            <table className="table table-striped">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                {projectData.data.map(project =>
                    <tr>
                        <td>{project.id}</td>
                        <td>{project.name}</td>
                        <td>
                            <div className="btn-group-vertical">
                                <Link to={"/all-projects/project/"+project.id}>
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

