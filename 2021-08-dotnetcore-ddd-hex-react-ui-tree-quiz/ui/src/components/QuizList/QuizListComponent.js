import React from 'react'
import './QuizListComponent.css'

import { QuizListItemComponent } from './QuizListItem/QuizListItemComponent'

export const QuizListComponent = (props) => {
    const { play, answers, items } = props
    return (
        <div className='quiz-list-component'>
            <div className='header'>{props.header}</div>
            {
                items.map(item => <QuizListItemComponent
                                    key={item.id}
                                    itemId={item.id}
                                    name={item.name}
                                    view
                                    play={play}
                                    answers={answers} />)
            }
        </div>
    )
}