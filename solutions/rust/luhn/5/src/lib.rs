pub fn is_valid(code: &str) -> bool {
    code.chars()
        .filter(|c| !c.is_whitespace())
        .rev()
        .try_fold((0, 0), |(sum, i), c| {
            c.to_digit(10)
                .map(|d| if i % 2 == 1 { d * 2 } else { d })
                .map(|d| if d > 9 { d - 9 } else { d })
                .map(|d| (d + sum, i + 1))
        })
        .is_some_and(|(sum, count)| count > 1 && (sum % 10 == 0))
}
