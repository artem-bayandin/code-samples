import React from 'react'

export const QuizTreeNodeComponent = ({node, relation, answers}) => {
    const { id, text, children } = node

    let containerClassName = 'tree-node'
    
    // this is very bad line of code
    if (Array.isArray(answers) && answers.some(item => item === id)) containerClassName += ' chosen'

    const nestedNodes = (children || []).map(child => {
        return <QuizTreeNodeComponent key={child.id} node={child.node} relation={child.relation} answers={answers} />
    })

    return (
        <div className={containerClassName}>
            { relation && <div className='relation'>{relation}</div>}
            <div>{text}</div>
            <div className='options'>
                {nestedNodes}
            </div>
        </div>
    )
}