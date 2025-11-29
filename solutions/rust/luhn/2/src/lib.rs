use std::ops::Mul;

/// Check a Luhn checksum.
pub fn is_valid(code: &str) -> bool {
    code.chars()
        .rev()
        .filter(|c| !c.is_whitespace())
        .try_fold((0, 0), |(sum, i), c| {
            c.to_digit(10)
                .map(|d| if i % 2 == 1 { d.mul(2) } else { d })
                .map(|d| if d > 9 { d.saturating_sub(9) } else { d })
                .map(|d| (d + sum, i + 1))
        })
        .map_or(false, |(sum, count)| count > 1 && (sum % 10 == 0))
}
