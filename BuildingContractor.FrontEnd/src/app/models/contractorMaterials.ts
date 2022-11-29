import { Producer } from 'src/app/models/producers';
export class ContractorMaterial {
  public id: number;
  public name: string;
  public createdDate: Date;
  public validaty: Date;
  public producer: Producer;
  [key: string] : any;
  constructor(id:number, name: string, createdDate: Date, validaty: Date, producer: Producer) {
    this.id = id;
    this.name = name;
    this.createdDate = createdDate;
    this.validaty = validaty;
    this.producer = producer;
  }
}
