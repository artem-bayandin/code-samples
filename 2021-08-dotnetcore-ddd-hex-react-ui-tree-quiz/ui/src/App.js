import React, { useEffect } from 'react'
import { useDispatch } from 'react-redux'
import { Switch, Route } from 'react-router'
import { checkUserIdAndCreateUserIfNeeded } from './redux-toolkit-store'

import { Layout } from './layout'
import { NotFound, Routes } from './navigation'
import * as Pages from './pages'

const App = (props) => {

    // definitely not a good way to check Auth
    // a separate AuthContainer should be created
    const dispatch = useDispatch()
    useEffect(() => {
        dispatch(checkUserIdAndCreateUserIfNeeded())
    }, [])

    return (
        <>
            <Layout>
                <Switch>
                    <Route exact path={Routes.ROOT} render={(props) => <Pages.IndexPage {...props} />} />
                    <Route exact path={Routes.QUIZ_LIST} render={(props) => <Pages.QuizListPage {...props} />} />
                    <Route exact path={Routes.QUIZ_ITEM} render={(props) => <Pages.QuizItemPage {...props} />} />
                    <Route exact path={Routes.QUIZ_ITEM_PLAY} render={(props) => <Pages.QuizPlayPage {...props} />} />
                    <Route exact path={Routes.ANSWERS_LIST} render={(props) => <Pages.AnswersListPage {...props} />} />
                    <Route exact path={Routes.ANSWERS_ITEM} render={(props) => <Pages.AnswersItemPage {...props} />} />
                    <Route path="*" component={NotFound} />
                </Switch>
            </Layout>
        </>
    )
}

export default App