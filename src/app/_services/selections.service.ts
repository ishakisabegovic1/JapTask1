import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/Pagination';
import { Selection } from '../_models/Selection';
import { SelectionClass } from '../_models/SelectionClass';
import { SelectionParams } from '../_models/SelectionParams';

@Injectable({
  providedIn: 'root'
})
export class SelectionsService {
  baseUrl = environment.apiUrl;
  selectionParams: SelectionParams;
  paginatedResult: PaginatedResult<Selection[]> = new PaginatedResult<Selection[]>();

  constructor(private http: HttpClient) { }

  getSelections() {
    return this.http.get<Selection[]>(this.baseUrl+'Selections');
  }

  getSelectionsP(page?:number, itemsPerPage?: number, nameFilter?: string, japFilter?:string, 
    statusFilter?:string, orderBy?:string, startDate?:Date, endDate?:Date){
    let params = new HttpParams();
    if(page != null && itemsPerPage != null){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
      if(nameFilter != null) params = params.append('nameFilter',nameFilter);
      if(japFilter != null) params = params.append('japFilter',japFilter);
      if(statusFilter != null) params = params.append('statusFilter',statusFilter);
      if(orderBy != null) params = params.append('OrderBy', orderBy.toString());
      if(startDate != null) params = params.append('dateFilter', startDate.toString());    
      if(endDate != null) params = params.append('endDateFilter', endDate.toString());   
    }

    return this.http.get<Selection[]>(this.baseUrl+'Selections', { observe: 'response', params}).pipe(
      map(response => {
        this.paginatedResult.result=response.body;
        
        if(response.headers.get('Pagination') != null){
          this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        console.log(this.paginatedResult.pagination);
        console.log(response);
        return this.paginatedResult;
      })

    );
  }

  getSelection(id: number){
    return this.http.get<Selection>(this.baseUrl+'Selections/'+id);
  }

  updateSelection(selection: Selection){
    return this.http.put<Selection>(this.baseUrl + 'Selections/edit-selection/'+ selection.id, selection);
  }

  addSelection(selection: SelectionClass){
    console.log(selection);
    return this.http.post<SelectionClass>(this.baseUrl +'Selections/add-selection', selection);
  }

  deleteSelection(id:number){
    return this.http.delete<Selection>(this.baseUrl+'Selections/delete-selection/'+id);
  }

}
