import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TaskModel } from '../Model/TaskModel';

@Injectable({
  providedIn: 'root'
})
export class ToDoServiceService {
 taskModel = new TaskModel();
  constructor(private http: HttpClient) { }

  getAllTask()
  {
    debugger;
    return this.http.get( 'https://localhost:7186/api/ToDo/getalltask');
  }
  addTasks()
  {
    debugger;
    return this.http.post( 'https://localhost:7186/api/ToDo/createtask',this.taskModel);
  }
  editTasks(todoObj:TaskModel)
  {
    debugger;
    return this.http.post( 'https://localhost:7186/api/ToDo/edittask',todoObj);
  }
  deleteTasks(todoObj:TaskModel)
  {
    debugger;
    return this.http.post( 'https://localhost:7186/api/ToDo/deletetask',todoObj);
  }
}
