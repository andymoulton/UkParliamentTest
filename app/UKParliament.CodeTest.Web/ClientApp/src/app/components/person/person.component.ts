import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormsModule, FormGroup, Validators } from '@angular/forms';
import { PersonViewModel } from '../../models/person-view-model';
import { DepartmentViewModel } from '../../models/department-view-model';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person.component.html',
  styleUrl: './person.component.scss'
})

export class PersonComponent implements OnChanges {

  @Input() person!: PersonViewModel;
  @Input() departments: DepartmentViewModel[] = [];
  @Output() save = new EventEmitter<PersonViewModel>();
  @Output() cancel = new EventEmitter<void>();

  editedPerson: any = {};

  ngOnChanges(changes: SimpleChanges) {
    if (changes['person'] && changes['person'].currentValue) {
      this.editedPerson = { ...changes['person'].currentValue };
    }
  }

  //ngOnInit() {
  //  this.personForm = this.fb.group({
  //    id: [null],
  //    name: ['', [Validators.required, Validators.minLength(2)]],
  //    email: ['', [Validators.required, Validators.email]],
  //    age: [null, [Validators.min(0), Validators.max(150)]],
  //  });
  //}

  //ngOnChanges() {
  //  // Clone to avoid mutating original object directly
  //  this.editedPerson = { ...this.person };
  //}

  onSave() {
    this.save.emit(this.editedPerson);
  }

  onCancel() {
    this.cancel.emit();
  }

}
