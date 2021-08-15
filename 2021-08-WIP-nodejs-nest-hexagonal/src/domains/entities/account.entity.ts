import { ActivityWindowEntity } from "./activity-window.entity"
import { ActivityEntity } from "./activity.entity"
import { MoneyEntity } from "./money.entity"

export type AccountId = string

export class AccountEntity {
    constructor(
        private readonly _id: AccountId,
        private readonly _baseLineBalance: MoneyEntity,
        private readonly _activityWindow: ActivityWindowEntity
    ) {}

    get id(): AccountId {
        return this._id
    }

    get baseLineBalance(): MoneyEntity {
        return this._baseLineBalance
    }

    get activityWindow(): ActivityWindowEntity {
        return this._activityWindow
    }

    public calculateBalance(): MoneyEntity {
        return MoneyEntity.sum(
            this.baseLineBalance,
            this._activityWindow.calculateBalance(this.id)
        )
    }

    public deposit(value: MoneyEntity, sourceAccountId: AccountId): boolean {
        // todo: check if deposit is possible

        const depo: ActivityEntity = new ActivityEntity(
            this.id,
            sourceAccountId,
            this.id,
            new Date(),
            value
        )
        this._activityWindow.addActivity(depo)
        return true
    }

    public withdraw(value: MoneyEntity, targetAccountId: AccountId): boolean {
        if (!this.mayWithdraw(value)) return false

        const withdrawal: ActivityEntity = new ActivityEntity(
            this.id,
            this.id,
            targetAccountId,
            new Date(),
            value
        )
        this._activityWindow.addActivity(withdrawal)
        return true
    }

    public mayWithdraw(value: MoneyEntity): boolean {
        return MoneyEntity.diff(this.calculateBalance(), value).amount.isGreaterThanOrEqualTo(0)
    }
}