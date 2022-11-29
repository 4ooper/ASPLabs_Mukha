import { PagedData } from './../app/models/paged-data';
import { environment } from './../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Producer } from 'src/app/models/producers';
import { first, map, Observable } from 'rxjs';
import { Page } from 'src/app/models/page';

class GetProducerList {
  public producers : Array<Producer> = new Array();
  public pagesCount: number = 0;
  public totalElements: number = 0;
}

interface IService {
  url: string;
}


interface GetProducerSearchList {
  producers: Array<Producer>
}

@Injectable({providedIn: 'root'})
export class ProducerService implements IService {
  public url: string =  environment.backendUrl + "api/Producer";

  constructor(private http: HttpClient) { }

  public GetAll(pageNumber: number) : Observable<PagedData<Producer>>{
    return this.http.get<GetProducerList>(this.url + "/GetAll/" + `?page=${pageNumber}`).pipe(
      map(data => {
        let pageData = new PagedData<Producer>();
        pageData.data = data.producers;
        let page = new Page();
        page.size = 15;
        page.totalElements = data.totalElements;
        page.totalPages = data.pagesCount;
        page.pageNumber = pageNumber;
        pageData.page = page;
        return pageData;
      })
    );
  }

  public GetListSearch(searchText: string) {
    return this.http.get<GetProducerSearchList>(this.url + "/Search/" + `?searchText=${searchText}`).pipe(first());
  }

  public Get(id: number) {
    return this.http.get<Producer>(this.url + "/" + id).pipe(first());
  }

  public Create(body: any) {
    return this.http.post(this.url, JSON.stringify(body), {'headers': new HttpHeaders().set("content-type", "application/json")});
  }

  public Update(body: Producer) {
    return this.http.put(this.url, JSON.stringify(body), {'headers': new HttpHeaders().set("content-type", "application/json")});
  }

  public Delete(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
