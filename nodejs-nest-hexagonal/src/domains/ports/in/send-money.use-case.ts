import { SendMoneyCommand } from "./send-money.command"

// because JS is not so good with DI
export const SendMoneyUseCaseSymbol = Symbol('SendMoneyUseCase')

export interface SendMoneyUseCase {
    sendMoney(command: SendMoneyCommand): Promise<boolean>
}