pub fn build_proverb(list: &[&str]) -> String {
    match list.len() {
        0 => String::new(),
        1 => format!("And all for the want of a {}.", list.first().unwrap()),
        2.. => {
            let mut poem: String = list.windows(2).fold(String::new(), |mut poem, window| {
                poem.push_str(&format!(
                    "For want of a {} the {} was lost.\n",
                    window[0], window[1]
                ));
                poem
            });

            poem.push_str(&format!(
                "And all for the want of a {}.",
                list.first().unwrap()
            ));

            poem
        }
    }
}
