import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { SharedRoutingModule } from './shared-routing.module';
import { NgbdSortableHeader } from './sortable.directive';

@NgModule({
  declarations: [
    NavbarComponent,
    HomeComponent,
    NgbdSortableHeader
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedRoutingModule,
  ],
  providers: [

  ],
  exports: [
    ReactiveFormsModule,
    FormsModule,
    NavbarComponent,
    NgbdSortableHeader
  ]
})
export class SharedModule { }
