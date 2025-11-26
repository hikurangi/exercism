pub fn raindrops(n: u32) -> String {
    let replacement = [(3, "Pling"), (5, "Plang"), (7, "Plong")].iter().fold(
        String::new(),
        |mut acc, (divisor, word)| {
            if n % divisor == 0 {
                acc.push_str(word);
            }
            acc
        },
    );

    if replacement.is_empty() {
        n.to_string()
    } else {
        replacement
    }
}
