import { Component, NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { DepartmentService } from '../../services/department.service';
import { PersonViewModel } from '../../models/person-view-model';
import { DepartmentViewModel } from '../../models/department-view-model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ViewChild } from '@angular/core';

@Component({
  selector: 'app-people-list',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})

export class PeopleComponent {

  dataSource = new MatTableDataSource<PersonViewModel>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  error: string = '';
  person?: PersonViewModel;
  people: PersonViewModel[] = [];
  departments: DepartmentViewModel[] = [];
  personBeingEdited: any = null;
  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'dateOfBirth',
    'departmentName',
    'actions'
  ];

  constructor(
    private personService: PersonService,
    private departmentService: DepartmentService
  ) {
    this.getAllPeople();
    this.getAllDepartments();
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  getPersonById(id: number): void {
    this.personService.getById(id).subscribe({
      next: (result) => {
        this.person = result;
      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  getAllPeople(): void {
    this.personService.getAll().subscribe({
      next: (result) => {
        this.dataSource.data = result;

      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  addPerson() {
    this.personBeingEdited = {
      id: -1,
      firstName: '',
      lastName: '',
      email: '',
      dateOfBirth: '',
      departmentId: undefined
    } as unknown;
  }

  editPerson(person: any) {
    this.personBeingEdited = person;
  }

  deletePerson(person: any) {
    const confirmed = confirm(`Are you sure you want to delete ${person.firstName} ${person.lastName}?`);
    if (!confirmed) {
      return;
    }
    this.dataSource.data = this.dataSource.data.filter(p => p.id !== person.id);
    this.dataSource.data = [...this.dataSource.data];
  }
   
  getAllDepartments(): void {
    this.departmentService.getAll().subscribe({
      next: (result) => {
        this.departments = result;
      },
      error: (e) => { this.error = `Error: ${e}`; }
    });
  }

  cancelEdit() {
    this.personBeingEdited = null;
  }

  savePerson(updatedPerson: any) {
    
    if (!updatedPerson || !updatedPerson.id) {
      this.error = 'Invalid person data';
      return;
    }

    this.personService.save(updatedPerson).subscribe({
      next: (result) => {
        const index = this.dataSource.data.findIndex(p => p.id === updatedPerson.id);
        if (index !== -1) {
          updatedPerson.departmentName = this.departments.find(d => d.id === updatedPerson.departmentId)?.name || '';
          this.dataSource.data[index] = updatedPerson;
        }
        else {
          this.dataSource.data.push(updatedPerson);
        }
        this.dataSource.data = [...this.dataSource.data]; // trigger change in mat-table
        this.personBeingEdited = null;
      },
      error: (e) => { this.error = `Error: ${e.error}`; }
    });

  }


}
