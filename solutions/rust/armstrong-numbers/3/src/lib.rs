pub fn is_armstrong_number(num: u32) -> bool {
    let stringified = num.to_string();
    let count: u32 = stringified.len().try_into().unwrap();

    num as u64
        == stringified
            .chars()
            .map(|n| (n.to_digit(10).unwrap() as u64).pow(count))
            .sum()
}
