import React from 'react'
import { Switch, Route } from 'react-router'

import * as paths from './constants'
import * as pages from '../pages'
import { NotFound } from './NotFound'

export const RouterConfig = (props) => {
    return (
        <Switch>
            <Route exact path={paths.ROOT} render={(props) => <pages.IndexPage {...props} />} />
            <Route exact path={paths.QUIZ_LIST} render={(props) => <pages.QuizListPage {...props} />} />
            <Route exact path={paths.QUIZ_ITEM} render={(props) => <pages.QuizItemPage {...props} />} />
            <Route exact path={paths.QUIZ_ITEM_PLAY} render={(props) => <pages.QuizPlayPage {...props} />} />
            <Route exact path={paths.RESULTS_LIST} render={(props) => <pages.ResultsListPage {...props} />} />
            <Route exact path={paths.RESULTS_ITEM} render={(props) => <pages.ResultsItemPage {...props} />} />
            <Route path="*" component={NotFound} />
        </Switch>
    )
}