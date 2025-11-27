pub fn annotate(garden: &[&str]) -> Vec<String> {
    if garden.is_empty() || garden.iter().any(|row| row.is_empty()) {
        return garden.iter().map(|row| row.to_string()).collect();
    }

    let garden_matrix: Vec<Vec<char>> = garden.iter().map(|s| s.chars().collect()).collect();

    let mut flower_field: Vec<String> = Vec::new();

    for (row_index, current_row) in garden_matrix.iter().enumerate() {
        for (char_index, current_character) in current_row.iter().enumerate() {
            let updated_row = flower_field.get(row_index);
            let mut current_character_as_string = current_character.to_string();

            // rust will just let you subtract with overflow
            // maybe my compiler settings are too permissive?
            let prev_row = match row_index {
                0 => None,
                1.. => garden_matrix.get(row_index - 1),
            };

            let next_row = garden_matrix.get(row_index + 1);

            let prev_char_index: Option<usize> = match char_index {
                0 => None,
                1.. => Some(char_index - 1),
            };

            let next_char_index = char_index + 1;

            let adjacent_flower_count: usize = [
                prev_row.and_then(|r| prev_char_index.and_then(|idx| r.get(idx))),
                prev_row.and_then(|r| r.get(char_index)),
                prev_row.and_then(|r| r.get(next_char_index)),
                prev_char_index.and_then(|idx| current_row.get(idx)),
                // current char
                current_row.get(next_char_index),
                next_row.and_then(|r| prev_char_index.and_then(|idx| r.get(idx))),
                next_row.and_then(|r| r.get(char_index)),
                next_row.and_then(|r| r.get(next_char_index)),
            ]
            .into_iter()
            .flatten()
            .filter(|s| s.to_string() == "*")
            .collect::<Vec<&char>>()
            .len();

            if adjacent_flower_count > 0 && current_character_as_string != "*" {
                current_character_as_string = adjacent_flower_count.to_string();
            }

            match updated_row {
                // NOTE: this is horrible
                None => flower_field.push(current_character_as_string),
                // dunno why push_str wants a string reference
                Some(_u_r) => flower_field[row_index].push_str(&current_character_as_string),
            }
        }
    }

    flower_field
}
