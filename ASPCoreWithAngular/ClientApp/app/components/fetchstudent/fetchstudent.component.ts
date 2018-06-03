import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { StudentService } from '../../services/stdservice.service'
import { DataTableModule } from "angular2-datatable";
import { NgModule } from '@angular/core';

@Component({
    selector: 'fetchStudent',
    templateUrl: './fetchstudent.component.html'
})


@NgModule({
    imports: [
      
        DataTableModule,
     
    ],
 })
export class FetchStudentComponent {
    public stdList: StudentData[];
    public stdListTemp: StudentData[];
    public pageList: PageData[];

    public data = [];
    public pseudoServer = [];
    public filterQuery = "";
    public rowsOnPage = 5;
    public sortBy = "email";
    public sortOrder = "asc";
    public amountOfRows = 0;
    public activePage = 1;
    constructor(public http: Http, private _router: Router, private _StudentService: StudentService) {
        this.getStudents();
    }
    SetPage(page: any) {

        //this.activePage = page;
        //this.getStudents();
    }
    Next() {
        
        this.activePage = this.activePage + 1;
        this.getStudents();
    }
    Previous()
    {
        if (this.activePage!=1)
        this.activePage = this.activePage - 1;
        this.getStudents();
    }
    getStudents() {
        this._StudentService.getStudents().subscribe((data) => {
            setTimeout(() => {

                this.stdList = data;
                this.stdListTemp = data;
                this.load();
                
            }, 2000);

        
            });

        
    }




    delete(studentID) {
        var ans = confirm("Do you want to delete student with Id: " + studentID);
        if (ans) {
            this._StudentService.deleteStudent(studentID).subscribe((data) => {
                this.getStudents();
            }, error => console.error(error)) 
        }
    }


    public load() {
        this.pageList = [];
        this.amountOfRows = this.stdList.length;
      

         if (this.activePage == 1 && this.amountOfRows <= 5) {

            this.pageList = [             
                { id: this.activePage, status: 'blue' },
            ];
          
            let start = (this.activePage - 1) * this.rowsOnPage;
            this.stdList = this.stdList.slice(start, start + this.rowsOnPage);

        }
        else if (this.activePage == 1 && this.amountOfRows > 5 && this.amountOfRows <10 ) {

            this.pageList = [
                { id: this.activePage, status: 'blue' },
                { id: this.activePage+1, status: 'yellow' },
            ];
        
            let start = (this.activePage - 1) * this.rowsOnPage;
            this.stdList = this.stdList.slice(start, start + this.rowsOnPage);

        }
        else if (this.activePage == 1 && this.amountOfRows > 10 ) {

            this.pageList = [
                { id: this.activePage, status: 'blue' },
                { id: this.activePage+1, status: 'yellow' },
                { id: this.activePage+2, status: 'yellow' },
            ];
            
            let start = (this.activePage - 1) * this.rowsOnPage;
            this.stdList = this.stdList.slice(start, start + this.rowsOnPage);

        }
       else if (this.activePage == 2 && this.amountOfRows > 5 && this.amountOfRows < 10 )
        {
            this.pageList = [
                { id: this.activePage, status: 'blue' },
                { id: this.activePage + 1, status: 'yellow' },
                        
            ];
            
            let start = (this.activePage - 1) * this.rowsOnPage;
            this.stdList = this.stdList.slice(start, start + this.rowsOnPage);

        }
       else if (this.activePage == 2 && this.amountOfRows > 10 ) {
            this.pageList = [
                { id: this.activePage, status: 'blue' },
                { id: this.activePage + 1, status: 'yellow' },            
                { id: this.activePage + 2, status: 'yellow' },

            ];
            
            let start = (this.activePage - 1) * this.rowsOnPage;
            this.stdList = this.stdList.slice(start, start + this.rowsOnPage);

        }
       else if (this.activePage >= 3)
        {
            this.pageList = [
                { id: this.activePage - 1, status: 'yellow' },
                { id: this.activePage, status: 'blue' },
                { id: this.activePage + 1, status: 'yellow' }
            ];
            
            let start = (this.activePage - 1) * this.rowsOnPage;
            this.stdList = this.stdList.slice(start, start + this.rowsOnPage);
        }
     
    
        
        
    }

    public toInt(num: string) {
        return +num;
    }

  

    public onPageChange(event) {
        this.rowsOnPage = event.rowsOnPage;
        //this.activePage = event.activePage;
        this.activePage = 1;
        this.load();
    }





}




interface StudentData {
    id: number;
    name: string;
    gender: string;
    department: string;
    city: string;

    lastName: string;
    fatherName: string;
    motherName: string;
    contactNo: string;
    email: string;
}



interface PageData {
    id: number;
    status: string;
}