import {Component} from 'angular2/core'

@Component({
    selector: 'courses',
    template: `<h2> ddd </h2> 
    <div> {{ title }} </div>
    <ul>
    <li *ngFor="#course of courses"> 
    {{ course }}
    </li>
    </ul>
    `
})

export class CoursesComponent{
    title = "Title of this component";
    courses = ["C1", "C2", "C3"]
}