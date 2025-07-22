import { Component } from '@angular/core';
import { PersonService } from '../../services/person.service';
import { PersonViewModel } from '../../models/person-view-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  message: string = 'Hello from Angular!';
  person?: PersonViewModel;
  people?: PersonViewModel[];

  constructor(private personService: PersonService) {
    this.getPersonById(1);
    this.getAllPeople();
  }

  getPersonById(id: number): void {
    this.personService.getById(id).subscribe({
      next: (result) => {
        this.person = result;
        //console.info(`User returned: ${JSON.stringify(result)}`)
      },
      error: (e) => console.error(`Error: ${e}`)
    });
  }

  getAllPeople(): void {
    this.personService.getAll().subscribe({
      next: (result) => {
        this.people= result;
      },
      error: (e) => console.error(`Error: ${e}`)
    });

  }

}
