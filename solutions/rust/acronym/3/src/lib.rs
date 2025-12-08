pub fn abbreviate(phrase: &str) -> String {
    let mut prev_char = phrase.chars().next().unwrap().to_ascii_uppercase(); // we will panic if user supplies an empty string
    let mut acronym = prev_char.to_string();

    for current_char in phrase.chars().skip(1) {
        if ((prev_char.is_whitespace() || prev_char == '-' || prev_char == '_')
            && current_char.is_alphabetic())
            || (prev_char.is_ascii_lowercase() && current_char.is_ascii_uppercase())
        {
            acronym.push(current_char.to_ascii_uppercase())
        }
        prev_char = current_char;
    }

    acronym
}
