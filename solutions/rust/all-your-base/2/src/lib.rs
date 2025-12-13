#[derive(Debug, PartialEq, Eq)]
pub enum Error {
    InvalidInputBase,
    InvalidOutputBase,
    InvalidDigit(u32),
}

pub fn convert(number: &[u32], from_base: u32, to_base: u32) -> Result<Vec<u32>, Error> {
    // tidy up validation
    if from_base < 2 {
        return Err(Error::InvalidInputBase);
    } else if to_base < 2 {
        return Err(Error::InvalidOutputBase);
    } else if let Some(n) = number.iter().find(|d| **d > from_base - 1) {
        return Err(Error::InvalidDigit(*n));
    } else if number.is_empty() || number.iter().all(|n| *n == 0) {
        return Ok(Vec::from([0]));
    }

    let mut as_native_integer = number
        .iter()
        .fold(0, |value, digit| value * from_base + *digit);

    // Preallocate vec length for max performance.
    // You can guess the number of digits in the output by log-base math, but even a simple pre-allocation of a small capacity is fine.

    let mut as_target_base: Vec<u32> = Vec::new();
    while as_native_integer > 0 {
        as_target_base.push(as_native_integer % to_base);
        as_native_integer /= to_base;
    }

    as_target_base.reverse();
    Ok(as_target_base)
}
