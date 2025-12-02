pub fn reply(message: &str) -> &str {
    let normalised = message
        .chars()
        .filter(|c| !c.is_whitespace())
        .collect::<Vec<char>>();

    let is_a_question = normalised.last().is_some_and(|c| *c == '?');
    let is_silence = normalised.is_empty();

    let alphabetic = normalised
        .iter()
        .filter(|c| c.is_alphabetic())
        .collect::<Vec<&char>>();
    let is_shouting = alphabetic.len() > 0 && alphabetic.iter().all(|c| c.is_uppercase());

    match (is_silence, is_shouting, is_a_question) {
        (true, _, _) => "Fine. Be that way!",
        (false, true, false) => "Whoa, chill out!",
        (false, false, true) => "Sure.",
        (false, true, true) => "Calm down, I know what I'm doing!",
        (false, false, false) => "Whatever.",
    }
}
