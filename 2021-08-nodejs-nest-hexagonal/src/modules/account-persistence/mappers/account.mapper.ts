import { AccountEntity } from "src/domains/entities/account.entity"
import { ActivityWindowEntity } from "src/domains/entities/activity-window.entity"
import { ActivityEntity } from "src/domains/entities/activity.entity"
import { MoneyEntity } from "src/domains/entities/money.entity"
import { AccountOrmEntity } from "../entities/account.orm-entity"
import { ActivityOrmEntity } from "../entities/activity.orm-entity"

export class AccountMapper {
    static mapToDomain(
        account: AccountOrmEntity,
        activities: ActivityOrmEntity[]
    ) {
        const activityWindow = this.mapActivityWindowToDomain(
            activities
        )
        const balance = activityWindow.calculateBalance(account.userId)
        return new AccountEntity(
            account.userId,
            balance,
            activityWindow
        )
    }

    static mapActivityWindowToDomain(
        activities: ActivityOrmEntity[]
    ): ActivityWindowEntity {
        const activityWindowEntity = new ActivityWindowEntity()
        activities.forEach(activity => {
            const activityEntity = new ActivityEntity(
                activity.ownerAccountId,
                activity.sourceAccountId,
                activity.targetAccountId,
                new Date(activity.timestamp),
                MoneyEntity.of(activity.amount),
                activity.id
            )
            activityWindowEntity.addActivity(activityEntity)
        })
        return activityWindowEntity
    }

    static mapToActivityOrmEntity(activity: ActivityEntity): ActivityOrmEntity {
        const activityOrmEntity = new ActivityOrmEntity()
        activityOrmEntity.timestamp = activity.timestamp.getTime()
        activityOrmEntity.ownerAccountId = activity.ownerAccountId
        activityOrmEntity.sourceAccountId = activity.sourceAccountId
        activityOrmEntity.targetAccountId = activity.targetAccountId
        activityOrmEntity.amount = activity.money.amount.toNumber()
        if (activity.id) {
            activityOrmEntity.id = activity.id
        }
        return activityOrmEntity
    }
}