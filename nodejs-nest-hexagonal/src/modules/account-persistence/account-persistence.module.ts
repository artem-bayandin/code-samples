import { Global, Module } from "@nestjs/common"
import { TypeOrmModule } from "@nestjs/typeorm";
import { SendMoneyUseCaseSymbol } from "src/domains/ports/in/send-money.use-case";
import { SendMoneyService } from "src/domains/services/send-money.service";
import { AccountPersistenceAdapter } from "./account-persistence.adapter";
import { AccountOrmEntity } from "./entities/account.orm-entity";
import { ActivityOrmEntity } from "./entities/activity.orm-entity";

@Global()
@Module({
    imports: [
        TypeOrmModule.forFeature([AccountOrmEntity, ActivityOrmEntity])
    ],
    providers: [
        AccountPersistenceAdapter,
        {
            provide: SendMoneyUseCaseSymbol,
            useFactory: (accountPersistenceAdapter) => {
                return new SendMoneyService(accountPersistenceAdapter, accountPersistenceAdapter)
            },
            inject: [AccountPersistenceAdapter]
        }
    ],
    exports: [SendMoneyUseCaseSymbol]
})
export class AccountPersistenceModule {
}