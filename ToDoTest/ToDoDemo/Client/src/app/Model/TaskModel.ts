export interface ITaskModel {
 
    id:number;
    name: string;
    isCompleted: boolean;
}

export class TaskModel implements ITaskModel {
    id:any;
    name: any;
    isCompleted: any;
 
}