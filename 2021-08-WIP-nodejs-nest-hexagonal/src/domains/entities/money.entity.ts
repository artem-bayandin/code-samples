import { BigNumber } from "bignumber.js"

export class MoneyEntity {
    constructor(private readonly _amount: BigNumber) { }

    static ZERO() {
        return new MoneyEntity(new BigNumber(0))
    }

    static of(value: number) {
        return new MoneyEntity(new BigNumber(value))
    }

    get amount(): BigNumber {
        return this._amount
    }

    static sum(a: MoneyEntity, b: MoneyEntity): MoneyEntity {
        return new MoneyEntity(a.amount.plus(b.amount))
    }

    static diff(a: MoneyEntity, b: MoneyEntity) {
        return new MoneyEntity(a.amount.minus(b.amount))
    }
}