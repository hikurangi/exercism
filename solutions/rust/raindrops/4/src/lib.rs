pub fn raindrops(n: u32) -> String {
    let replaced: String = [(3, "Pling"), (5, "Plang"), (7, "Plong")]
        .into_iter()
        .filter_map(|(divisor, word)| (n % divisor == 0).then_some(word))
        .collect();

    if replaced.is_empty() {
        n.to_string()
    } else {
        replaced
    }
}
