import { mock, when, anything, anyString, instance } from "ts-mockito"
import { AccountEntity, AccountId } from "../entities/account.entity"
import { MoneyEntity } from "../entities/money.entity"
import { SendMoneyCommand } from "../ports/in/send-money.command"
import { LoadAccountPort } from "../ports/out/load-account.port"
import { UpdateAccountStatePort } from "../ports/out/update-account-state.port"
import { SendMoneyService } from "./send-money.service"

describe('SendMoneyService', () => {
    it('should send transaction', () => {
        const loadAccountPortMock = mock<LoadAccountPort>()
        const updateAccountStatePortMock = mock<UpdateAccountStatePort>()

        function mockAccountWithId(id: AccountId): AccountEntity {
            const mockedAccountEntity = mock(AccountEntity)
            when(mockedAccountEntity.id).thenReturn(id)
            when(mockedAccountEntity.mayWithdraw(anything())).thenReturn(true)
            when(mockedAccountEntity.withdraw(anything(), anyString())).thenReturn(true)
            when(mockedAccountEntity.deposit(anything(), anyString())).thenReturn(true)
            const account = instance(mockedAccountEntity)
            when(loadAccountPortMock.loadAccount(id)).thenReturn(account)
            return account
        }

        const sourceAccount = mockAccountWithId('a')
        const targetAccount = mockAccountWithId('b')

        const command = new SendMoneyCommand(
            sourceAccount.id,
            targetAccount.id,
            MoneyEntity.of(101)
        )

        const sendMoneyService = new SendMoneyService(
            instance(loadAccountPortMock),
            instance(updateAccountStatePortMock)
        )

        const result = sendMoneyService.sendMoney(command)

        expect(result).toBeTruthy()
    })
})