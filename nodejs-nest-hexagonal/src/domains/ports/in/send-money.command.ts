import { AccountId } from "../../entities/account.entity"
import { MoneyEntity } from "../../entities/money.entity"

export class SendMoneyCommand {
    constructor(
        private readonly _sourceAccountId: AccountId,
        private readonly _targetAccountId: AccountId,
        private readonly _amount: MoneyEntity
    ) {}

    get sourceAccountId(): AccountId {
        return this._sourceAccountId
    }

    get targetAccountId(): AccountId {
        return this._targetAccountId
    }

    get amount(): MoneyEntity {
        return this._amount
    }
}