export const PART_QUIZ = `quiz`
export const PART_QUIZ_PLAY = `play`
export const PART_ANSWERS = `answers`

export const ROOT = `/`
export const QUIZ_LIST = `/${PART_QUIZ}`
export const QUIZ_ITEM = `${QUIZ_LIST}/:id`
export const QUIZ_ITEM_PLAY = `${QUIZ_ITEM}/${PART_QUIZ_PLAY}`
export const ANSWERS_LIST = `/${PART_ANSWERS}`
export const ANSWERS_ITEM = `${ANSWERS_LIST}/:id`
