pub fn is_armstrong_number(num: u32) -> bool {
    let stringified = num.to_string();

    let digit_count = stringified
        .len()
        .try_into()
        .expect("there was an issue with the digit count");

    let armstrongified: u128 = stringified.chars().fold(0, |acc, digit_char| {
        let digit: u128 = digit_char
            .to_digit(10)
            .expect("issue converting digit")
            .into();

        let value = acc + digit.pow(digit_count);
        value
    });

    num as u128 == armstrongified
}
