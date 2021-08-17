export const PART_QUIZ = `quiz`
export const PART_QUIZ_PLAY = `play`
export const PART_RESULTS = `results`

export const ROOT = `/`
export const QUIZ_LIST = `/${PART_QUIZ}`
export const QUIZ_ITEM = `${QUIZ_LIST}/:id`
export const QUIZ_ITEM_PLAY = `${QUIZ_ITEM}/${PART_QUIZ_PLAY}`
export const RESULTS_LIST = `/${PART_RESULTS}`
export const RESULTS_ITEM = `${RESULTS_LIST}/:id`
