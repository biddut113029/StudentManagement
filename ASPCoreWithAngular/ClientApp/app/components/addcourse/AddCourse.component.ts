﻿import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchStudentComponent } from '../fetchstudent/fetchstudent.component';
import { CourseService } from '../../services/crsservice.service';
import { StudentService } from '../../services/stdservice.service';

@Component({
    selector: 'createcourse',
    templateUrl: './AddCourse.component.html'
})

export class createcourse implements OnInit {
    courseForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    nameList: any;  
    stdList: any;
    data: any;   
   
    nameId:number; 




    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _studentService: CourseService, private _takeStudentService: StudentService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

   
        this._studentService.getCourses().subscribe(
            data => this.nameList = data
        )
        this._takeStudentService.getStudents().subscribe(
            data => this.stdList = data
        )
     

   
        this.courseForm = this._fb.group({
            id: 0,
            credit: ['', [Validators.required]],
            course: ['', [Validators.required]],
            student: ['', [Validators.required]],
            semester: ['', [Validators.required]]
        })
    }

    ngOnInit() {

     


        if (this.id > 0) {
            this.title = "Edit";
            this._studentService.getCourseById(this.id)
                .subscribe(resp => this.courseForm.setValue(resp)
                , error => this.errorMessage = error);
        }
    }

   

    save() {

        if (!this.courseForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._studentService.saveCourse(this.courseForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-student']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._studentService.updateCourse(this.courseForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-student']);
                }, error => this.errorMessage = error) 
        }
    }

    cancel() {
        this._router.navigate(['/fetch-student']);
    }

    get credit() { return this.courseForm.get('credit'); }
    get course() { return this.courseForm.get('course'); }
    get student() { return this.courseForm.get('student'); }
    get semester() { return this.courseForm.get('semester'); }
}