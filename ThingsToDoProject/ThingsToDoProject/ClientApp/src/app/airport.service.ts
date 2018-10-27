export class Airport {
    area: string = 'InsideOutsideAirport';
    input: string;
    test:{}[]=[{name:'shreea',age:23}];

    getInput() {
        return this.input;
    }

    setArea(area) {
        console.log(area);
        this.area = area; 
    }

    setInput(input) {
        console.log(input);
       
         this.input = input; 
    }
}