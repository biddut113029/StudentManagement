import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class CourseService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getCourses() {
        return this._http.get(this.myAppUrl + 'api/Course/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getCourseById(id: number) {
        return this._http.get(this.myAppUrl + "api/Course/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveCourse(Course) {
        return this._http.post(this.myAppUrl + 'api/Course/Create', Course)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateCourse(Course) {
        return this._http.put(this.myAppUrl + 'api/Course/Edit', Course)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteCourse(id) {
        return this._http.delete(this.myAppUrl + "api/Course/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}