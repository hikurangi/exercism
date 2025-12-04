use std::{collections::HashMap, ops::ControlFlow};

const SQUARE_OPEN: char = '[';
const SQUARE_CLOSE: char = ']';
const CURLY_OPEN: char = '{';
const CURLY_CLOSE: char = '}';
const PARENTHESIS_OPEN: char = '(';
const PARENTHESIS_CLOSE: char = ')';

pub fn brackets_are_balanced(string: &str) -> bool {
    let corresponding_brackets = HashMap::from([
        (SQUARE_OPEN, SQUARE_CLOSE),
        (CURLY_OPEN, CURLY_CLOSE),
        (PARENTHESIS_OPEN, PARENTHESIS_CLOSE),
    ]);
    string
        .chars()
        .try_fold(Vec::new(), |mut t, c| match c {
            open_bracket if [SQUARE_OPEN, CURLY_OPEN, PARENTHESIS_OPEN].contains(&open_bracket) => {
                t.push(open_bracket);
                ControlFlow::Continue(t)
            }
            close_bracket
                if [SQUARE_CLOSE, CURLY_CLOSE, PARENTHESIS_CLOSE].contains(&close_bracket) =>
            {
                if t.last().is_some_and(|possible_open_bracket| {
                    corresponding_brackets
                        .get(possible_open_bracket)
                        .is_some_and(|v| *v == close_bracket)
                }) {
                    t.pop();
                    ControlFlow::Continue(t)
                } else {
                    ControlFlow::Break(t)
                }
            }
            _ => ControlFlow::Continue(t),
        })
        .continue_value()
        .is_some_and(|v| v.is_empty())
}
