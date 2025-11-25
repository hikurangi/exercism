export default class Squares {

    private list: Array<number>
    private sum: number
    public squareOfSum: number
    public difference: number
    public sumOfSquares: number

    constructor(limit: number) {
        this.list = Array.from(Array(limit + 1).keys()).slice(1)
        this.sum = this.getSum()
        this.squareOfSum = this.sum * this.sum
        this.sumOfSquares = this.getSumOfSquares()
        this.difference = this.squareOfSum - this.sumOfSquares
    }

    private getSum() {
        return this.list.reduce((acc: number, item: number): number => {
            return acc + item
        })
    }

    private getSumOfSquares() {
        return this.list.reduce((acc: number, item: number): number => {
            return acc + (item * item)
        })
    }

}