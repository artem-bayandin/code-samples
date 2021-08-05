import { AccountEntity } from "../entities/account.entity"
import { SendMoneyCommand } from "../ports/in/send-money.command"
import { SendMoneyUseCase } from "../ports/in/send-money.use-case"
import { LoadAccountPort } from "../ports/out/load-account.port"
import { UpdateAccountStatePort } from "../ports/out/update-account-state.port"

export class SendMoneyService implements SendMoneyUseCase {
    constructor(
        private readonly _loadAccountPort: LoadAccountPort,
        private readonly _updateAccountStatePort: UpdateAccountStatePort
    ) {}

    async sendMoney(command: SendMoneyCommand): Promise<boolean> {
        const sourceAccount: AccountEntity = await this._loadAccountPort.loadAccount(command.sourceAccountId)
        const targetAccount: AccountEntity = await this._loadAccountPort.loadAccount(command.targetAccountId)

        if (!sourceAccount.mayWithdraw(command.amount)) return false

        sourceAccount.withdraw(command.amount, command.targetAccountId)
        targetAccount.deposit(command.amount, command.sourceAccountId)
        this._updateAccountStatePort.updateActivities(sourceAccount)
        this._updateAccountStatePort.updateActivities(targetAccount)

        return true
    }
}