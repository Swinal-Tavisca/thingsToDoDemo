export class Data {
    constructor(
        public address: string,
        public latitude: string,
        public longitude: string,
        public name: string,
        public openClosedStatus: string,
        public photoReference:string,
        public placeID:string,
        public rating:number,
        public vicinity:string
    ){}
}