pub fn series(digits: &str, len: usize) -> Vec<String> {
    digits
        .as_bytes()
        .windows(len)
        .flat_map(|w| String::from_utf8(w.to_vec()))
        .collect()
}
