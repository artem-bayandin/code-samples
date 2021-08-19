import { Injectable } from "@nestjs/common"
import { InjectRepository } from "@nestjs/typeorm"
import { AccountEntity } from "src/domains/entities/account.entity"
import { LoadAccountPort } from "src/domains/ports/out/load-account.port"
import { UpdateAccountStatePort } from "src/domains/ports/out/update-account-state.port"
import { Repository } from "typeorm"
import { AccountOrmEntity } from "./entities/account.orm-entity"
import { ActivityOrmEntity } from "./entities/activity.orm-entity"
import { AccountMapper } from "./mappers/account.mapper"

@Injectable()
export class AccountPersistenceAdapter implements LoadAccountPort, UpdateAccountStatePort {
    constructor(
        @InjectRepository(AccountOrmEntity) private readonly _accountRepository: Repository<AccountOrmEntity>,
        @InjectRepository(ActivityOrmEntity) private readonly _activityRepository: Repository<ActivityOrmEntity>
    ) {}
    
    async loadAccount(accountId: string): Promise<AccountEntity> {
        const account = await this._accountRepository.findOne({userId: accountId})
        if (!account) throw new Error('account not found')
        const activities = await this._activityRepository.find({ownerAccountId: accountId})
        return AccountMapper.mapToDomain(account, activities)
    }
    
    async updateActivities(account: AccountEntity) {
        account.activityWindow.activities.forEach(async activity => {
            if (!activity.id) {
                await this._activityRepository.save(AccountMapper.mapToActivityOrmEntity(activity))
            }
        })
    }
}