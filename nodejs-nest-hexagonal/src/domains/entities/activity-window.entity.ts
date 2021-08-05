import { AccountId } from "./account.entity"
import { ActivityEntity } from "./activity.entity"
import { MoneyEntity } from "./money.entity"

export class ActivityWindowEntity {
    constructor() {}

    private readonly _activities: ActivityEntity[] = []

    get activities(): ActivityEntity[] {
        return this._activities
    }

    addActivity(activity: ActivityEntity) {
        this.activities.push(activity)
        return this
    }

    public calculateBalance(accountId: AccountId): MoneyEntity {
        const depositedBalance = this
            .activities
            .filter(activity => activity.targetAccountId == accountId)
            .map(activity => activity.money)
            .reduce(MoneyEntity.sum, MoneyEntity.ZERO())
        const withdrawalBalance = this
            .activities
            .filter(activity => activity.sourceAccountId == accountId)
            .map(activity => activity.money)
            .reduce(MoneyEntity.sum, MoneyEntity.ZERO())
        return new MoneyEntity(depositedBalance.amount.minus(withdrawalBalance.amount))
    }
}