import { Page } from 'src/app/models/page';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map, first } from 'rxjs';
import { PagedData } from './../app/models/paged-data';
import { environment } from './../environments/environment';
import { Contractor } from './../app/models/contractor';
import { Injectable } from '@angular/core';

interface GetContractorList {
  contractors : Array<Contractor>;
  pagesCount: number;
  totalElements: number;
}

@Injectable({providedIn: 'root'})
export class ContractorService {
  public url: string =  environment.backendUrl + "api/Contractor";

  constructor(private http: HttpClient) { }


  public GetAll(pageNumber: number) : Observable<PagedData<Contractor>>{
    return this.http.get<GetContractorList>(this.url + "/GetAll/" + `?page=${pageNumber}`).pipe(
      map(data => {
        let pageData = new PagedData<Contractor>();
        pageData.data = data.contractors;
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

  public Get(id: number) {
    return this.http.get<Contractor>(this.url + "/" + id).pipe(first());
  }

  public Create(body: any) {
    return this.http.post(this.url, JSON.stringify(body), {'headers': new HttpHeaders().set("content-type", "application/json")});
  }

  public Update(body: Contractor) {
    return this.http.put(this.url, JSON.stringify(body), {'headers': new HttpHeaders().set("content-type", "application/json")});
  }

  public Delete(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
