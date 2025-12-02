pub fn reply(message: &str) -> &str {
    let normalised = message.trim();
    let is_a_question = normalised.ends_with(['?']);
    let is_silence = normalised.is_empty();
    let is_shouting =
        normalised.to_uppercase() == normalised && normalised.chars().any(|c| c.is_uppercase());

    match (is_silence, is_shouting, is_a_question) {
        (true, _, _) => "Fine. Be that way!",
        (false, true, false) => "Whoa, chill out!",
        (false, false, true) => "Sure.",
        (false, true, true) => "Calm down, I know what I'm doing!",
        (false, false, false) => "Whatever.",
    }
}
