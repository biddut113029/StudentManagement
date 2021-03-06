﻿import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchStudentComponent } from '../fetchstudent/fetchstudent.component';
import { StudentService } from '../../services/stdservice.service';

@Component({
    selector: 'createstudent',
    templateUrl: './AddStudent.component.html'
})

export class createstudent implements OnInit {
    studentForm: FormGroup;
    title: string = "Create";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _studentService: StudentService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.studentForm = this._fb.group({
            id: 0,
            name: ['', [Validators.required]],
            gender: ['', [Validators.required]],
            department: ['', [Validators.required]],
            city: ['', [Validators.required]],
            lastName: ['', [Validators.required]],
            fatherName: ['', [Validators.required]],
            motherName: ['', [Validators.required]],
            contactNo: ['', [Validators.required]],
            email: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "Edit";
            this._studentService.getStudentById(this.id)
                .subscribe(resp => this.studentForm.setValue(resp)
                , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.studentForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._studentService.saveStudent(this.studentForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-student']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._studentService.updateStudent(this.studentForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-student']);
                }, error => this.errorMessage = error) 
        }
    }

    cancel() {
        this._router.navigate(['/fetch-student']);
    }

    get name() { return this.studentForm.get('name'); }
    get gender() { return this.studentForm.get('gender'); }
    get city() { return this.studentForm.get('city'); }
    get department() { return this.studentForm.get('department'); }
    get lastName() { return this.studentForm.get('lastName'); }
    get fatherName() { return this.studentForm.get('fatherName'); }
    get motherName() { return this.studentForm.get('motherName'); }
    get contactNo() { return this.studentForm.get('contactNo'); }
    get email() { return this.studentForm.get('email'); }
   
}