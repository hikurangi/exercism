pub fn abbreviate(phrase: &str) -> String {
    phrase
        .chars()
        .scan(
            (None::<char>, String::new()),
            |(prev_char, acronym), current_char| {
                if let Some(prev) = *prev_char {
                    if ((prev.is_whitespace() || prev == '-' || prev == '_')
                        && current_char.is_alphabetic())
                        || (prev.is_ascii_lowercase() && current_char.is_ascii_uppercase())
                    {
                        acronym.push_str(&current_char.to_ascii_uppercase().to_string());
                    }
                } else if prev_char.is_none() {
                    acronym.push_str(&current_char.to_ascii_uppercase().to_string());
                }

                *prev_char = Some(current_char);

                Some((*prev_char, acronym.clone()))
            },
        )
        .last()
        .map(|(_c, acronym)| acronym)
        .unwrap()
        .to_string()
}
