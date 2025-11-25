class ArmstrongNumbers {

  private digits: number[]
  private exponent: number

  constructor() {
    this.digits = []
    this.exponent = 0
  }

  private getSummedPowers(): number {
    return this.digits.reduce((acc: number, item: number): number => acc + (item ** this.exponent), 0)
  }

  public isArmstrongNumber(number: number): boolean {
    this.digits = number
      .toString()
      .split('')
      .map(Number)

    this.exponent = this.digits.length

    return this.getSummedPowers() === number
  }
}

export default new ArmstrongNumbers()