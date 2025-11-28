const SECOND_LINE: &str = "And if one green bottle should accidentally fall,\n";

static NUMBER_TEXT: &[&str] = &[
    "No", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
];

pub fn recite(start_bottles: u32, take_down: u32) -> String {
    (0_u32..take_down)
        .into_iter()
        .fold(String::new(), |verses, i| {
            let current_bottles = start_bottles.saturating_sub(i);
            let current_bottle_count_text = NUMBER_TEXT[current_bottles as usize];
            let current_plural_suffix = if current_bottles == 1 { "" } else { "s" };

            let next_bottles = start_bottles.saturating_sub(i + 1);
            let next_bottle_count_text = NUMBER_TEXT[next_bottles as usize];
            let next_plural_suffix = if next_bottles == 1 { "" } else { "s" };

            let first_line = format!("{current_bottle_count_text} green bottle{current_plural_suffix} hanging on the wall,\n");
            let final_line = format!("There'll be {count} green bottle{next_plural_suffix} hanging on the wall.",
                count = next_bottle_count_text.to_lowercase()
            );

            format!("{verses}\n\n{first_line}{first_line}{SECOND_LINE}{final_line}")
        })
}
