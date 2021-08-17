import React from 'react'

import { QuizListItemComponent } from '../../components'

export const QuizListContainer = (props) => {
    const { play, results, items } = props
    return (
        <>
            <div>{props.header}</div>
            {
                items.map(item => <QuizListItemComponent
                                    itemId={item.id}
                                    name={item.name}
                                    view
                                    play={play}
                                    results={results} />)
            }
        </>
    )
}