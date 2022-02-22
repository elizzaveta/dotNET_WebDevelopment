import React, {Component} from 'react';
import {Route} from 'react-router';
import {Layout} from './components/Layout';
import Home from "./components/Home";
import TaskDetails from "./components/TaskDetails/TaskDetails";
import ProjectTaskTree from "./components/DisplayTasksTree/ProjectTaskTree";

import './custom.css'
import AddTask from "./components/AddTask/AddTask";
import ViewEmployeesTasks from "./components/ViewEmployeesTasks";
import UpdateStatus from "./components/UpdateTask/UpdateStatus";
import ProjectList from "./components/TaskList/ProjectList";
import ProjectTaskList from "./components/TaskList/ProjectTaskList";
import EmployeeList from "./components/TaskList/EmployeeList";
import EmployeeTaskList from "./components/TaskList/EmployeeTaskList";

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home}/>
                <Route exact path='/all-projects' component={ProjectList}/>
                <Route exact path='/all-employees' component={EmployeeList}/>
                <Route exact path="/all-projects/project/:projectId" component={ProjectTaskList}/>
                <Route exact path="/all-tasks/employee/:employeeId" component={EmployeeTaskList}/>
                <Route exact path='/all-tasks/task/:id' component={TaskDetails}/>
                <Route exact path='/all-tasks/info'><ProjectTaskTree option="details"/></Route>
                <Route path='/add-task' component={AddTask}/>
                {/*<Route exact path='/all-tasks/appoint-employee/task/:projectId/:taskId' component={UpdateEmployee}/>*/}
                {/*<Route path='/all-tasks/edit-employee'><ProjectTaskTree option='EditEmployee'/></Route>*/}
                <Route exact path='/all-tasks/edit-status'><ProjectTaskTree option='editStatus'/></Route>
                <Route path='/edit-task-status/:taskId' component={UpdateStatus}/>
                <Route path='/tasks-of-emp' component={ViewEmployeesTasks}/>
            </Layout>
        );
    }
}
