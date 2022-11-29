import { Page } from 'src/app/models/page';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, map, first } from 'rxjs';
import { ContractorMaterial } from './../app/models/contractorMaterials';
import { PagedData } from './../app/models/paged-data';
import { environment } from './../environments/environment';
import { Injectable } from '@angular/core';

class GetProducerList {
  public conctractorMaterials : Array<ContractorMaterial> = new Array();
  public pagesCount: number = 0;
  public totalElements: number = 0;
}

@Injectable({providedIn: 'root'})
export class ContractorMaterialService {
  public url: string =  environment.backendUrl + "api/ConctractorMaterial";

  constructor(private http: HttpClient) { }

  public GetAll(pageNumber: number) : Observable<PagedData<ContractorMaterial>>{
    return this.http.get<GetProducerList>(this.url + "/GetAll" + `?page=${pageNumber}`).pipe(
      map(data => {
        let pageData = new PagedData<ContractorMaterial>();
        pageData.data = data.conctractorMaterials;
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
    return this.http.get<ContractorMaterial>(this.url + "/" + id).pipe(first());
  }

  public Create(body: any) {
    return this.http.post(this.url, JSON.stringify(body), {'headers': new HttpHeaders().set("content-type", "application/json")});
  }

  public Update(body: ContractorMaterial) {
    return this.http.put(this.url, JSON.stringify(body), {'headers': new HttpHeaders().set("content-type", "application/json")});
  }

  public Delete(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
