export class Producer {
  public id: number;
  public name: string;
  [key: string] : any;
  constructor(id:number, name: string) {
    this.id = id;
    this.name = name;
  }

  toString() : string { return "something"; }
}
