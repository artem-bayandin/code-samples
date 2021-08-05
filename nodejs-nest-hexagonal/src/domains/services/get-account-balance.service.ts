import { MoneyEntity } from "../entities/money.entity"
import { GetAccountBalanceQuery } from "../ports/in/get-account-balance.query"
import { LoadAccountPort } from "../ports/out/load-account.port"

export class GetAccountBalanceService implements GetAccountBalanceQuery {
    constructor(private readonly _loadAccountPort: LoadAccountPort) {}

    async getAccountBalance(accountId: string): Promise<MoneyEntity> {
        const account = await this._loadAccountPort.loadAccount(accountId)
        return account.calculateBalance()
    }

}