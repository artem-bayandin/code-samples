import React from 'react'

import { QuizListItemComponent } from './QuizListItem/QuizListItemComponent'

export const QuizListComponent = (props) => {
    const { play, answers, items } = props
    return (
        <>
            <div>{props.header}</div>
            {
                items.map(item => <QuizListItemComponent
                                    key={item.id}
                                    itemId={item.id}
                                    name={item.name}
                                    view
                                    play={play}
                                    answers={answers} />)
            }
        </>
    )
}