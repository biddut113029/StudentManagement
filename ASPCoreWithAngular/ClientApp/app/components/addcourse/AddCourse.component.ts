import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchStudentComponent } from '../fetchstudent/fetchstudent.component';
import { CourseService } from '../../services/crsservice.service';

@Component({
    selector: 'createcourse',
    templateUrl: './AddCourse.component.html'
})

export class createcourse implements OnInit {
    courseForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _studentService: CourseService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.courseForm = this._fb.group({
            id: 0,
            name: ['', [Validators.required]],
            gender: ['', [Validators.required]],
            department: ['', [Validators.required]],
            city: ['', [Validators.required]]
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

    get name() { return this.courseForm.get('name'); }
    get gender() { return this.courseForm.get('gender'); }
    get department() { return this.courseForm.get('department'); }
    get city() { return this.courseForm.get('city'); }
}