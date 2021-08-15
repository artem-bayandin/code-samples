import { Column, Entity, PrimaryGeneratedColumn } from "typeorm"

@Entity({})
export class AccountOrmEntity {
    @PrimaryGeneratedColumn()
    id: number

    @Column()
    userId: string
}