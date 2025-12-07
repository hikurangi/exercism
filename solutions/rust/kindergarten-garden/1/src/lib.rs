fn letter_to_name(letter: &u8) -> &'static str {
    match letter {
        b'R' => "radishes",
        b'C' => "clover",
        b'G' => "grass",
        b'V' => "violets",
        _ => "unknown",
    }
}

pub fn plants(diagram: &str, student: &str) -> Vec<&'static str> {
    let student_index = student
        .chars()
        .next()
        .map(|c| c as usize - 'A' as usize)
        .unwrap();

    diagram
        .split("\n")
        .flat_map(|r| r.as_bytes().chunks(2).nth(student_index).unwrap())
        .map(|plant_letters| letter_to_name(plant_letters))
        .collect::<Vec<&str>>()
}
