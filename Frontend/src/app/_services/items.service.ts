import { ItemClass } from './../_models/ItemClass';
import { Item } from './../_models/Item';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { identifierModuleUrl } from '@angular/compiler';
import { PaginatedResult } from '../_models/Pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  baseUrl = environment.apiUrl;
  paginatedResult: PaginatedResult<Item[]> = new PaginatedResult<Item[]>();
  constructor(private http: HttpClient) { }

  // getItems(){
  //   return this.http.get<Item[]>(this.baseUrl+'Items');
  // }

  getItems(page?: number, itemsPerPage?: number, nameFilter?:string,
    descFilter?:string, urlFilter?:string, orderBy?:string){
      let params = new HttpParams();
      if(page != null && itemsPerPage != null){
        params = params.append('pageNumber', page.toString());
        params = params.append('pageSize', itemsPerPage.toString());
        if(nameFilter != null) params = params.append('nameFilter', nameFilter);
        if(descFilter != null) params = params.append('descFilter', descFilter);
        if(urlFilter != null) params = params.append('urlFilter', urlFilter);
        if(orderBy != null) params = params.append('OrderBy', orderBy.toString());
      }
    return this.http.get<Item[]>(this.baseUrl+'Items', {observe: 'response', params}).pipe(
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

  getItemById(id: number){
    return this.http.get<ItemClass>(this.baseUrl+'Items/'+id);
  }

  addItem(item: ItemClass){
    return this.http.post<ItemClass>(this.baseUrl+'Items/add-item',item);
  }

  editItem(item: ItemClass){
    return this.http.put<ItemClass>(this.baseUrl+'Items/edit-item/'+item.id, item)
  }

  deleteItem(id: number){
    return this.http.delete<ItemClass>(this.baseUrl+'Items/delete-item/' +id);
  }
}
