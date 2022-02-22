import { Route } from 'react-router';
import React, {Component, useEffect, useState} from 'react';
import {Link, useParams} from "react-router-dom";

export default function Home(){
    
    return(
        <div>
            <h1>Choose what to do:</h1>
            <Link to="add-task">
                <p>Add task</p>
            </Link>
            <Link to="all-projects">
                <p>Get Project Tasks</p>
            </Link>
            <Link to="all-employees">
                <p>Get Employee Active Tasks </p>
            </Link>
        </div>    
    )
}