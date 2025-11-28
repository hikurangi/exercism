use std::ops::Mul;

/// Check a Luhn checksum.
pub fn is_valid(code: &str) -> bool {
    let code_normalised: Vec<char> = code.chars().filter(|c| *c != ' ').collect();

    if code_normalised.len() < 2 || code_normalised.iter().any(|c| !c.is_ascii_digit()) {
        return false;
    }

    code_normalised
        .iter()
        .rev()
        .enumerate()
        .fold(0_u32, |acc, (i, c)| {
            acc + c
                .to_digit(10)
                .map(|d| match i != 0 && !i.is_multiple_of(2) {
                    false => d,
                    true => match d < 5 {
                        true => d.mul(2),
                        false => d.mul(2).saturating_sub(9),
                    },
                })
                .expect("Invalid digit in code {code}")
        })
        .is_multiple_of(10)
}
