import {useEffect} from "react";

export function json(response) {
    return response.json()
}

export function post(url, json){
    const requestOptions = {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: json
    };
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(data => console.log(data));
}
export function put(url, json){
    const requestOptions = {
        method: 'PUT',
        headers: {'Content-Type': 'application/json'},
        body: json
    };
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(data => console.log(data));
}

