const FLOWER_CHAR: char = '*';

pub fn annotate(garden: &[&str]) -> Vec<String> {
    if garden.is_empty() || garden.iter().any(|row| row.is_empty()) {
        return garden.iter().map(|row| row.to_string()).collect();
    }

    let garden_matrix: Vec<Vec<char>> = garden.iter().map(|s| s.chars().collect()).collect();

    let mut flower_field: Vec<String> = Vec::new();

    for (current_row_index, current_row) in garden_matrix.iter().enumerate() {
        for (current_char_index, current_character) in current_row.iter().enumerate() {
            let updated_row = flower_field.get(current_row_index);
            let current_character_as_string = current_character.to_string();
            let mut updated_character_as_string = current_character_as_string.clone();

            let prev_row = current_row_index
                .checked_sub(1)
                .and_then(|idx| garden_matrix.get(idx));

            let next_row = garden_matrix.get(current_row_index + 1);

            let prev_char_index = current_char_index.checked_sub(1);

            let next_char_index = current_char_index + 1;

            let adjacent_plots: [Option<&char>; 8] = [
                // Above Left
                prev_row.and_then(|r| prev_char_index.and_then(|idx| r.get(idx))),
                // Above
                prev_row.and_then(|r| r.get(current_char_index)),
                // Above Right
                prev_row.and_then(|r| r.get(next_char_index)),
                // Left
                prev_char_index.and_then(|idx| current_row.get(idx)),
                // Current Char, ie:
                // current_row.get(current_char_index)

                // Right
                current_row.get(next_char_index),
                // Below Left
                next_row.and_then(|r| prev_char_index.and_then(|idx| r.get(idx))),
                // Below
                next_row.and_then(|r| r.get(current_char_index)),
                // Below Right
                next_row.and_then(|r| r.get(next_char_index)),
            ];

            let adjacent_flower_count = adjacent_plots
                .into_iter()
                // we don't have to figure out bounds.
                // using safe methods, out-of-bounds access
                // can be filtered out as Nones
                .flatten()
                .filter(|s| **s == FLOWER_CHAR)
                .collect::<Vec<&char>>()
                .len();

            if adjacent_flower_count > 0 && *current_character != FLOWER_CHAR {
                updated_character_as_string = adjacent_flower_count.to_string();
            }

            match updated_row {
                None => flower_field.push(updated_character_as_string),
                // Safe(?) but suuuper ugly
                // since we're type-matching a statement to an expression
                Some(_) => flower_field
                    .get_mut(current_row_index)
                    .map(|up_row| {
                        up_row.push_str(&updated_character_as_string);
                    })
                    .unwrap_or(()),
            }
        }
    }

    flower_field
}
