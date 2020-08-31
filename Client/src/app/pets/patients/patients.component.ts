import { Router } from '@angular/router';
import {DecimalPipe} from '@angular/common';
import {OnInit, Component, QueryList, ViewChildren} from '@angular/core';
import {Observable} from 'rxjs';

import {Country} from '../models/pet-list.model';
import {CountryService} from '../service/country.service';
import {NgbdSortableHeader, SortEvent} from '../../shared/sortable.directive';


@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css'],
  providers: [CountryService, DecimalPipe]
})
export class PatientsComponent implements OnInit {
  countries$: Observable<Country[]>;
  total$: Observable<number>;
  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;

  constructor(private router: Router, public service: CountryService) { 
    this.countries$ = service.countries$;
    this.total$ = service.total$;
  }
  
  ngOnInit(): void {
  }

  goToPersonalInfo(param) {
    this.router.navigate([`pets/patient-info/${param}`])
  }

  onSort({column, direction}: SortEvent) {
    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }
}
