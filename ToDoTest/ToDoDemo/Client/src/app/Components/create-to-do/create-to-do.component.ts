import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ITaskModel } from 'src/app/Model/TaskModel';
import { ToDoServiceService } from 'src/app/Services/to-do-service.service';

@Component({
  selector: 'app-create-to-do',
  templateUrl: './create-to-do.component.html',
  styleUrls: ['./create-to-do.component.css']
})
export class CreateToDoComponent implements OnInit {

  newTodo: string | undefined;
  todos: any;
  todoObj: any;
  taskList: any;
  isAdmin:any;
  constructor(public toDOService:ToDoServiceService, private router: Router) { }

  ngOnInit(): void {
    this.getAllTaskList()
    this.isAdmin = localStorage.getItem("isAdmin");
  }
  deleteTodo(index:number)
  {
    this.todoObj = {
      id: index,
    }
    this.toDOService.deleteTasks(this.todoObj).subscribe(
      (res) =>{
        debugger;
        this.getAllTaskList()
      },
      (err) => {}
    );
  }
  deleteSelectedTodos()
  {
   
  }
  getAllTaskList()
  {
    this.toDOService.getAllTask().subscribe(

      (res) => {
        debugger;
        this.taskList = res as ITaskModel[];
      },
      (err) => {}
    )
  }
  taskCheck(id:number,isCompleted:boolean)
  {
    this.todoObj = {
      id: id,
      isCompleted: isCompleted
    }
    this.toDOService.editTasks(this.todoObj).subscribe(
      (res) =>{
        debugger;
        this.getAllTaskList()
      },
      (err) => {}
    );
  }
  addTodo()
  {
    this.todoObj = {
      name: this.toDOService.taskModel.name,
      isCompleted: false
    }
    this.toDOService.addTasks().subscribe(
      (res) =>{
        debugger;
        this.getAllTaskList()
      },
      (err) => {}
    );
  }




}
