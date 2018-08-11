import { HttpService } from './http.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Restful Tasks API';
  tasks = [];
  task: any;
  shouldDisplayTasks: boolean;
  shouldDisplayTask: boolean;
  constructor(private _httpService: HttpService){
  }
  ngOnInit() {
    this.getTasksFromService();
  }
  getTasksFromService(){
    let observable = this._httpService.getTasks();
    observable.subscribe(data => {
      console.log("Got our tasks!", data);
      this.tasks = data.tasks;
    })
  }
  hideSection($event){
    $event.stopPropagation();
    this.shouldDisplayTasks = false;
  }
  showTasks(){
    this.shouldDisplayTasks = true;
  }
  showTask(task){
    this.shouldDisplayTask = true;
    this.task = task;
  }
}
