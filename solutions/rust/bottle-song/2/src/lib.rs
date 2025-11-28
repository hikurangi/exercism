const SECOND_LINE: &str = "And if one green bottle should accidentally fall,\n";

static NUMBERS_AS_WORDS: &[&str] = &[
    "No", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
];

fn recite_rec(verses: String, current_bottles: u32, take_down: u32) -> String {
    // TODO: use Numerics::default() converter instead of my own silly lookup, can work for any number!
    let current_bottle_count_text = match current_bottles {
        // TODO: ideally we would have this guard earlier, protecting the whole domain.
        n if n > 0 => NUMBERS_AS_WORDS[n as usize],
        _ => panic!("Invalid starting bottle count supplied: {current_bottles}"),
    };
    let current_plural_suffix = match current_bottles == 1 {
        true => "",
        false => "s",
    };

    // we're relying on the guard above to keep this number accurate.
    // all this code is panic-prone but we're probably ok
    let next_bottles = current_bottles.saturating_sub(1);
    let next_bottle_count_text = NUMBERS_AS_WORDS[next_bottles as usize];
    let next_plural_suffix = match next_bottles == 1 {
        true => "",
        false => "s",
    };

    let first_line = format!(
        "{current_bottle_count_text} green bottle{current_plural_suffix} hanging on the wall,\n",
    );
    let final_line = format!(
        "There'll be {count} green bottle{next_plural_suffix} hanging on the wall.",
        count = next_bottle_count_text.to_lowercase(),
    );

    // TODO: these two lines could be one line?
    // that line could be a meeting
    // that meeting could be an email
    let this_verse = format!("{}{}{}{}", first_line, first_line, SECOND_LINE, final_line);
    let all_verses_so_far = format!("{}\n\n{}", verses, this_verse);

    match take_down == 1 {
        true => all_verses_so_far,
        false => recite_rec(
            all_verses_so_far,
            current_bottles.saturating_sub(1),
            take_down.saturating_sub(1),
        ),
    }
}

pub fn recite(start_bottles: u32, take_down: u32) -> String {
    recite_rec(String::new(), start_bottles, take_down)
}
